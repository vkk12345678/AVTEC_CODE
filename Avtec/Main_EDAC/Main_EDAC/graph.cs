using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Automation.BDaq;

enum TimeUnit { Microsecond, Millisecond, Second };
enum FrequencyUnit { Hz, KHz, MHz };
class graph
{
    #region fields
    Bitmap m_bitmap;
    Size m_bitmapSize;
    Control m_control;

    Double m_XcoordinateMin;
    Double m_XcoordinateMax;
    Double m_YcoordinateMin;
    Double m_YcoordinateMax;

    int m_panelLineCount;
    int m_panelRowCount;
    int m_pointCountPerScreen;
    Pen m_backgroundGridLinePen;
    Color m_backgroundColor;
    Pen[] m_penRelStartChan;

    int m_plotCount;
    Double m_sampleRate;
    int m_dataCountPerPlot;
    int m_copyDataCountPerChan;
    int m_allDataCountPerChanNow;

    Double[] m_plotData;
    PointF[][] m_dataPoint;

    double m_XcoordinateDivBase;
    Double m_XcoorDividedRate;
    Double m_XCoordTimeDiv;
    int m_offsetIndex;
    Double m_XCoordTimeOffset;
    bool m_isDrawContinue;
    int m_countDrawed;

    #endregion

    #region ctor and dtor
    public graph(Size bmSize, Control control)
    {
        m_control = control;
        m_bitmapSize = bmSize;
        m_bitmap = new Bitmap(m_bitmapSize.Width, m_bitmapSize.Height);

        m_panelRowCount = 10;
        m_panelLineCount = 10;
        m_backgroundColor = Color.WhiteSmoke;   // White;
        m_backgroundGridLinePen = Pens.Silver; // .LightGray;

        m_plotCount = 1;
        m_pointCountPerScreen = 0;
        m_allDataCountPerChanNow = 0;

        m_offsetIndex = 0;
        m_copyDataCountPerChan = 0;
        m_XCoordTimeOffset = 0;
        m_XCoordTimeDiv = 66;
        m_XcoorDividedRate = 1;// us is unit.

        m_isDrawContinue = false;

        // allocate data buffer 
        m_penRelStartChan = new Pen[] { Pens.Red, Pens.Blue, Pens.DarkTurquoise, Pens.Green, Pens.DodgerBlue }; // .DarkSeaGreen, Pens.LightGray };
                                       //Pens.DarkBlue,Pens.SteelBlue,Pens.DarkSeaGreen,Pens.LightGreen,
                                       //Pens.NavajoWhite,Pens.DarkGreen  ,Pens.DeepPink,Pens.MediumOrchid,
                                       //Pens.LightGray,Pens.MediumVioletRed,Pens.MistyRose,Pens.PowderBlue};
        m_control.Paint += new PaintEventHandler(control_Paint);

    }

    #endregion

    #region properties

    public int dataCountPerChanNow
    {
        get
        {
            return m_allDataCountPerChanNow;
        }
    }

    public Double XcoordinateMin
    {
        get
        {
            return m_XcoordinateMin;
        }
    }

    public Double XcoordinateMax
    {
        get
        {
            return m_XcoordinateMax;
        }
    }

    public Double YcoordinateMax
    {
        get
        {
            return m_YcoordinateMax;
        }
    }

    public Double YcoordinateMin
    {
        get
        {
            return m_YcoordinateMin;
        }
    }

    public Double XCoordTimeOffset
    {
        get
        {
            return m_XCoordTimeOffset;
        }
        set
        {
            m_XCoordTimeOffset = value;
        }
    }

    public Double XcoorDividedRate
    {
        get
        {
            return m_XcoorDividedRate;
        }
        set
        {
            m_XcoorDividedRate = value;
        }
    }

    public Double XCoordTimeDiv
    {
        get
        {
            return m_XCoordTimeDiv;
        }
        set
        {
            m_XCoordTimeDiv = value;
        }
    }

    public int PanelLineCount
    {
        get
        {
            return m_panelLineCount;
        }
        set
        {
            m_panelLineCount = value;
        }
    }

    public int PanelRawCount
    {
        get
        {
            return m_panelRowCount;
        }
        set
        {
            m_panelRowCount = value;
        }
    }

    public Pen BackgroundGridLinePen
    {
        get
        {
            return m_backgroundGridLinePen;
        }
        set
        {
            m_backgroundGridLinePen = value;
        }
    }

    public Color BackgroundColor
    {
        get
        {
            return m_backgroundColor;
        }
        set
        {
            m_backgroundColor = value;
        }
    }

    public Pen[] PenRelStartChan
    {
        get
        {
            return m_penRelStartChan;
        }
    }

    public bool isDrawContinue
    {
        get
        {
            return m_isDrawContinue;
        }
        set
        {
            m_isDrawContinue = value;
        }
    }
    #endregion

    #region methods
    public void InitGraph(int plotCount, int pointCountPerPlot)
    {
        m_plotData = new double[plotCount * (m_bitmapSize.Width * 4 + 1)];
        m_dataPoint = new PointF[plotCount][];
        for (int i = 0; i < plotCount; i++)
        {
            m_dataPoint[i] = new PointF[m_bitmapSize.Width * 4 + 1];
        }
        clear();
    }
    private void DrawBackgroundLine()
    {
        Graphics bg = Graphics.FromImage(m_bitmap);
        bg.Clear(m_backgroundColor);
        for (int i = 1; i < m_panelRowCount; i++)
        {
            bg.DrawLine(m_backgroundGridLinePen, new Point((int)(1.0 * i * (m_bitmapSize.Width - 1) / m_panelRowCount), 0), new Point((int)(1.0 * i * (m_bitmapSize.Width - 1) / m_panelRowCount), (m_bitmapSize.Height - 1)));
        }
        for (int i = 1; i < m_panelLineCount; i++)
        {
            bg.DrawLine(m_backgroundGridLinePen, new Point(0, (int)(1.0 * i * (m_bitmapSize.Height - 1) / m_panelLineCount)), new Point((m_bitmapSize.Width - 1), (int)(1.0 * i * (m_bitmapSize.Height - 1) / m_panelLineCount)));
        }
    }

    public void clear()
    {
        m_copyDataCountPerChan = 0;
        m_countDrawed = 0;
        m_control.Invalidate();
    }

    public void Shift(int shiftTime)
    {
        m_XCoordTimeOffset = shiftTime;
        clear();
        Plot(m_plotData, m_plotCount, m_dataCountPerPlot, m_sampleRate);
    }

    public void ScaleXCoordinateDiv(int DivValue)
    {
        m_XCoordTimeDiv = DivValue;
        clear();
        Plot(m_plotData, m_plotCount, m_dataCountPerPlot, m_sampleRate);
    }

    public void Plot(Double[] plotData, int channelCount, int dataCountOfPerChan, double sampleRate)
    {
        m_sampleRate = sampleRate;
        m_plotCount = channelCount;
        m_dataCountPerPlot = dataCountOfPerChan;

        m_offsetIndex = (int)(m_XCoordTimeOffset * m_sampleRate / 1000);
        m_XcoordinateDivBase = (m_bitmapSize.Width * 1000.0) / (m_sampleRate * m_panelRowCount);//ms
        if (sampleRate >= 10 * 1000)//us
        {
            m_XcoordinateDivBase = (m_bitmapSize.Width) * 1000.0 / ((m_sampleRate / 1000) * m_panelRowCount);
            m_offsetIndex = (int)(m_XCoordTimeOffset * m_sampleRate / (1000 * 1000));
        }

        if (dataCountOfPerChan == 1 && m_isDrawContinue == false)
        {
            m_XCoordTimeDiv = 1000;
        }
        m_XcoorDividedRate = m_XcoordinateDivBase / m_XCoordTimeDiv;

        int dataCountCur = 0;

        m_pointCountPerScreen = (int)(m_bitmapSize.Width * m_XCoordTimeDiv / m_XcoordinateDivBase) + 1;

        if (dataCountOfPerChan == 1 && m_isDrawContinue == false)
        {
            if (m_copyDataCountPerChan > m_pointCountPerScreen)
            {
                m_copyDataCountPerChan = 0;
            }
            dataCountCur = m_copyDataCountPerChan;
            m_copyDataCountPerChan += dataCountOfPerChan;
            Array.Copy(plotData, m_plotData, channelCount);
            m_offsetIndex = 0;
        }
        else
        {
            if (m_isDrawContinue == false)
            {
                Array.Copy(plotData, m_plotData, m_plotData.Length > plotData.Length ? plotData.Length : m_plotData.Length);
                dataCountCur = 0;//always start from begin for the block data.
                if (dataCountOfPerChan - m_offsetIndex > m_pointCountPerScreen)
                {
                    m_copyDataCountPerChan = m_pointCountPerScreen;
                }
                else
                {
                    m_copyDataCountPerChan = dataCountOfPerChan - m_offsetIndex;
                }
            }
            else if (m_isDrawContinue)
            {
                dataCountCur = 0;
                CreateDataBuffer(plotData, channelCount, dataCountOfPerChan);
            }
        }

        CreatePointsOfLine(m_offsetIndex, dataCountCur);
        m_control.Invalidate();
    }

    private void CreateDataBuffer(Double[] dataScaled, int channelCount, int dataCountOfPerChan)
    {
        if (dataCountOfPerChan >= m_pointCountPerScreen)
        {
            Array.Copy(dataScaled,
                       (int)(channelCount * (dataCountOfPerChan - m_pointCountPerScreen)),
                       m_plotData,
                       0,
                       channelCount * (m_pointCountPerScreen));
            m_countDrawed = m_pointCountPerScreen;
            m_copyDataCountPerChan = m_pointCountPerScreen;
            m_offsetIndex = 0;
        }
        else if (dataCountOfPerChan < m_pointCountPerScreen)
        {
            m_countDrawed += dataCountOfPerChan;

            if (m_countDrawed <= dataCountOfPerChan)
            {
                Array.Copy(dataScaled, 0, m_plotData, 0, channelCount * dataCountOfPerChan);
                m_copyDataCountPerChan = dataCountOfPerChan;
            }
            else
            {
                if (m_countDrawed < m_pointCountPerScreen)
                {
                    Array.Copy(dataScaled, 0, m_plotData, (m_countDrawed - dataCountOfPerChan) * channelCount, channelCount * dataCountOfPerChan);
                    m_copyDataCountPerChan = m_countDrawed;
                }
                else if (m_countDrawed >= m_pointCountPerScreen &&
                         m_countDrawed - m_pointCountPerScreen <= dataCountOfPerChan)
                {
                    int lastCount = channelCount * (m_countDrawed - m_pointCountPerScreen);

                    Array.Copy(m_plotData,
                              lastCount,
                              m_plotData,
                              0,
                              channelCount * (m_countDrawed - dataCountOfPerChan) - lastCount);
                    Array.Copy(dataScaled,
                               0,
                               m_plotData,
                               channelCount * (m_countDrawed - dataCountOfPerChan) - lastCount,
                               channelCount * dataCountOfPerChan);
                    m_copyDataCountPerChan = m_pointCountPerScreen;
                }
                else
                {
                    Array.Copy(m_plotData,
                               channelCount * dataCountOfPerChan,
                               m_plotData,
                               0,
                               channelCount * (m_pointCountPerScreen - dataCountOfPerChan));
                    Array.Copy(dataScaled,
                               0,
                               m_plotData,
                               channelCount * (m_pointCountPerScreen - dataCountOfPerChan),
                               channelCount * dataCountOfPerChan);

                    m_copyDataCountPerChan = m_pointCountPerScreen;

                    m_countDrawed -= dataCountOfPerChan;

                }
            }
        }

    }

    private void CreatePointsOfLine(int offsetIndex, int dataCountCur)
    {
        int chanCountOffset = offsetIndex;

        if (m_copyDataCountPerChan > m_bitmapSize.Width * 4 + 1)
        {
            m_copyDataCountPerChan = m_bitmapSize.Width * 4 + 1;
        }

        //if shift time is more than 0,should discard the shift data.
        for (int index = dataCountCur; index < m_copyDataCountPerChan; index++)
        {
            for (int relChannel = 0; relChannel < m_plotCount; relChannel++)
            {
                m_dataPoint[relChannel][index].Y =
                   (float)((m_bitmapSize.Height - 1) * ((m_YcoordinateMax - m_plotData[chanCountOffset * m_plotCount + relChannel]) / (m_YcoordinateMax - m_YcoordinateMin)));

                m_dataPoint[relChannel][index].X = (float)Math.Round((index) * m_XcoorDividedRate);

            }
            chanCountOffset++;
        }
    }

    private void DrawBitmap()
    {
        DrawBackgroundLine();
        //draw sample data on bitmap.
        if (m_copyDataCountPerChan > 0)
        {
            Graphics bg = Graphics.FromImage(m_bitmap);
            Pen drawLinePen;
           
            int copyDataCountPerChan = m_copyDataCountPerChan;
            PointF[] drawData = new PointF[copyDataCountPerChan];
            for (int relChannel = 0; relChannel < m_plotCount; relChannel++)
            {
                Array.Copy(m_dataPoint[relChannel], 0, drawData, 0, copyDataCountPerChan);
                GetPenForChannel(relChannel, out  drawLinePen);
                if (copyDataCountPerChan > 1)
                {
                    bg.DrawLines(drawLinePen,drawData) ;
                }
                else
                {
                    PointF drawPoint = drawData[0];
                    bg.DrawLine(drawLinePen, drawPoint, drawPoint);
                }
            }
        }
    }

    void control_Paint(object sender, PaintEventArgs e)
    {
        DrawBitmap();
        e.Graphics.DrawImage(m_bitmap, new Point(0, 0));
    }

    public void SetXCoordinate(MathInterval rangeX, Label label_XCoordinateMin, Label label_XCoordinateMax, TimeUnit unit)
    {
        string timeUint = "ms";
        switch (unit)
        {
            case TimeUnit.Second:
                timeUint = "Sec";
                break;
            case TimeUnit.Millisecond:
                timeUint = "ms";
                break;
            case TimeUnit.Microsecond:
                timeUint = "us";
                break;
            default:
                break;
        };
        label_XCoordinateMin.Text = rangeX.Min.ToString() + " " + timeUint;
        label_XCoordinateMax.Text = rangeX.Max.ToString() + " " + timeUint;
        if (rangeX.Max >= 1000)
        {
            if (timeUint == "ms")
            {
                timeUint = "Sec";
            }
            if (timeUint == "us")
            {
                timeUint = "ms";
            }

            rangeX.Min /= 1000;
            rangeX.Max /= 1000;
            label_XCoordinateMin.Text = rangeX.Min.ToString() + " " + timeUint;
            label_XCoordinateMax.Text = rangeX.Max.ToString() + " " + timeUint;
        }
        m_XcoordinateMin = rangeX.Min;
        m_XcoordinateMax = rangeX.Max;
    }

    public void SetYCoordinate(MathInterval rangeY, Label label_YCoordinateMax, Label label_YCoordinateMin, Label label_YCoordinateMiddle, ValueUnit unit)
    {
        m_YcoordinateMax = rangeY.Max;
        m_YcoordinateMin = rangeY.Min;
        string sUnit = "";
        switch (unit)
        {
            case ValueUnit.Kilovolt:
                sUnit = "kV";
                break;
            case ValueUnit.Volt:
                sUnit = "V";
                break;
            case ValueUnit.Millivolt:
                sUnit = "mV";
                m_YcoordinateMax = rangeY.Max / 1000;
                m_YcoordinateMin = rangeY.Min / 1000;
                break;
            case ValueUnit.Milliampere:
                sUnit = "mA";
                break;
            case ValueUnit.Ampere:
                sUnit = "A";
                break;
            case ValueUnit.Kiloampere:
                sUnit = "KA";
                break;
            case ValueUnit.CelsiusUnit:
                sUnit = "C";
                break;
            default:
                break;
        }
        label_YCoordinateMax.Text = rangeY.Max.ToString() + sUnit;
        label_YCoordinateMin.Text = rangeY.Min.ToString() + sUnit;
        if (rangeY.Max == -rangeY.Min)
        {
            label_YCoordinateMiddle.Text = " 0";
        }
        else
        {
            label_YCoordinateMiddle.Text = "";
        }

    }

    public void SetYCoordinate(MathInterval rangeY, Label label_YCoordinateMax, Label label_YCoordinateMin, Label label_YCoordinateMiddle, FrequencyUnit unit)
    {
        m_YcoordinateMax = rangeY.Max;
        m_YcoordinateMin = rangeY.Min;
        string sUnit = "";
        double middleY;

        switch (unit)
        {
            case FrequencyUnit.Hz:
                sUnit = "Hz";
                break;
            case FrequencyUnit.KHz:
                sUnit = "k";
                m_YcoordinateMax = rangeY.Max * 1000;
                m_YcoordinateMin = rangeY.Min * 1000;
                break;
            case FrequencyUnit.MHz:
                sUnit = "M";
                m_YcoordinateMax = rangeY.Max * 1000000;
                m_YcoordinateMin = rangeY.Min * 1000000;
                break;
            default:
                break;
        }

        label_YCoordinateMax.Text = rangeY.Max.ToString() + " " + sUnit;
        label_YCoordinateMin.Text = rangeY.Min.ToString();

        middleY = (rangeY.Max - rangeY.Min) / 2 + rangeY.Min;
        label_YCoordinateMiddle.Text = middleY.ToString() + " " + sUnit;
    }

    private void GetPenForChannel(int plotNumber, out Pen drawLinePen)
    {
        if (plotNumber >= 0 && plotNumber < 16)
        {
            drawLinePen = m_penRelStartChan[plotNumber];
        }
        else
        {
            drawLinePen = Pens.Black;
        }
    }

    #endregion
}
