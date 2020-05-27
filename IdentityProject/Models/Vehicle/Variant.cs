using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityProject.Models.Vehicle
{
    public class Variant
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public float Ex_ShowroomPrice { get; set; }
        public float On_Road_Price { get; set; }
        public float Mileage { get; set; }
        public float Engine_DisplacementCC { get; set; }
        public string Engine_Type { get; set; }
        public float Number_Of_Cylinder { get; set; }
        public float Max_Power { get; set; }
        public float Max_Torque { get; set; }
        public string Front_Brake { get; set; }
        public string Rear_Brake { get; set; }
        public float Total_Rating { get; set; }
        public virtual UserRating Rating { get; set; }
        public float Fuel_Tank_Capacity { get; set; }
        public string Body_Type { get; set; }
        public float Emi_Starts { get; set; }
        public float Insurance { get; set; }
        public string Cooling_System { get; set; }
        public string Valve_Per_Cylinder { get; set; }
        public string Drive_Type { get; set; }
        public string Ignition { get; set; }
        public string Fuel_Supply { get; set; }
        public string Clutch_Type { get; set; }
        public string Engine_Start { get; set; }
        public string Transmission { get; set; }
        public string Gear_Box { get; set; }
        public string Bore { get; set; }
        public string Stroke { get; set; }
        public string Emission_Type { get; set; }
        public string ABS { get; set; }
        public string Console { get; set; }
        public string Clock { get; set; }
        public string Quick_Shifter { get; set; }
        public string Additional_Features { get; set; }
        public string Stepup_Seat { get; set; }
        public float Seat_Height_mm { get; set; }
        public float Maximum_Height_mm { get; set; }
        public float Maximum_Length_mm { get; set; }
        public string Side_View_Mirror { get; set; }
        public float Side_View_Mirror_Width_mm { get; set; }
        public string Passenger_Footrest { get; set; }
        public string Chassis { get; set; }
        public string Front_Suspension { get; set; }
        public string Rear_Suspention { get; set; }
        public string Body_Graphics { get; set; }
        public string Saddle_Height { get; set; }
        public string Ground_Clearance { get; set; }
        public string Wheelbase { get; set; }
        public string Dry_Weight { get; set; }
        public string Headlight { get; set; }
        public string Tail_Light { get; set; }
        public string Turn_Signal_Lamp { get; set; }
        public string Led_Tail_Lights { get; set; }
        public string Front_Tyre_Size { get; set; }
        public string Rear_Tyre_Size { get; set; }
        public string Tyre_Type { get; set; }
        public string Front_Wheel_Size { get; set; }
        public string Rear_Wheel_Size { get; set; }
        public string Wheel_Type { get; set; }
        public string Front_Brake_Diameter { get; set; }
        public string Rear_Brake_Diameter { get; set; }
        public string Kerb_Weight { get; set; }
        public string Front_Track { get; set; }
        public string Rear_Track { get; set; }
        public string Minimum_Turning_Radius { get; set; }
        public int Number_Of_Doors { get; set; }
        public int Seat_Capacity { get; set; }
        public int Number_Gears { get; set; }
        public float Mileage_City { get; set; }
        public float Mileage_Highway { get; set; }
        public string Steering_Type { get; set; }
        public float Acceleration_From_0_to_100 { get; set; }
        public float Acceleration_From_0_to_60 { get; set; }
        public float Max_Speed { get; set; }

        public  List<VehicleMedia> media { get; set; }
        public  List<Color> Colors { get; set; }
        public DateTime LaunchDate { get; set; }
        public int Model_Year { get; set; }
        public float Popularity { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsActive { get; set; }
        public float User_Rating { get; set; }
        public virtual ApplicationUser Added_User { get; set; }





    }
}