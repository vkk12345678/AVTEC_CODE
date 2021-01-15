using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection.Emit;

namespace Rd_Gantner
{
    public class eGateUtility
    {
        [DllImport("eGateUtility.dll")]
        public static extern int _CDDLG_IdentifyDevices_First(int useEXT,
                                                               double scanTime,
                                                               byte[] adapterInfo,
                                                               byte[] deviceInfo,
                                                               byte[] error);
        [DllImport("eGateUtility.dll")]
        public static extern int _CDDLG_IdentifyDevices_Next(
                                                               byte[] adapterInfo,
                                                               byte[] deviceInfo,
                                                               byte[] error);
        [DllImport("eGateUtility.dll")]
        public static extern int _CDDLG_IdentifyVisual(string mac, 
                                                        byte[] error);
    }
    public class HSP
    {
        public enum RETURNSTATES
        {
            OK=0,
            ERROR=1,
            CONNECTION_ERROR=2,
            INIT_ERROR=3,
            LIMIT_ERROR=4,
            SYNC_CONF_ERROR=5,
            MULTYUSED_ERROR=6,
            INDEX_ERROR=7,
            FILE_ERROR=8,
            NOT_READY=9,
            EXLIB_MISSING=10,
            NOT_CONNECTED=11,
            NO_FILE=12,
            CORE_ERROR=13,
            POINTER_INVALID=14
        };

        public enum CHANNELINFO
        {
            Name=0,
            Unit=1,
            DataDirection=2,
            Format=3,
            Type=4,
            InputAccessIndex=5,
            OutputAccessIndex=6,
            TotalAccessIndex=7,
            Precision=8,
            FieldLength=9
        };
        public enum DEVICEINFO
        {
            //String
            Location=10,
            Address=11,
            Type=12,
            Version=13,
            TypeCode=14,
            SerialNumber=15,
            //Integer
            SampleRate=16,
            ModuleCount=17,
            ChnnelCount=18
        };
        public enum MODULEINFO
        {
            //String
            Type = 19,
            TypeCode = 20,
            Location = 21,
            //Integer
            UARTIndex = 22,
            Address = 23,
            VariableCount = 24
        };
        public enum STORAGEINFO
        {
            STORE_FILECOUNT=25,
            STORE_SECONDS=26
        };
        public enum DATADIRECTION
        {
            Input=0,   // = Input
            Output=1,   // = Output
            InputOutput=2,   // = Input/output
            Empty=3,   // = Empty
            Statistic=4	// = Statistic Channels
        };
        public enum CONNECTIONTYPE
        {
            Online=1,
            Buffer=2,
            EconLogger=3,
            Archives=4,
            Files=5,
            Diagnostic=7
        };
        public enum STATISTICINFOTYPE
        {
            Connected=0,
            StackSize=1,
            DecodeTime=2
        };
        public enum DIAGNOSTICTYPE
        {
            Controller=0,
            Interface=1,
            Transport=2,
            Variable=3,
            ItemCount=4
        };
        public enum STORAGETYPE
        {
            MDF=0,
            CSV=1
        };
        public enum DATATYPE
        {
            No=0,
            Bool=1,
            SINT8=2,
            USINT8=3,
            SINT16=4,
            USINT16=5,
            SINT32=6,
            USINT32=7,
            FLOAT=8,
            SET8=9,
            SET16=10,
            SET32=11,
            DOUBLE=12,
            SINT64=13,
            USINT64=14,
            SET64=15
        };
        public enum CALLBACKTYPE
        {
            Control = 0,
            Error = 1,
            Diagnostic = 2,
            DSPData = 3,
            FReady = 4,
            Debug = 5
        };
        public enum REMOTECONTROL
        {
            Start = 0,
            Stop = 1,
            End = 2
        };
        public enum FILETYPE
        {
            DIR_ALL=0,
            FLASHAPPLICATION=1,
            FLASHDATA=2,
            USBDATA=3,
            VIRTUALSTATE=4,
            VIRTUALONLINEBUFFER=5,
            VIRTUALCIRCLEBUFFER=6,
            VIRTUALARCHIVE=7,
            VIRTUALLOGGER=8
        };
        /****************************************************************************************/
        public delegate void HSP_CallBack(int ID, double value, byte[] message);

        /*
            Use CallBack callback = new CallBack(targetFunction) in your main program.
            Then pass the delegate to Register calback.
         
            The dll will call "targetFunction" depending on "callbackType"
            
            Please be sure that targetFunction cannot block DLL!
         
        */
        public static void RegisterCallback(int connectionInstance,
                                            int callbackType,
                                            HSP_CallBack callback)
        {
            _CD_eGateHighSpeedPort_RegisterCallback(connectionInstance,
                                                    callbackType,
                                                    callback);
        }
        /****************************************************************************************/
        /************		Initialize connection
        Initialize the Ethernet HighSpeedPort Connection to a Gantner-Instruments		
        Controller. 																	
	    																		
        IN:
            hostName		 ...  the ip address of the controller

            timeout			 ...  the connection timeout in seconds

            mode			 ...  the communication mode (see constants "Connection Types")
								  
                                  If HSP_ONLINE: this function initializes the complete 
                                  communication.

                                  If HSP_BUFFER or HSP_LOGGER: 
                                  eGateHighSpeedPort_InitBuffer is needed to select the 
                                  buffer index before data transfer.

                                  Other Communication types will only open the Port but 
                                  not initialize anything.

            sampleRate       ...  The sample rate for reading single or buffered data 
                                  from the controller.
								  
                                  HSP_ONLINE: up to 1000Hz (check System Health!)
                                  HSP_BUFFER: 2Hz default (otherwise check System Health!)

         OUT:
	
            client Instance	  ... If several tasks of the application uses the same connection,
                                  some DLL functions need the client instance 
                                  for synchronisation.

            connectionInstance .. This dll supports up to 10 connections which 
                                  work in different threads.

                                  To identify the connection, this Instance has to be stored.

							
        RETURN:	General Returncodes	
         
        */
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_Init(string hostname,
                                                              int timeout,
                                                              int mode,
                                                              int sampleRate,
                                                              ref int HCLIENT,
                                                              ref int HCONNECTION);
        /****************************************************************************************/
        /************		Initialize Buffer
												    
		Initializes a buffered connection with a specified circular buffer or test.con
		dataLogger on a supported controller.

		Communication Type must be HSP_BUFFER or HSP_LOGGER.

		eGateHighSpeedPort_Init() has to be used first!!
	    																		
 	    IN:

		    connection Instance	...	to select the correct connection

		    buffer Index		... the index of a CircleBuffer or test.con Logger.
								    Check configuration if the correct buffer type is supported
								    and configured correctly!

	    RETURN:	General Returncodes	
        
        */
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_InitBuffer(int HCONNECTION,
                                                                    int bufferIndex,
                                                                    int autoRun);

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_SetSampleRate(int connectionInstance, 
															          long sampleRateHz);

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_GetSampleRate(int connectionInstance, 
															          ref long sampleRateHz);

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_SetReceiveTimeout(int connectionInstance, 
																          long timeOut);

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_GetReceiveTimeout(int connectionInstance, 
																          ref long timeOut);

        /****************************************************************************************/
        /************		Initialize Synchronisation

		Initializes a synchronisation thread of up to 10 connections.
		The synchronized data can be used like any other connection.

	    IN:

		    connectionArray	... the connection Instances for the connections to be synchronized

	    OUT:

		    connectionInstance ... the instance to access to the data

		    clientInstance

	    RETURN: General Returncodes

        */
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_InitSynchronization(ref int syncConnectionInstance,
																	         ref int clientInstance,
																	         int sourceConnectionInstance);
        /****************************************************************************************/
        /************		Initialize MDF data storage												

		Initializes a new thread for data storage to MDF format.

		Only data from one connection can be stored to a MDF file.
		If several connections shoule be stored to a single file, 
		synchronisation has to be done first.

	    IN:

		    connection Instance ... to select the data source

		    fileName			...	defines the format of the filename

		    maxSamples			... defines the length of the file in samples (<0 if no limit)

		    maxSeconds			... defines the length of the file in seconds (<0 if no limit)

        RETURN: General Returncodes

        */
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_InitMDFStorage(int connectionInstance,
																	    string fileNameFormat,
																	    string text,
																	    string name,
																	    string department,
																	    string project,
																	    string subject,
																	    double maxSamples,
																	    double maxSeconds,
                                                                        double totalSeconds,
                                                                        double totalSamples);
        /****************************************************************************************/
       [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
       public static extern int _CD_eGateHighSpeedPort_ConfigureMDFChannel(int connectionInstance,
																	         int MDFGroupIndex,
																	         int MDFChannelIndex,
																	         int HWChannelIndex,
																	         int isTimeChannel,
                                                                             string unit,
                                                                             float factor,
                                                                             float offset);
       /****************************************************************************************/
       /************		Start/Stop auto mode
  
	        This functions are used to start/stop configured mechanisms like reading buffer, synchronisation		
	        or data storage.
       */
       [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
       public static extern int _CD_eGateHighSpeedPort_StartConfiguration();

       [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
       public static extern int _CD_eGateHighSpeedPort_StopConfiguration();

       /****************************************************************************************/
       [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
       public static extern int _CD_eGateHighSpeedPort_GetNumberOfChannels(int ConnectionInstance, 
															               int directionID,
                                                                           ref int ChannelCount);
       /****************************************************************************************/
       [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
       public static extern int _CD_eGateHighSpeedPort_GetChannelInfo_String(int ConnectionInstance,
															                 int typeID,
															                 int directionID,
															                 int channelIndex,
															                 byte[] channelInfo);
       /****************************************************************************************/
       [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
       public static extern int _CD_eGateHighSpeedPort_GetChannelInfo_Int(int ConnectionInstance,
                                                                             int typeID,
                                                                             int directionID,
                                                                             int channelIndex,
                                                                             ref int channelInfo);
       /****************************************************************************************/
       [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
       public static extern int _CD_eGateHighSpeedPort_Close(int connectionInstance,
													        int clientInstance);
       /****************************************************************************************/

       [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
       private static extern int _CD_eGateHighSpeedPort_RegisterCallback(int connectionInstance,
                                                                        int callbackType,
                                                                        HSP_CallBack callback);
       /****************************************************************************************/
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void _CD_eGateHighSpeedPort_RemoteControl(int remoteControlID);
        /****************************************************************************************/

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void _CD_eGateHighSpeedPort_StartControlThread(int connectionInstance);
        /****************************************************************************************/

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_Diagnostic(int connectionInstance,
                                                                    int diagType,
                                                                    int index,
                                                                    ref int state,
                                                                    ref int errorCount);
        /****************************************************************************************/
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void _CD_eGateHighSpeedPort_IdentDLL(byte[] DLLVersion,
                                                                 byte[] DLLDate);
        /****************************************************************************************/
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_GetDeviceInfo(int ConnectionInstance,
                                                              int typeID,
                                                              int index,
                                                              ref double info,
                                                              byte[] Info);
        /****************************************************************************************/
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_ModifyMDFTimestamp(int ConnectionInstance,
                                                                           int typeID);
        /****************************************************************************************/
        /************			Set BackTime													

		Is used to set a BackTime Manually for one Ethernet Request.

		Backtime: defines how many seconds of buffer data should be read at one request.

	    IN:

		    connection Instance	...	to select the correct connection

		BackTime			    ... -1: complete buffer will be read
								     0: buffer will be cleared completely before the next request
								    >0: the next request will contain the last "BackTime" seconds
									    or the complete buffer if less than "BackTime" seconds are stored

	    RETURN:	General Returncodes	

        */
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_SetBackTime(int ConnectionInstance,
                                                                    double BackTime);

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_GetBufferFrames(int ConnectionInstance,
									                                    int ClientInstance);

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_ReadBuffer_NextFrame(int ConnectionInstance,
												                             int ClientInstance);
        /****************************************************************************************/
        /************		Initialize ASCII data storage												

		Initializes a new thread for data storage to any ASCII format.

		Only data from one connection can be stored to a ASCII file.
		If several connections shoule be stored to a single file, 
		synchronisation has to be done first.

	    IN:

		    connection Instance ... to select the data source

		    fileName			...	defines the format of the filename

		    maxSamples			... defines the length of the file in samples (<0 if no limit)

		    maxSeconds			... defines the length of the file in seconds (<0 if no limit)

        RETURN: General Returncodes

        */
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_InitASCIIStorage(int connectionInstance,
																	    string fileNameFormat,
																	    string fileHeaderText,
																	    string channelSepChar,
																	    string frameSepChar,
																	    double maxSamples,
																	    double maxSeconds,
																	    double totalSamples,
																	    double totalSeconds);
        /****************************************************************************************/
        /************		Add ASCII save channel
        
        This function selects a channel from the connection to be stored in the ASCII file.
        10 Groups are possible with 1024 channels for each group as maximum.

	    IN:

		    connection Instance	... to select the data source

		    HWChannelIndex		... real channel index on device

		    precision			... number of decimal positions 
                                    if <1 -> as configured on the module
        */

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_AddASCIIChannel(int connectionInstance,
																        int HWChannelIndex,
																        int precision);
        /****************************************************************************************/

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_ReadOnline_Single(int connectionInstance,
                                                                          int HWChannelIndex,
                                                                          ref double value);
        /****************************************************************************************/

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_WriteOnline_Single_Immediate(int connectionInstance,
                                                                                int HWChannelIndex,
                                                                                double value);
        /***************************************************************************************/
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_ToggleDebugMode();

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_ExplainError(int connectionInstance, 
															        byte[] errorMessage);

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_GetDebugMessage(byte[] errorMessage);

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_Connected(int connectionInstance);

        /****************************************************************************************/

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_CopyFile(int connectionInstance, 
														         int fileIndex,
														         string sourceFileName,
														         string savePath);
        /****************************************************************************************/

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_DecodeFile_Select(ref int connectionInstance,
																          int source,
																          string fileName);
        /****************************************************************************************/

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_GetFileCount(int connectionInstance, 
														             int fileTypeID,
															         ref int fileCount);
        /****************************************************************************************/
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_GetFileInfo(int connectionInstance, 
														            int fileIndex,
                                                                    byte[] fileName,
															        ref int size,
															        ref double OLETime);
        /****************************************************************************************/

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_ReadBuffer_NextChannel(int ConnectionInstance,
												                               int ClientInstance);
        /****************************************************************************************/

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_ReadBuffer_Single(int ConnectionInstance,
										                                  int ClientInstance,
									                                      int ChannelIndex,
										                                  ref double value);
        /****************************************************************************************/

        //[DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int _CD_eGateHighSpeedPort_Init(string hostname,
        //                                                      int timeout,
        //                                                      int mode,
        //                                                      int sampleRate,
        //                                                      ref int HCLIENT,
        //                                                      ref int HCONNECTION);
        ///****************************************************************************************/
        /************		Read buffer to double array									

	Reads buffered data to a double array

  	IN:
		connectionInstance	...	To select the correct connection


		arrayLength			... Number of elements in "valueArray"
								If "valueArray" is smaller than "arrayLength" this will cause a segfault!!!

		fillArray			... With fillArray set to "1" this call will block until "arrayLength/channelCount"
								frames are received!

	OUT:

		valueArray			... Pointer to a double array with at least "ArrayLength" elements
								Contains double converted values.


		receivedFrames		... Number of frames in valueArray after processing
								(frame = 1 sample over all channels)

		channelCount		... Number of channels in one frame
								(can also be read with "getNumberOfChannels")

		complete			...	Indicates if one TCP/IP request was completely decoded


	RETURN:	General Returncodes	

*/
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateHighSpeedPort_ReadBufferToDoubleArray(int ConnectionInstance,
                                                                                double[] valueArray,
                                                                                int arrayLength,
                                                                                int fillArray,
                                                                                ref int receivedFrames,
                                                                                ref int channelCount,
                                                                                ref int complete);

        /****************************************************************************************/
        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateDistributorPort_Init(string hostName, 
											                   int timeOut, 
											                   ref int clientInstance, 
											                   ref int connectionInstance);

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateDistributorPort_InitCommunication(
											  string hostName_Destination, 
											  int	port_Destination,
											  string hostName_Source, 
											  int	port_Source,
											  int	sampleRate,
											  int	retriggerTime,
											  int	useTransferCounter,
											  int	channelOffset_Send,
											  int	channelCount_Send,
											  int	channelOffset_Receive,
											  int	channelCount_Receive,
											  int	connectionInstance);

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateDistributorPort_Send(int connectioInstance,
														double[] valueArray);

        [DllImport("eGateHighSpeedPort.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _CD_eGateDistributorPort_Recv(int connectioInstance,
														double[] valueArray);


        internal static void _CD_eGateHighSpeedPort_Init()
        {
            throw new NotImplementedException();
        }
    }
}