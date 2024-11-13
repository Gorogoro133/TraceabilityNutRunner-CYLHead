using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceabilityNutRunner_CYLHead
{
    public class DataFromCsv
    {
        public int Id { get; set; }
        public string Datatime { get; set; }
        public string Engine_No { get; set; }

        public string[] DataArray { get; set; } = new string[60]; // Array to hold the last 60 float data
    }
    // Model for spindle data
    public class Spindle
    {
        public int Id { get; set; }
        public string Torque { get; set; }
        public string Angle { get; set; }
    }

    

    public class DataSave
    {
        [Key]
        public int Id { get; set; }
        public string DatatimeRec { get; set; }
        public string Engin_NoRec { get; set; }
        public string MeasurementStatusRecord {  get; set; }
        public string SpindleNumber { get; set; }
        public string Torque1_Rec { get; set; }
        public string Torque2_Rec { get; set; }
        public string Torque3_Rec { get; set; }
        public string Torque4_Rec { get; set; }
        public string Torque5_Rec { get; set; }
        public string Torque6_Rec { get; set; }
        public string Torque7_Rec { get; set; }
        public string Torque8_Rec { get; set; }
        public string Torque9_Rec { get; set; }
        public string Torque10_Rec { get; set; }
        public string Torque11_Rec { get; set; }
        public string Torque12_Rec { get; set; }
        public string Torque13_Rec { get; set; }
        public string Torque14_Rec { get; set; }
        public string Torque15_Rec { get; set; }
        public string Torque16_Rec { get; set; }
        public string Torque17_Rec { get; set; }
        public string Torque18_Rec { get; set; }
        public string Torque19_Rec { get; set; }
        public string Torque20_Rec { get; set; }
        public string Torque21_Rec { get; set; }
        public string Torque22_Rec { get; set; }
        public string Torque23_Rec { get; set; }
        public string Torque24_Rec { get; set; }
        public string Torque25_Rec { get; set; }
        public string Torque26_Rec { get; set; }
        public string Torque27_Rec { get; set; }
        public string Torque28_Rec { get; set; }
        public string Torque29_Rec { get; set; }
        public string Torque30_Rec { get; set; }

        
        public string Angle1_Rec { get; set; }
        public string Angle2_Rec { get; set; }
        public string Angle3_Rec { get; set; }
        public string Angle4_Rec { get; set; }
        public string Angle5_Rec { get; set; }
        public string Angle6_Rec { get; set; }
        public string Angle7_Rec { get; set; }
        public string Angle8_Rec { get; set; }
        public string Angle9_Rec { get; set; }
        public string Angle10_Rec { get; set; }
        public string Angle11_Rec { get; set; }
        public string Angle12_Rec { get; set; }
        public string Angle13_Rec { get; set; }
        public string Angle14_Rec { get; set; }
        public string Angle15_Rec { get; set; }
        public string Angle16_Rec { get; set; }
        public string Angle17_Rec { get; set; }
        public string Angle18_Rec { get; set; }
        public string Angle19_Rec { get; set; }
        public string Angle20_Rec { get; set; }
        public string Angle21_Rec { get; set; }
        public string Angle22_Rec { get; set; }
        public string Angle23_Rec { get; set; }
        public string Angle24_Rec { get; set; }
        public string Angle25_Rec { get; set; }
        public string Angle26_Rec { get; set; }
        public string Angle27_Rec { get; set; }
        public string Angle28_Rec { get; set; }
        public string Angle29_Rec { get; set; }
        public string Angle30_Rec { get; set; }

    }
}
