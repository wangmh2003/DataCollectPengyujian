﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace GJ_DNC_test
{

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct PmCartesia
    {
        public Double x;
        public Double y;
        public Double z;
    };
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct CncPose
    {
        [MarshalAs(UnmanagedType.Struct, SizeConst = 1)]
        public PmCartesia info;
        [MarshalAs(UnmanagedType.R8)]
        public Double a;
        [MarshalAs(UnmanagedType.R8)]
        public Double b;
        [MarshalAs(UnmanagedType.R8)]
        public Double c;
        [MarshalAs(UnmanagedType.R8)]
        public Double u;
        [MarshalAs(UnmanagedType.R8)]
        public Double v;
        [MarshalAs(UnmanagedType.R8)]
        public Double w;
    }
    public struct CNCINFO
    {
        public double host_value1; //编程值   
        public double host_value2;
        public double host_value3;
        public double host_value4;
        public double host_value5;
        public double host_value6;

        public double ahost_value1;
        public double ahost_value2;  //各轴位置 实际值
        public double ahost_value3;
        public double ahost_value4;
        public double ahost_value5;
        public double ahost_value6;

        public double dist_togo1;     //剩余量
        public double dist_togo2;
        public double dist_togo3;
        public double dist_togo4;
        public double dist_togo5;
        public double dist_togo6;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public double[] torq;           //进给轴扭矩

        public double feed_speed; 
        public double afeed_speed;   
        public double dfeed_speed;       // 修调

        public double spindle_speed;
        public double aspindle_speed;
        public double dspindle_speed;

        public double travers_scale;      //手轮倍率
        public int spin_torq;           //主轴负载    
        public int current_line;         //当前行
        public int work_piece;           //计件
        public int tool_num;              //刀具号 
        public int axis_num;               //轴数

        public double tool_radius; 
        public double tool_length;

        public int disp_mode;               //显示状态
        public int task_state;              //任务状态
        public int interp_state;           //解释器状态

        public long poweron_time;           //上电时间
        public long run_time;              //运行时间
        public long cut_time;              //切削时间

        public long total_poweron_time;    
        public long total_run_time;
        public long total_cut_time;

        public int error_id;              //报警id
        public int error_axisnum;         //报警轴号

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]  //PROGNAME_LEN??
        public string prog_name;	         //程序名
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]  //PROGNAME_LEN??
        public string softversion;          //软件版本

        public int mainFileTotalLine;   //文件行号
        public int subFileTotalLine;   //从文件行号
        public int error_flag;         //错误标识

        public float x_blacklash;  //X轴齿隙游移，反向
        public float y_blacklash;  
        public float z_blacklash;
        public float a_blacklash;
        public float b_blacklash;

        public double sublevel;           
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string mainfile_name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	    public string  subfile_name;

	    public int auto_error_ret_code;
	    public char auto_motion_name;
	    public int no_auto_error_ret_code;
	    public int plc_error_ret_code;
	    public int plc_array_index;
    };
    public class GjApi
   {
        //连接接口
       [DllImport("NCConnectDll330.dll", EntryPoint = "connectToNC330",CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 connectToNC330(ref Int32 iNCIndex, char[] IPAddr, UInt16 Port);
       [DllImport("NCConnectDll330.dll", EntryPoint = "disconnectToNC330", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 disconnectToNC330(Int32 iNCIndex);
        //send cmd to nc
       [DllImport("NCConnectDll330.dll", EntryPoint = "sendCmdToNC330", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 sendCmdToNC330(Int32 iNCIndex, Int32 iCmdType, Char[] strCmdComment);
       //状态数据，IO status，string status，double status
       [DllImport("NCConnectDll330.dll", EntryPoint = "getIOStatusVal330", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 getIOStatusVal330(int iNCIndex, int iIOIndex);
       [DllImport("NCConnectDll330.dll", EntryPoint = "getStatusStrVal330", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 getStatusStrVal330(int iNCIndex, int index, Char[] retString);
       [DllImport("NCConnectDll330.dll", EntryPoint = "getStatusVal330", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 getStatusVal330(int iNCIndex, int index, ref double retValue);
       //轴数据
       [DllImport("NCConnectDll330.dll", EntryPoint = "getStatusAxisVal330", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 getStatusAxisVal330(int iNCIndex, int index, ref double retAxisValue);
       ////time数据？
       //[DllImport("NCConnectDll330.dll", EntryPoint = "get330StatusTimeVal", CallingConvention = CallingConvention.Cdecl)]
       //public static extern Int32 get330StatusTimeVal(int iNCIndex, int index, time_t* retTimeValue);
       //坐标系数据
       [DllImport("NCConnectDll330.dll", EntryPoint = "getStatusCoordVal330", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 getStatusCoordVal330(int iNCIndex, int index, IntPtr retCoordValue); //point to Cncpose
        //获得版本，型号数据
       [DllImport("NCConnectDll330.dll", EntryPoint = "getStatusStaticVal330", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 getStatusStaticVal330(int iNCIndex, int index, String retString);
       //报警 error
       [DllImport("NCConnectDll330.dll", EntryPoint = "getErrorVal330", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 getErrorVal330(int iNCIndex, char[] retString);
       [DllImport("NCConnectDll330.dll", EntryPoint = "getAutoMotionErrorVal330", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 getAutoMotionErrorVal330(int iNCIndex, char[] retString);
       [DllImport("NCConnectDll330.dll", EntryPoint = "getAutoPlcErrorVal330", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 getAutoPlcErrorVal330(int iNCIndex, char[] retString);
        //文件
       [DllImport("NCConnectDll330.dll", EntryPoint = "downloadFileFromServer330", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 downloadFileFromServer330(char[] localPathPtr, char[] fileNamePtr, char[] ipAddrPtr, int server_port = 6666, int iFileType = 0);
       [DllImport("NCConnectDll330.dll", EntryPoint = "uploadFileToServer330", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 uploadFileToServer330(char[] localPathPtr, char[] fileNamePtr, char[] ipAddrPtr, int server_port = 6666, int iFileType = 0);

        //获得数据集合
       [DllImport("NCConnectDll330.dll", EntryPoint = "get_mach330_info", CallingConvention = CallingConvention.StdCall)]
       public static extern Int32 get_mach330_info(int iNCIndex, ref CNCINFO machinfo);

   }
}
 