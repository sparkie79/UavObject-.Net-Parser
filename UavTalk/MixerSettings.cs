// Object ID: 485485170
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class MixerSettings : UAVDataObject
	{
		public const long OBJID = 485485170;
		public int NUMBYTES { get; set; }
		protected const String NAME = "MixerSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref ActuatorModule that controls the channel assignments for the mixer based on AircraftType";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> MaxAccel;
		public UAVObjectField<float> FeedForward;
		public UAVObjectField<float> AccelTime;
		public UAVObjectField<float> DecelTime;
		public UAVObjectField<float> ThrottleCurve1;
		public UAVObjectField<float> ThrottleCurve2;
		public enum Curve2SourceUavEnum
		{
			[Description("Throttle")]
			Throttle = 0, 
			[Description("Roll")]
			Roll = 1, 
			[Description("Pitch")]
			Pitch = 2, 
			[Description("Yaw")]
			Yaw = 3, 
			[Description("Collective")]
			Collective = 4, 
			[Description("Accessory0")]
			Accessory0 = 5, 
			[Description("Accessory1")]
			Accessory1 = 6, 
			[Description("Accessory2")]
			Accessory2 = 7, 
			[Description("Accessory3")]
			Accessory3 = 8, 
			[Description("Accessory4")]
			Accessory4 = 9, 
			[Description("Accessory5")]
			Accessory5 = 10, 
		}
		public UAVObjectField<Curve2SourceUavEnum> Curve2Source;
		public enum Mixer1TypeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Motor")]
			Motor = 1, 
			[Description("Servo")]
			Servo = 2, 
			[Description("CameraRollOrServo1")]
			CameraRollOrServo1 = 3, 
			[Description("CameraPitchOrServo2")]
			CameraPitchOrServo2 = 4, 
			[Description("CameraYaw")]
			CameraYaw = 5, 
			[Description("Accessory0")]
			Accessory0 = 6, 
			[Description("Accessory1")]
			Accessory1 = 7, 
			[Description("Accessory2")]
			Accessory2 = 8, 
			[Description("Accessory3")]
			Accessory3 = 9, 
			[Description("Accessory4")]
			Accessory4 = 10, 
			[Description("Accessory5")]
			Accessory5 = 11, 
		}
		public UAVObjectField<Mixer1TypeUavEnum> Mixer1Type;
		public UAVObjectField<sbyte> Mixer1Vector;
		public enum Mixer2TypeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Motor")]
			Motor = 1, 
			[Description("Servo")]
			Servo = 2, 
			[Description("CameraRollOrServo1")]
			CameraRollOrServo1 = 3, 
			[Description("CameraPitchOrServo2")]
			CameraPitchOrServo2 = 4, 
			[Description("CameraYaw")]
			CameraYaw = 5, 
			[Description("Accessory0")]
			Accessory0 = 6, 
			[Description("Accessory1")]
			Accessory1 = 7, 
			[Description("Accessory2")]
			Accessory2 = 8, 
			[Description("Accessory3")]
			Accessory3 = 9, 
			[Description("Accessory4")]
			Accessory4 = 10, 
			[Description("Accessory5")]
			Accessory5 = 11, 
		}
		public UAVObjectField<Mixer2TypeUavEnum> Mixer2Type;
		public UAVObjectField<sbyte> Mixer2Vector;
		public enum Mixer3TypeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Motor")]
			Motor = 1, 
			[Description("Servo")]
			Servo = 2, 
			[Description("CameraRollOrServo1")]
			CameraRollOrServo1 = 3, 
			[Description("CameraPitchOrServo2")]
			CameraPitchOrServo2 = 4, 
			[Description("CameraYaw")]
			CameraYaw = 5, 
			[Description("Accessory0")]
			Accessory0 = 6, 
			[Description("Accessory1")]
			Accessory1 = 7, 
			[Description("Accessory2")]
			Accessory2 = 8, 
			[Description("Accessory3")]
			Accessory3 = 9, 
			[Description("Accessory4")]
			Accessory4 = 10, 
			[Description("Accessory5")]
			Accessory5 = 11, 
		}
		public UAVObjectField<Mixer3TypeUavEnum> Mixer3Type;
		public UAVObjectField<sbyte> Mixer3Vector;
		public enum Mixer4TypeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Motor")]
			Motor = 1, 
			[Description("Servo")]
			Servo = 2, 
			[Description("CameraRollOrServo1")]
			CameraRollOrServo1 = 3, 
			[Description("CameraPitchOrServo2")]
			CameraPitchOrServo2 = 4, 
			[Description("CameraYaw")]
			CameraYaw = 5, 
			[Description("Accessory0")]
			Accessory0 = 6, 
			[Description("Accessory1")]
			Accessory1 = 7, 
			[Description("Accessory2")]
			Accessory2 = 8, 
			[Description("Accessory3")]
			Accessory3 = 9, 
			[Description("Accessory4")]
			Accessory4 = 10, 
			[Description("Accessory5")]
			Accessory5 = 11, 
		}
		public UAVObjectField<Mixer4TypeUavEnum> Mixer4Type;
		public UAVObjectField<sbyte> Mixer4Vector;
		public enum Mixer5TypeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Motor")]
			Motor = 1, 
			[Description("Servo")]
			Servo = 2, 
			[Description("CameraRollOrServo1")]
			CameraRollOrServo1 = 3, 
			[Description("CameraPitchOrServo2")]
			CameraPitchOrServo2 = 4, 
			[Description("CameraYaw")]
			CameraYaw = 5, 
			[Description("Accessory0")]
			Accessory0 = 6, 
			[Description("Accessory1")]
			Accessory1 = 7, 
			[Description("Accessory2")]
			Accessory2 = 8, 
			[Description("Accessory3")]
			Accessory3 = 9, 
			[Description("Accessory4")]
			Accessory4 = 10, 
			[Description("Accessory5")]
			Accessory5 = 11, 
		}
		public UAVObjectField<Mixer5TypeUavEnum> Mixer5Type;
		public UAVObjectField<sbyte> Mixer5Vector;
		public enum Mixer6TypeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Motor")]
			Motor = 1, 
			[Description("Servo")]
			Servo = 2, 
			[Description("CameraRollOrServo1")]
			CameraRollOrServo1 = 3, 
			[Description("CameraPitchOrServo2")]
			CameraPitchOrServo2 = 4, 
			[Description("CameraYaw")]
			CameraYaw = 5, 
			[Description("Accessory0")]
			Accessory0 = 6, 
			[Description("Accessory1")]
			Accessory1 = 7, 
			[Description("Accessory2")]
			Accessory2 = 8, 
			[Description("Accessory3")]
			Accessory3 = 9, 
			[Description("Accessory4")]
			Accessory4 = 10, 
			[Description("Accessory5")]
			Accessory5 = 11, 
		}
		public UAVObjectField<Mixer6TypeUavEnum> Mixer6Type;
		public UAVObjectField<sbyte> Mixer6Vector;
		public enum Mixer7TypeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Motor")]
			Motor = 1, 
			[Description("Servo")]
			Servo = 2, 
			[Description("CameraRollOrServo1")]
			CameraRollOrServo1 = 3, 
			[Description("CameraPitchOrServo2")]
			CameraPitchOrServo2 = 4, 
			[Description("CameraYaw")]
			CameraYaw = 5, 
			[Description("Accessory0")]
			Accessory0 = 6, 
			[Description("Accessory1")]
			Accessory1 = 7, 
			[Description("Accessory2")]
			Accessory2 = 8, 
			[Description("Accessory3")]
			Accessory3 = 9, 
			[Description("Accessory4")]
			Accessory4 = 10, 
			[Description("Accessory5")]
			Accessory5 = 11, 
		}
		public UAVObjectField<Mixer7TypeUavEnum> Mixer7Type;
		public UAVObjectField<sbyte> Mixer7Vector;
		public enum Mixer8TypeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Motor")]
			Motor = 1, 
			[Description("Servo")]
			Servo = 2, 
			[Description("CameraRollOrServo1")]
			CameraRollOrServo1 = 3, 
			[Description("CameraPitchOrServo2")]
			CameraPitchOrServo2 = 4, 
			[Description("CameraYaw")]
			CameraYaw = 5, 
			[Description("Accessory0")]
			Accessory0 = 6, 
			[Description("Accessory1")]
			Accessory1 = 7, 
			[Description("Accessory2")]
			Accessory2 = 8, 
			[Description("Accessory3")]
			Accessory3 = 9, 
			[Description("Accessory4")]
			Accessory4 = 10, 
			[Description("Accessory5")]
			Accessory5 = 11, 
		}
		public UAVObjectField<Mixer8TypeUavEnum> Mixer8Type;
		public UAVObjectField<sbyte> Mixer8Vector;
		public enum Mixer9TypeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Motor")]
			Motor = 1, 
			[Description("Servo")]
			Servo = 2, 
			[Description("CameraRollOrServo1")]
			CameraRollOrServo1 = 3, 
			[Description("CameraPitchOrServo2")]
			CameraPitchOrServo2 = 4, 
			[Description("CameraYaw")]
			CameraYaw = 5, 
			[Description("Accessory0")]
			Accessory0 = 6, 
			[Description("Accessory1")]
			Accessory1 = 7, 
			[Description("Accessory2")]
			Accessory2 = 8, 
			[Description("Accessory3")]
			Accessory3 = 9, 
			[Description("Accessory4")]
			Accessory4 = 10, 
			[Description("Accessory5")]
			Accessory5 = 11, 
		}
		public UAVObjectField<Mixer9TypeUavEnum> Mixer9Type;
		public UAVObjectField<sbyte> Mixer9Vector;
		public enum Mixer10TypeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Motor")]
			Motor = 1, 
			[Description("Servo")]
			Servo = 2, 
			[Description("CameraRollOrServo1")]
			CameraRollOrServo1 = 3, 
			[Description("CameraPitchOrServo2")]
			CameraPitchOrServo2 = 4, 
			[Description("CameraYaw")]
			CameraYaw = 5, 
			[Description("Accessory0")]
			Accessory0 = 6, 
			[Description("Accessory1")]
			Accessory1 = 7, 
			[Description("Accessory2")]
			Accessory2 = 8, 
			[Description("Accessory3")]
			Accessory3 = 9, 
			[Description("Accessory4")]
			Accessory4 = 10, 
			[Description("Accessory5")]
			Accessory5 = 11, 
		}
		public UAVObjectField<Mixer10TypeUavEnum> Mixer10Type;
		public UAVObjectField<sbyte> Mixer10Vector;
		public enum Mixer11TypeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Motor")]
			Motor = 1, 
			[Description("Servo")]
			Servo = 2, 
			[Description("CameraRollOrServo1")]
			CameraRollOrServo1 = 3, 
			[Description("CameraPitchOrServo2")]
			CameraPitchOrServo2 = 4, 
			[Description("CameraYaw")]
			CameraYaw = 5, 
			[Description("Accessory0")]
			Accessory0 = 6, 
			[Description("Accessory1")]
			Accessory1 = 7, 
			[Description("Accessory2")]
			Accessory2 = 8, 
			[Description("Accessory3")]
			Accessory3 = 9, 
			[Description("Accessory4")]
			Accessory4 = 10, 
			[Description("Accessory5")]
			Accessory5 = 11, 
		}
		public UAVObjectField<Mixer11TypeUavEnum> Mixer11Type;
		public UAVObjectField<sbyte> Mixer11Vector;
		public enum Mixer12TypeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Motor")]
			Motor = 1, 
			[Description("Servo")]
			Servo = 2, 
			[Description("CameraRollOrServo1")]
			CameraRollOrServo1 = 3, 
			[Description("CameraPitchOrServo2")]
			CameraPitchOrServo2 = 4, 
			[Description("CameraYaw")]
			CameraYaw = 5, 
			[Description("Accessory0")]
			Accessory0 = 6, 
			[Description("Accessory1")]
			Accessory1 = 7, 
			[Description("Accessory2")]
			Accessory2 = 8, 
			[Description("Accessory3")]
			Accessory3 = 9, 
			[Description("Accessory4")]
			Accessory4 = 10, 
			[Description("Accessory5")]
			Accessory5 = 11, 
		}
		public UAVObjectField<Mixer12TypeUavEnum> Mixer12Type;
		public UAVObjectField<sbyte> Mixer12Vector;

		public MixerSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> MaxAccelElemNames = new List<String>();
			MaxAccelElemNames.Add("0");
			MaxAccel=new UAVObjectField<float>("MaxAccel", "units/sec", MaxAccelElemNames, null, this);
			fields.Add(MaxAccel);

			List<String> FeedForwardElemNames = new List<String>();
			FeedForwardElemNames.Add("0");
			FeedForward=new UAVObjectField<float>("FeedForward", "", FeedForwardElemNames, null, this);
			fields.Add(FeedForward);

			List<String> AccelTimeElemNames = new List<String>();
			AccelTimeElemNames.Add("0");
			AccelTime=new UAVObjectField<float>("AccelTime", "ms", AccelTimeElemNames, null, this);
			fields.Add(AccelTime);

			List<String> DecelTimeElemNames = new List<String>();
			DecelTimeElemNames.Add("0");
			DecelTime=new UAVObjectField<float>("DecelTime", "ms", DecelTimeElemNames, null, this);
			fields.Add(DecelTime);

			List<String> ThrottleCurve1ElemNames = new List<String>();
			ThrottleCurve1ElemNames.Add("0");
			ThrottleCurve1ElemNames.Add("25");
			ThrottleCurve1ElemNames.Add("50");
			ThrottleCurve1ElemNames.Add("75");
			ThrottleCurve1ElemNames.Add("100");
			ThrottleCurve1=new UAVObjectField<float>("ThrottleCurve1", "percent", ThrottleCurve1ElemNames, null, this);
			fields.Add(ThrottleCurve1);

			List<String> ThrottleCurve2ElemNames = new List<String>();
			ThrottleCurve2ElemNames.Add("0");
			ThrottleCurve2ElemNames.Add("25");
			ThrottleCurve2ElemNames.Add("50");
			ThrottleCurve2ElemNames.Add("75");
			ThrottleCurve2ElemNames.Add("100");
			ThrottleCurve2=new UAVObjectField<float>("ThrottleCurve2", "percent", ThrottleCurve2ElemNames, null, this);
			fields.Add(ThrottleCurve2);

			List<String> Curve2SourceElemNames = new List<String>();
			Curve2SourceElemNames.Add("0");
			List<String> Curve2SourceEnumOptions = new List<String>();
			Curve2SourceEnumOptions.Add("Throttle");
			Curve2SourceEnumOptions.Add("Roll");
			Curve2SourceEnumOptions.Add("Pitch");
			Curve2SourceEnumOptions.Add("Yaw");
			Curve2SourceEnumOptions.Add("Collective");
			Curve2SourceEnumOptions.Add("Accessory0");
			Curve2SourceEnumOptions.Add("Accessory1");
			Curve2SourceEnumOptions.Add("Accessory2");
			Curve2SourceEnumOptions.Add("Accessory3");
			Curve2SourceEnumOptions.Add("Accessory4");
			Curve2SourceEnumOptions.Add("Accessory5");
			Curve2Source=new UAVObjectField<Curve2SourceUavEnum>("Curve2Source", "", Curve2SourceElemNames, Curve2SourceEnumOptions, this);
			fields.Add(Curve2Source);

			List<String> Mixer1TypeElemNames = new List<String>();
			Mixer1TypeElemNames.Add("0");
			List<String> Mixer1TypeEnumOptions = new List<String>();
			Mixer1TypeEnumOptions.Add("Disabled");
			Mixer1TypeEnumOptions.Add("Motor");
			Mixer1TypeEnumOptions.Add("Servo");
			Mixer1TypeEnumOptions.Add("CameraRollOrServo1");
			Mixer1TypeEnumOptions.Add("CameraPitchOrServo2");
			Mixer1TypeEnumOptions.Add("CameraYaw");
			Mixer1TypeEnumOptions.Add("Accessory0");
			Mixer1TypeEnumOptions.Add("Accessory1");
			Mixer1TypeEnumOptions.Add("Accessory2");
			Mixer1TypeEnumOptions.Add("Accessory3");
			Mixer1TypeEnumOptions.Add("Accessory4");
			Mixer1TypeEnumOptions.Add("Accessory5");
			Mixer1Type=new UAVObjectField<Mixer1TypeUavEnum>("Mixer1Type", "", Mixer1TypeElemNames, Mixer1TypeEnumOptions, this);
			fields.Add(Mixer1Type);

			List<String> Mixer1VectorElemNames = new List<String>();
			Mixer1VectorElemNames.Add("ThrottleCurve1");
			Mixer1VectorElemNames.Add("ThrottleCurve2");
			Mixer1VectorElemNames.Add("Roll");
			Mixer1VectorElemNames.Add("Pitch");
			Mixer1VectorElemNames.Add("Yaw");
			Mixer1Vector=new UAVObjectField<sbyte>("Mixer1Vector", "", Mixer1VectorElemNames, null, this);
			fields.Add(Mixer1Vector);

			List<String> Mixer2TypeElemNames = new List<String>();
			Mixer2TypeElemNames.Add("0");
			List<String> Mixer2TypeEnumOptions = new List<String>();
			Mixer2TypeEnumOptions.Add("Disabled");
			Mixer2TypeEnumOptions.Add("Motor");
			Mixer2TypeEnumOptions.Add("Servo");
			Mixer2TypeEnumOptions.Add("CameraRollOrServo1");
			Mixer2TypeEnumOptions.Add("CameraPitchOrServo2");
			Mixer2TypeEnumOptions.Add("CameraYaw");
			Mixer2TypeEnumOptions.Add("Accessory0");
			Mixer2TypeEnumOptions.Add("Accessory1");
			Mixer2TypeEnumOptions.Add("Accessory2");
			Mixer2TypeEnumOptions.Add("Accessory3");
			Mixer2TypeEnumOptions.Add("Accessory4");
			Mixer2TypeEnumOptions.Add("Accessory5");
			Mixer2Type=new UAVObjectField<Mixer2TypeUavEnum>("Mixer2Type", "", Mixer2TypeElemNames, Mixer2TypeEnumOptions, this);
			fields.Add(Mixer2Type);

			List<String> Mixer2VectorElemNames = new List<String>();
			Mixer2VectorElemNames.Add("ThrottleCurve1");
			Mixer2VectorElemNames.Add("ThrottleCurve2");
			Mixer2VectorElemNames.Add("Roll");
			Mixer2VectorElemNames.Add("Pitch");
			Mixer2VectorElemNames.Add("Yaw");
			Mixer2Vector=new UAVObjectField<sbyte>("Mixer2Vector", "", Mixer2VectorElemNames, null, this);
			fields.Add(Mixer2Vector);

			List<String> Mixer3TypeElemNames = new List<String>();
			Mixer3TypeElemNames.Add("0");
			List<String> Mixer3TypeEnumOptions = new List<String>();
			Mixer3TypeEnumOptions.Add("Disabled");
			Mixer3TypeEnumOptions.Add("Motor");
			Mixer3TypeEnumOptions.Add("Servo");
			Mixer3TypeEnumOptions.Add("CameraRollOrServo1");
			Mixer3TypeEnumOptions.Add("CameraPitchOrServo2");
			Mixer3TypeEnumOptions.Add("CameraYaw");
			Mixer3TypeEnumOptions.Add("Accessory0");
			Mixer3TypeEnumOptions.Add("Accessory1");
			Mixer3TypeEnumOptions.Add("Accessory2");
			Mixer3TypeEnumOptions.Add("Accessory3");
			Mixer3TypeEnumOptions.Add("Accessory4");
			Mixer3TypeEnumOptions.Add("Accessory5");
			Mixer3Type=new UAVObjectField<Mixer3TypeUavEnum>("Mixer3Type", "", Mixer3TypeElemNames, Mixer3TypeEnumOptions, this);
			fields.Add(Mixer3Type);

			List<String> Mixer3VectorElemNames = new List<String>();
			Mixer3VectorElemNames.Add("ThrottleCurve1");
			Mixer3VectorElemNames.Add("ThrottleCurve2");
			Mixer3VectorElemNames.Add("Roll");
			Mixer3VectorElemNames.Add("Pitch");
			Mixer3VectorElemNames.Add("Yaw");
			Mixer3Vector=new UAVObjectField<sbyte>("Mixer3Vector", "", Mixer3VectorElemNames, null, this);
			fields.Add(Mixer3Vector);

			List<String> Mixer4TypeElemNames = new List<String>();
			Mixer4TypeElemNames.Add("0");
			List<String> Mixer4TypeEnumOptions = new List<String>();
			Mixer4TypeEnumOptions.Add("Disabled");
			Mixer4TypeEnumOptions.Add("Motor");
			Mixer4TypeEnumOptions.Add("Servo");
			Mixer4TypeEnumOptions.Add("CameraRollOrServo1");
			Mixer4TypeEnumOptions.Add("CameraPitchOrServo2");
			Mixer4TypeEnumOptions.Add("CameraYaw");
			Mixer4TypeEnumOptions.Add("Accessory0");
			Mixer4TypeEnumOptions.Add("Accessory1");
			Mixer4TypeEnumOptions.Add("Accessory2");
			Mixer4TypeEnumOptions.Add("Accessory3");
			Mixer4TypeEnumOptions.Add("Accessory4");
			Mixer4TypeEnumOptions.Add("Accessory5");
			Mixer4Type=new UAVObjectField<Mixer4TypeUavEnum>("Mixer4Type", "", Mixer4TypeElemNames, Mixer4TypeEnumOptions, this);
			fields.Add(Mixer4Type);

			List<String> Mixer4VectorElemNames = new List<String>();
			Mixer4VectorElemNames.Add("ThrottleCurve1");
			Mixer4VectorElemNames.Add("ThrottleCurve2");
			Mixer4VectorElemNames.Add("Roll");
			Mixer4VectorElemNames.Add("Pitch");
			Mixer4VectorElemNames.Add("Yaw");
			Mixer4Vector=new UAVObjectField<sbyte>("Mixer4Vector", "", Mixer4VectorElemNames, null, this);
			fields.Add(Mixer4Vector);

			List<String> Mixer5TypeElemNames = new List<String>();
			Mixer5TypeElemNames.Add("0");
			List<String> Mixer5TypeEnumOptions = new List<String>();
			Mixer5TypeEnumOptions.Add("Disabled");
			Mixer5TypeEnumOptions.Add("Motor");
			Mixer5TypeEnumOptions.Add("Servo");
			Mixer5TypeEnumOptions.Add("CameraRollOrServo1");
			Mixer5TypeEnumOptions.Add("CameraPitchOrServo2");
			Mixer5TypeEnumOptions.Add("CameraYaw");
			Mixer5TypeEnumOptions.Add("Accessory0");
			Mixer5TypeEnumOptions.Add("Accessory1");
			Mixer5TypeEnumOptions.Add("Accessory2");
			Mixer5TypeEnumOptions.Add("Accessory3");
			Mixer5TypeEnumOptions.Add("Accessory4");
			Mixer5TypeEnumOptions.Add("Accessory5");
			Mixer5Type=new UAVObjectField<Mixer5TypeUavEnum>("Mixer5Type", "", Mixer5TypeElemNames, Mixer5TypeEnumOptions, this);
			fields.Add(Mixer5Type);

			List<String> Mixer5VectorElemNames = new List<String>();
			Mixer5VectorElemNames.Add("ThrottleCurve1");
			Mixer5VectorElemNames.Add("ThrottleCurve2");
			Mixer5VectorElemNames.Add("Roll");
			Mixer5VectorElemNames.Add("Pitch");
			Mixer5VectorElemNames.Add("Yaw");
			Mixer5Vector=new UAVObjectField<sbyte>("Mixer5Vector", "", Mixer5VectorElemNames, null, this);
			fields.Add(Mixer5Vector);

			List<String> Mixer6TypeElemNames = new List<String>();
			Mixer6TypeElemNames.Add("0");
			List<String> Mixer6TypeEnumOptions = new List<String>();
			Mixer6TypeEnumOptions.Add("Disabled");
			Mixer6TypeEnumOptions.Add("Motor");
			Mixer6TypeEnumOptions.Add("Servo");
			Mixer6TypeEnumOptions.Add("CameraRollOrServo1");
			Mixer6TypeEnumOptions.Add("CameraPitchOrServo2");
			Mixer6TypeEnumOptions.Add("CameraYaw");
			Mixer6TypeEnumOptions.Add("Accessory0");
			Mixer6TypeEnumOptions.Add("Accessory1");
			Mixer6TypeEnumOptions.Add("Accessory2");
			Mixer6TypeEnumOptions.Add("Accessory3");
			Mixer6TypeEnumOptions.Add("Accessory4");
			Mixer6TypeEnumOptions.Add("Accessory5");
			Mixer6Type=new UAVObjectField<Mixer6TypeUavEnum>("Mixer6Type", "", Mixer6TypeElemNames, Mixer6TypeEnumOptions, this);
			fields.Add(Mixer6Type);

			List<String> Mixer6VectorElemNames = new List<String>();
			Mixer6VectorElemNames.Add("ThrottleCurve1");
			Mixer6VectorElemNames.Add("ThrottleCurve2");
			Mixer6VectorElemNames.Add("Roll");
			Mixer6VectorElemNames.Add("Pitch");
			Mixer6VectorElemNames.Add("Yaw");
			Mixer6Vector=new UAVObjectField<sbyte>("Mixer6Vector", "", Mixer6VectorElemNames, null, this);
			fields.Add(Mixer6Vector);

			List<String> Mixer7TypeElemNames = new List<String>();
			Mixer7TypeElemNames.Add("0");
			List<String> Mixer7TypeEnumOptions = new List<String>();
			Mixer7TypeEnumOptions.Add("Disabled");
			Mixer7TypeEnumOptions.Add("Motor");
			Mixer7TypeEnumOptions.Add("Servo");
			Mixer7TypeEnumOptions.Add("CameraRollOrServo1");
			Mixer7TypeEnumOptions.Add("CameraPitchOrServo2");
			Mixer7TypeEnumOptions.Add("CameraYaw");
			Mixer7TypeEnumOptions.Add("Accessory0");
			Mixer7TypeEnumOptions.Add("Accessory1");
			Mixer7TypeEnumOptions.Add("Accessory2");
			Mixer7TypeEnumOptions.Add("Accessory3");
			Mixer7TypeEnumOptions.Add("Accessory4");
			Mixer7TypeEnumOptions.Add("Accessory5");
			Mixer7Type=new UAVObjectField<Mixer7TypeUavEnum>("Mixer7Type", "", Mixer7TypeElemNames, Mixer7TypeEnumOptions, this);
			fields.Add(Mixer7Type);

			List<String> Mixer7VectorElemNames = new List<String>();
			Mixer7VectorElemNames.Add("ThrottleCurve1");
			Mixer7VectorElemNames.Add("ThrottleCurve2");
			Mixer7VectorElemNames.Add("Roll");
			Mixer7VectorElemNames.Add("Pitch");
			Mixer7VectorElemNames.Add("Yaw");
			Mixer7Vector=new UAVObjectField<sbyte>("Mixer7Vector", "", Mixer7VectorElemNames, null, this);
			fields.Add(Mixer7Vector);

			List<String> Mixer8TypeElemNames = new List<String>();
			Mixer8TypeElemNames.Add("0");
			List<String> Mixer8TypeEnumOptions = new List<String>();
			Mixer8TypeEnumOptions.Add("Disabled");
			Mixer8TypeEnumOptions.Add("Motor");
			Mixer8TypeEnumOptions.Add("Servo");
			Mixer8TypeEnumOptions.Add("CameraRollOrServo1");
			Mixer8TypeEnumOptions.Add("CameraPitchOrServo2");
			Mixer8TypeEnumOptions.Add("CameraYaw");
			Mixer8TypeEnumOptions.Add("Accessory0");
			Mixer8TypeEnumOptions.Add("Accessory1");
			Mixer8TypeEnumOptions.Add("Accessory2");
			Mixer8TypeEnumOptions.Add("Accessory3");
			Mixer8TypeEnumOptions.Add("Accessory4");
			Mixer8TypeEnumOptions.Add("Accessory5");
			Mixer8Type=new UAVObjectField<Mixer8TypeUavEnum>("Mixer8Type", "", Mixer8TypeElemNames, Mixer8TypeEnumOptions, this);
			fields.Add(Mixer8Type);

			List<String> Mixer8VectorElemNames = new List<String>();
			Mixer8VectorElemNames.Add("ThrottleCurve1");
			Mixer8VectorElemNames.Add("ThrottleCurve2");
			Mixer8VectorElemNames.Add("Roll");
			Mixer8VectorElemNames.Add("Pitch");
			Mixer8VectorElemNames.Add("Yaw");
			Mixer8Vector=new UAVObjectField<sbyte>("Mixer8Vector", "", Mixer8VectorElemNames, null, this);
			fields.Add(Mixer8Vector);

			List<String> Mixer9TypeElemNames = new List<String>();
			Mixer9TypeElemNames.Add("0");
			List<String> Mixer9TypeEnumOptions = new List<String>();
			Mixer9TypeEnumOptions.Add("Disabled");
			Mixer9TypeEnumOptions.Add("Motor");
			Mixer9TypeEnumOptions.Add("Servo");
			Mixer9TypeEnumOptions.Add("CameraRollOrServo1");
			Mixer9TypeEnumOptions.Add("CameraPitchOrServo2");
			Mixer9TypeEnumOptions.Add("CameraYaw");
			Mixer9TypeEnumOptions.Add("Accessory0");
			Mixer9TypeEnumOptions.Add("Accessory1");
			Mixer9TypeEnumOptions.Add("Accessory2");
			Mixer9TypeEnumOptions.Add("Accessory3");
			Mixer9TypeEnumOptions.Add("Accessory4");
			Mixer9TypeEnumOptions.Add("Accessory5");
			Mixer9Type=new UAVObjectField<Mixer9TypeUavEnum>("Mixer9Type", "", Mixer9TypeElemNames, Mixer9TypeEnumOptions, this);
			fields.Add(Mixer9Type);

			List<String> Mixer9VectorElemNames = new List<String>();
			Mixer9VectorElemNames.Add("ThrottleCurve1");
			Mixer9VectorElemNames.Add("ThrottleCurve2");
			Mixer9VectorElemNames.Add("Roll");
			Mixer9VectorElemNames.Add("Pitch");
			Mixer9VectorElemNames.Add("Yaw");
			Mixer9Vector=new UAVObjectField<sbyte>("Mixer9Vector", "", Mixer9VectorElemNames, null, this);
			fields.Add(Mixer9Vector);

			List<String> Mixer10TypeElemNames = new List<String>();
			Mixer10TypeElemNames.Add("0");
			List<String> Mixer10TypeEnumOptions = new List<String>();
			Mixer10TypeEnumOptions.Add("Disabled");
			Mixer10TypeEnumOptions.Add("Motor");
			Mixer10TypeEnumOptions.Add("Servo");
			Mixer10TypeEnumOptions.Add("CameraRollOrServo1");
			Mixer10TypeEnumOptions.Add("CameraPitchOrServo2");
			Mixer10TypeEnumOptions.Add("CameraYaw");
			Mixer10TypeEnumOptions.Add("Accessory0");
			Mixer10TypeEnumOptions.Add("Accessory1");
			Mixer10TypeEnumOptions.Add("Accessory2");
			Mixer10TypeEnumOptions.Add("Accessory3");
			Mixer10TypeEnumOptions.Add("Accessory4");
			Mixer10TypeEnumOptions.Add("Accessory5");
			Mixer10Type=new UAVObjectField<Mixer10TypeUavEnum>("Mixer10Type", "", Mixer10TypeElemNames, Mixer10TypeEnumOptions, this);
			fields.Add(Mixer10Type);

			List<String> Mixer10VectorElemNames = new List<String>();
			Mixer10VectorElemNames.Add("ThrottleCurve1");
			Mixer10VectorElemNames.Add("ThrottleCurve2");
			Mixer10VectorElemNames.Add("Roll");
			Mixer10VectorElemNames.Add("Pitch");
			Mixer10VectorElemNames.Add("Yaw");
			Mixer10Vector=new UAVObjectField<sbyte>("Mixer10Vector", "", Mixer10VectorElemNames, null, this);
			fields.Add(Mixer10Vector);

			List<String> Mixer11TypeElemNames = new List<String>();
			Mixer11TypeElemNames.Add("0");
			List<String> Mixer11TypeEnumOptions = new List<String>();
			Mixer11TypeEnumOptions.Add("Disabled");
			Mixer11TypeEnumOptions.Add("Motor");
			Mixer11TypeEnumOptions.Add("Servo");
			Mixer11TypeEnumOptions.Add("CameraRollOrServo1");
			Mixer11TypeEnumOptions.Add("CameraPitchOrServo2");
			Mixer11TypeEnumOptions.Add("CameraYaw");
			Mixer11TypeEnumOptions.Add("Accessory0");
			Mixer11TypeEnumOptions.Add("Accessory1");
			Mixer11TypeEnumOptions.Add("Accessory2");
			Mixer11TypeEnumOptions.Add("Accessory3");
			Mixer11TypeEnumOptions.Add("Accessory4");
			Mixer11TypeEnumOptions.Add("Accessory5");
			Mixer11Type=new UAVObjectField<Mixer11TypeUavEnum>("Mixer11Type", "", Mixer11TypeElemNames, Mixer11TypeEnumOptions, this);
			fields.Add(Mixer11Type);

			List<String> Mixer11VectorElemNames = new List<String>();
			Mixer11VectorElemNames.Add("ThrottleCurve1");
			Mixer11VectorElemNames.Add("ThrottleCurve2");
			Mixer11VectorElemNames.Add("Roll");
			Mixer11VectorElemNames.Add("Pitch");
			Mixer11VectorElemNames.Add("Yaw");
			Mixer11Vector=new UAVObjectField<sbyte>("Mixer11Vector", "", Mixer11VectorElemNames, null, this);
			fields.Add(Mixer11Vector);

			List<String> Mixer12TypeElemNames = new List<String>();
			Mixer12TypeElemNames.Add("0");
			List<String> Mixer12TypeEnumOptions = new List<String>();
			Mixer12TypeEnumOptions.Add("Disabled");
			Mixer12TypeEnumOptions.Add("Motor");
			Mixer12TypeEnumOptions.Add("Servo");
			Mixer12TypeEnumOptions.Add("CameraRollOrServo1");
			Mixer12TypeEnumOptions.Add("CameraPitchOrServo2");
			Mixer12TypeEnumOptions.Add("CameraYaw");
			Mixer12TypeEnumOptions.Add("Accessory0");
			Mixer12TypeEnumOptions.Add("Accessory1");
			Mixer12TypeEnumOptions.Add("Accessory2");
			Mixer12TypeEnumOptions.Add("Accessory3");
			Mixer12TypeEnumOptions.Add("Accessory4");
			Mixer12TypeEnumOptions.Add("Accessory5");
			Mixer12Type=new UAVObjectField<Mixer12TypeUavEnum>("Mixer12Type", "", Mixer12TypeElemNames, Mixer12TypeEnumOptions, this);
			fields.Add(Mixer12Type);

			List<String> Mixer12VectorElemNames = new List<String>();
			Mixer12VectorElemNames.Add("ThrottleCurve1");
			Mixer12VectorElemNames.Add("ThrottleCurve2");
			Mixer12VectorElemNames.Add("Roll");
			Mixer12VectorElemNames.Add("Pitch");
			Mixer12VectorElemNames.Add("Yaw");
			Mixer12Vector=new UAVObjectField<sbyte>("Mixer12Vector", "", Mixer12VectorElemNames, null, this);
			fields.Add(Mixer12Vector);

	

			// Compute the number of bytes for this object
            NUMBYTES = fields.Sum(j => j.getNumBytes());
			
			// Initialize object
			initializeFields(fields, new ByteBuffer(NUMBYTES), NUMBYTES);
			// Set the default field values
			setDefaultFieldValues();
			// Set the object description
			setDescription(DESCRIPTION);
		}

		/**
		 * Create a Metadata object filled with default values for this object
		 * @return Metadata object with default values
		 */
		public override Metadata getDefaultMetadata() {
			Metadata metadata = new Metadata();
    		metadata.flags =
				(int)AccessMode.ACCESS_READWRITE << Metadata.UAVOBJ_ACCESS_SHIFT |
				(int)AccessMode.ACCESS_READWRITE << Metadata.UAVOBJ_GCS_ACCESS_SHIFT |
				1 << Metadata.UAVOBJ_TELEMETRY_ACKED_SHIFT |
				1 << Metadata.UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_ONCHANGE << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_ONCHANGE << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
    		metadata.flightTelemetryUpdatePeriod = 0;
    		metadata.gcsTelemetryUpdatePeriod = 0;
    		metadata.loggingUpdatePeriod = 0;
 
			return metadata;
		}

		/**
		 * Initialize object fields with the default values.
		 * If a default value is not specified the object fields
		 * will be initialized to zero.
		 */
		public void setDefaultFieldValues()
		{
			MaxAccel.setValue((float)1000);
			FeedForward.setValue((float)0);
			AccelTime.setValue((float)0);
			DecelTime.setValue((float)0);
			ThrottleCurve1.setValue((float)0,0);
			ThrottleCurve1.setValue((float)0,1);
			ThrottleCurve1.setValue((float)0,2);
			ThrottleCurve1.setValue((float)0,3);
			ThrottleCurve1.setValue((float)0,4);
			ThrottleCurve2.setValue((float)0,0);
			ThrottleCurve2.setValue((float)0.25,1);
			ThrottleCurve2.setValue((float)0.5,2);
			ThrottleCurve2.setValue((float)0.75,3);
			ThrottleCurve2.setValue((float)1,4);
			Curve2Source.setValue(Curve2SourceUavEnum.Throttle);
			Mixer1Type.setValue(Mixer1TypeUavEnum.Disabled);
			Mixer1Vector.setValue((sbyte)0,0);
			Mixer1Vector.setValue((sbyte)0,1);
			Mixer1Vector.setValue((sbyte)0,2);
			Mixer1Vector.setValue((sbyte)0,3);
			Mixer1Vector.setValue((sbyte)0,4);
			Mixer2Type.setValue(Mixer2TypeUavEnum.Disabled);
			Mixer2Vector.setValue((sbyte)0,0);
			Mixer2Vector.setValue((sbyte)0,1);
			Mixer2Vector.setValue((sbyte)0,2);
			Mixer2Vector.setValue((sbyte)0,3);
			Mixer2Vector.setValue((sbyte)0,4);
			Mixer3Type.setValue(Mixer3TypeUavEnum.Disabled);
			Mixer3Vector.setValue((sbyte)0,0);
			Mixer3Vector.setValue((sbyte)0,1);
			Mixer3Vector.setValue((sbyte)0,2);
			Mixer3Vector.setValue((sbyte)0,3);
			Mixer3Vector.setValue((sbyte)0,4);
			Mixer4Type.setValue(Mixer4TypeUavEnum.Disabled);
			Mixer4Vector.setValue((sbyte)0,0);
			Mixer4Vector.setValue((sbyte)0,1);
			Mixer4Vector.setValue((sbyte)0,2);
			Mixer4Vector.setValue((sbyte)0,3);
			Mixer4Vector.setValue((sbyte)0,4);
			Mixer5Type.setValue(Mixer5TypeUavEnum.Disabled);
			Mixer5Vector.setValue((sbyte)0,0);
			Mixer5Vector.setValue((sbyte)0,1);
			Mixer5Vector.setValue((sbyte)0,2);
			Mixer5Vector.setValue((sbyte)0,3);
			Mixer5Vector.setValue((sbyte)0,4);
			Mixer6Type.setValue(Mixer6TypeUavEnum.Disabled);
			Mixer6Vector.setValue((sbyte)0,0);
			Mixer6Vector.setValue((sbyte)0,1);
			Mixer6Vector.setValue((sbyte)0,2);
			Mixer6Vector.setValue((sbyte)0,3);
			Mixer6Vector.setValue((sbyte)0,4);
			Mixer7Type.setValue(Mixer7TypeUavEnum.Disabled);
			Mixer7Vector.setValue((sbyte)0,0);
			Mixer7Vector.setValue((sbyte)0,1);
			Mixer7Vector.setValue((sbyte)0,2);
			Mixer7Vector.setValue((sbyte)0,3);
			Mixer7Vector.setValue((sbyte)0,4);
			Mixer8Type.setValue(Mixer8TypeUavEnum.Disabled);
			Mixer8Vector.setValue((sbyte)0,0);
			Mixer8Vector.setValue((sbyte)0,1);
			Mixer8Vector.setValue((sbyte)0,2);
			Mixer8Vector.setValue((sbyte)0,3);
			Mixer8Vector.setValue((sbyte)0,4);
			Mixer9Type.setValue(Mixer9TypeUavEnum.Disabled);
			Mixer9Vector.setValue((sbyte)0,0);
			Mixer9Vector.setValue((sbyte)0,1);
			Mixer9Vector.setValue((sbyte)0,2);
			Mixer9Vector.setValue((sbyte)0,3);
			Mixer9Vector.setValue((sbyte)0,4);
			Mixer10Type.setValue(Mixer10TypeUavEnum.Disabled);
			Mixer10Vector.setValue((sbyte)0,0);
			Mixer10Vector.setValue((sbyte)0,1);
			Mixer10Vector.setValue((sbyte)0,2);
			Mixer10Vector.setValue((sbyte)0,3);
			Mixer10Vector.setValue((sbyte)0,4);
			Mixer11Type.setValue(Mixer11TypeUavEnum.Disabled);
			Mixer11Vector.setValue((sbyte)0,0);
			Mixer11Vector.setValue((sbyte)0,1);
			Mixer11Vector.setValue((sbyte)0,2);
			Mixer11Vector.setValue((sbyte)0,3);
			Mixer11Vector.setValue((sbyte)0,4);
			Mixer12Type.setValue(Mixer12TypeUavEnum.Disabled);
			Mixer12Vector.setValue((sbyte)0,0);
			Mixer12Vector.setValue((sbyte)0,1);
			Mixer12Vector.setValue((sbyte)0,2);
			Mixer12Vector.setValue((sbyte)0,3);
			Mixer12Vector.setValue((sbyte)0,4);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				MixerSettings obj = new MixerSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public MixerSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (MixerSettings)(objMngr.getObject(MixerSettings.OBJID, instID));
		}
	}
}
