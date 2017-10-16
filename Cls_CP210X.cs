using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;   //  pour DllImport

namespace PABLO
{
    public class Cls_CP210X
    {

        // Declare statements for all the functions in the CP210x DLL
        // NOTE: These statements assume that the DLL file is located in
        //       the same directory as this project.
        //       If you change the location of the DLL, be sure to change the location
        //       in the declare statements also.

        //GetDeviceVersion() return codes
        public static int CP210x_CP2101_VERSION = 0x01;
        public static int CP210x_CP2102_VERSION = 0x02;
        public static int CP210x_CP2103_VERSION = 0x03;
        public static int CP210x_CP2104_VERSION = 0x04;    // <- Used at the relay board
        public static int CP210x_CP2105_VERSION = 0x05;

        //  Return codes
        public static int CP210x_SUCCESS = 0x00;
        public static int CP210x_DEVICE_NOT_FOUND = 0xff;
        public static int CP210x_INVALID_HANDLE = 0x01;
        public static int CP210x_INVALID_PARAMETER = 0x02;
        public static int CP210x_DEVICE_IO_FAILED = 0x03;
        public static int CP210x_FUNCTION_NOT_SUPPORTED = 0x04;
        public static int CP210x_GLOBAL_DATA_ERROR = 0x05;
        public static int CP210x_FILE_ERROR = 0x06;
        public static int CP210x_COMMAND_FAILED = 0x08;
        public static int CP210x_INVALID_ACCESS_TYPE = 0x09;

        //   Masks for the serial number and description
        public static int CP210x_RETURN_SERIAL_NUMBER = 0x00;
        public static int CP210x_RETURN_DESCRIPTION = 0x01;
        public static int CP210x_RETURN_FULL_PATH = 0x02;

        //  Mask and Latch value bit definitions
        public static int CP210x_GPIO_0 = 0x01;
        public static int CP210x_GPIO_1 = 0x02;
        public static int CP210x_GPIO_2 = 0x04;
        public static int CP210x_GPIO_3 = 0x08;

        //  CP210xRUNTIMEDLL_API CP210x_STATUS WINAP

        //  Read CP210x Output Latch State. 
        //  Public Declare Function CP210xRT_ReadLatch Lib "CP210xRuntime.dll" (ByVal Handle As UShort, ByRef Latch As Byte) As Integer
        [DllImport("CP210xRuntime.dll")]
        public static extern int CP210xRT_ReadLatch([In] IntPtr Handle, ref byte Latch);


        //  Write CP210x Output Latch. Relays are switched-on at Low (0)
        //  Public Declare Function CP210xRT_WriteLatch Lib "CP210xRuntime.dll" (ByVal Handle As Integer, ByVal lpbMask As Byte, ByVal lpbLatch As Byte) As Integer

        [DllImport("CP210xRuntime.dll")]
        public static extern int CP210xRT_WriteLatch([In] IntPtr Handle, [In] byte lpbMask, [In] byte lpbLatch);

        //  Get Device Part Number     
        //Public Declare Function CP210xRT_GetPartNumber Lib "CP210xRuntime.dll" (ByVal Handle As UShort, ByRef lpbPartNum As Byte) As Integer

        [DllImport("CP210xRuntime.dll")]
        public static extern int CP210xRT_GetPartNumber([In] IntPtr Handle, ref byte lpbPartNum);


        // Read the Serial Number of the CP210x
        // Public Declare Function CP210xRT_GetDeviceSerialNumber Lib "CP210xRuntime.dll" (ByVal cyHandle As UShort, ByVal lpSerialNumber As String, ByRef lpbLength As Byte, ByVal bConvertToASCII As Boolean) As Integer

        // Get Device Product String
        //Public Declare Function CP210xRT_GetDeviceProductString Lib "CP210xRuntime.dll" (ByVal cyHandle As UShort, ByVal lpProduct As String, ByRef lpbLength As Byte, ByVal bConvertToASCII As Boolean) As Integer


    }
}
