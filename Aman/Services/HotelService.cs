using Aman.Interfaces;
using Aman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace Aman.Services
{
    public class HotelService : IHotelService<Hotel>
    {
        public List<Hotel> hotels;

        public HotelService()
        {
            hotels = new List<Hotel>()
            {
                new Hotel { HotelID = "0", 
                            Name = "West Inn & Suites", 
                            Address="4970 Avenida Encinas Unit #111",
                            City = "Carlsbad",
                            State = "CA",
                            ZipCode = "92008",
                            Country = "USA",
                            Amentities = new List<Amenity>()
                            {
                                new Amenity { AmenityID ="7", Description ="On-site laundry", Name="Laundry",IconName="laundry.png"},
                                new Amenity { AmenityID ="8", Description ="Fully equipped buisness center", Name="Business Center",IconName="businessCenter.png"},
                                new Amenity { AmenityID ="9", Description ="Outdoor Heated Pool", Name="Heated Pool",IconName="pool.png"},
                                new Amenity { AmenityID ="10", Description ="Hot Tubs", Name="Hot Tub",IconName="hotTub.png"},
                                new Amenity { AmenityID ="11", Description ="Pet Friendly", Name="Pet Friendly",IconName="pets.png"},
                                new Amenity { AmenityID ="12", Description ="Parking Lot", Name="Parking",IconName="parking.png"},
                                new Amenity { AmenityID ="14", Description ="Routine Housekeeping", Name="Housekeeping",IconName="housekeeping.png"},
                                new Amenity { AmenityID ="15", Description ="Fitness Center", Name="Fitness Center",IconName="gym.png"}
                            },
                            AvailableRooms = new List<Room>()
                            {
                                new Room { 
                                    ParentHotelID = "0", 
                                    RoomID = "0", 
                                    Price = 2000, 
                                    FloorPlan = "Studio", 
                                    SqFeet = "900", 
                                    IconName = "studio.png",
                                    ImageNames = new List<string>()
                                    { 
                                        "Address_1_1.png","Address_1_2.png","Address_1_3.png","Address_1_4.png"
                                    } ,
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "0", 
                                    RoomID = "1", 
                                    Price = 3800, 
                                    FloorPlan = "Suite", 
                                    SqFeet = "1,500", 
                                    IconName = "suite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_1_1.png","Address_1_2.png","Address_1_3.png","Address_1_4.png"
                                    } ,
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "0", 
                                    RoomID = "2", 
                                    Price = 4000, 
                                    FloorPlan = "Suite", 
                                    SqFeet = "1,800", 
                                    IconName = "suite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_1_1.png","Address_1_2.png","Address_1_3.png","Address_1_4.png"
                                    }   ,
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { ParentHotelID = "0", 
                                    RoomID = "3", 
                                    Price = 5000, 
                                    FloorPlan = "XL Suite", 
                                    SqFeet = "2,200", 
                                    IconName = "xLSuite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_1_1.png","Address_1_2.png","Address_1_3.png","Address_1_4.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { ParentHotelID = "0",
                                    RoomID = "4",
                                    Price = 8000,
                                    FloorPlan = "Penthouse",
                                    SqFeet = "3,200",
                                    IconName = "penthouse.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_1_1.png","Address_1_2.png","Address_1_3.png","Address_1_4.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { ParentHotelID = "0",
                                    RoomID = "5",
                                    Price = 8000,
                                    FloorPlan = "Penthouse",
                                    SqFeet = "3,200",
                                    IconName = "penthouse.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_1_1.png","Address_1_2.png","Address_1_3.png","Address_1_4.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                }

                            },
                            ImageNames = new List<string>()
                            {
                                "Address_1_5.png","Address_1_6.png"
                            },
                            HotelPosition = new Position(33.1356767695679, -117.33144147681503),
                            ThumbnailName = "hotel.png"
                },
                new Hotel { HotelID = "1", 
                            Name = "Hilton Homewood Suites", 
                            Address="2576 Laning Road (Unit #111)",
                            City = "San Diego",
                            State = "CA",
                            ZipCode = "92106",
                            Country = "USA",
                            Amentities = new List<Amenity>()
                            {
                                new Amenity { AmenityID ="0", Description ="Full size gym", Name="Gym", IconName="gym.png"},
                                new Amenity { AmenityID ="1", Description ="Large relaxing spa", Name="Spa", IconName="spa.png"},
                                new Amenity { AmenityID ="2", Description ="24/7 Breakfast, Lunch, and Dinner Menu", Name="Room Service", IconName="roomService.png"},
                                new Amenity { AmenityID ="3", Description ="Board your pets!", Name="Pet Boarding",IconName="pets.png"}
                            },
                            AvailableRooms = new List<Room>()
                            {
                                new Room { 
                                    ParentHotelID = "1", 
                                    RoomID = "0", 
                                    Price = 2000, 
                                    FloorPlan = "Studio", 
                                    SqFeet = "900", 
                                    IconName = "studio.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_2_1.png","Address_2_2.png","Address_2_3.png","Address_2_4.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "1", 
                                    RoomID = "1", 
                                    Price = 3800, 
                                    FloorPlan = "Suite", 
                                    SqFeet = "1,500", 
                                    IconName = "suite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_2_1.png","Address_2_2.png","Address_2_3.png","Address_2_4.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "1", 
                                    RoomID = "2", 
                                    Price = 4000, 
                                    FloorPlan = "Suite", 
                                    SqFeet = "1,800", 
                                    IconName = "suite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_2_1.png","Address_2_2.png","Address_2_3.png","Address_2_4.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "1", 
                                    RoomID = "3", 
                                    Price = 5000, 
                                    FloorPlan = "XL Suite", 
                                    SqFeet = "2,200", 
                                    IconName = "xLSuite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_2_1.png","Address_2_2.png","Address_2_3.png","Address_2_4.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "1", 
                                    RoomID = "4", 
                                    Price = 8000, 
                                    FloorPlan = "Penthouse", 
                                    SqFeet = "3,200", 
                                    IconName = "penthouse.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_2_1.png","Address_2_2.png","Address_2_3.png","Address_2_4.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                }

                            },
                            ImageNames = new List<string>()
                            {
                                "Address_2_5.png",
                                "Address_2_6.png"
                            },
                            HotelPosition = new Position(32.72956492612323, -117.21612110230622),
                            ThumbnailName = "hotel.png"
                },
                new Hotel { HotelID = "2", 
                            Name = "Hilton Homewood Suites", 
                            Address="2201 Hotel Circle South (Unit #111)",
                            City = "San Diego",
                            State = "CA",
                            ZipCode = "92108",
                            Country = "USA",
                            Amentities = new List<Amenity>()
                            {
                                new Amenity { AmenityID ="0", Description ="Full size gym", Name="Gym", IconName="gym.png"},
                                new Amenity { AmenityID ="1", Description ="Large relaxing spa", Name="Spa", IconName="spa.png"},
                                new Amenity { AmenityID ="2", Description ="24/7 Breakfast, Lunch, and Dinner Menu", Name="Room Service", IconName="roomService.png"},
                                new Amenity { AmenityID ="3", Description ="Board your pets!", Name="Pet Boarding",IconName="pets.png"}
                            },
                            AvailableRooms = new List<Room>()
                            {
                                new Room { 
                                    ParentHotelID = "2", 
                                    RoomID = "0", 
                                    Price = 2000, 
                                    FloorPlan = "Studio", 
                                    SqFeet = "900", 
                                    IconName = "studio.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_3_1.png", "Address_3_2.png", "Address_3_3.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "2", 
                                    RoomID = "1", 
                                    Price = 3800, 
                                    FloorPlan = "Suite", 
                                    SqFeet = "1,500", 
                                    IconName = "suite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_3_1.png", "Address_3_2.png", "Address_3_3.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "2", 
                                    RoomID = "2", 
                                    Price = 4000, 
                                    FloorPlan = "Suite", 
                                    SqFeet = "1,800", 
                                    IconName = "suite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_3_1.png", "Address_3_2.png", "Address_3_3.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "2", 
                                    RoomID = "3", 
                                    Price = 5000, 
                                    FloorPlan = "XL Suite", 
                                    SqFeet = "2,200", 
                                    IconName = "xLSuite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_3_1.png", "Address_3_2.png", "Address_3_3.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "2", 
                                    RoomID = "4", 
                                    Price = 8000, 
                                    FloorPlan = "Penthouse", 
                                    SqFeet = "3,200", 
                                    IconName = "penthouse.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_3_1.png", "Address_3_2.png", "Address_3_3.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                }

                            },
                            ImageNames = new List<string>()
                            {
                                "Address_3_4.png",
                                "Address_3_5.png",
                                "Address_3_6.png"
                            },
                            HotelPosition = new Position(32.75883935192274, -117.1830503464862),
                            ThumbnailName = "hotel.png"
                },
                new Hotel { HotelID = "3", 
                            Name = "Hilton Homewood Suites", 
                            Address="11025 Vista Sorrento Parkway (Unit #111)",
                            City = "San Diego",
                            State = "CA",
                            ZipCode = "92130",
                            Country = "USA",
                            Amentities = new List<Amenity>()
                            {
                                new Amenity { AmenityID ="0", Description ="Full size gym", Name="Gym", IconName="gym.png"},
                                new Amenity { AmenityID ="1", Description ="Large relaxing spa", Name="Spa", IconName="spa.png"},
                                new Amenity { AmenityID ="2", Description ="24/7 Breakfast, Lunch, and Dinner Menu", Name="Room Service", IconName="roomService.png"},
                                new Amenity { AmenityID ="3", Description ="Board your pets!", Name="Pet Boarding",IconName="pets.png"}
                            },
                            AvailableRooms = new List<Room>()
                            {
                                new Room { 
                                    ParentHotelID = "3", 
                                    RoomID = "0", 
                                    Price = 2000, 
                                    FloorPlan = "Studio", 
                                    SqFeet = "900", 
                                    IconName = "studio.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_4_1.png", "Address_4_2.png", "Address_4_3.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "3", 
                                    RoomID = "1", 
                                    Price = 3800, 
                                    FloorPlan = "Suite", 
                                    SqFeet = "1,500", 
                                    IconName = "suite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_4_1.png", "Address_4_2.png", "Address_4_3.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "3", 
                                    RoomID = "2", 
                                    Price = 4000, 
                                    FloorPlan = "Suite", 
                                    SqFeet = "1,800", 
                                    IconName = "suite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_4_1.png", "Address_4_2.png", "Address_4_3.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "3", 
                                    RoomID = "3", 
                                    Price = 5000, 
                                    FloorPlan = "XL Suite", 
                                    SqFeet = "2,200", 
                                    IconName = "xLSuite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_4_1.png", "Address_4_2.png", "Address_4_3.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "3", 
                                    RoomID = "4", 
                                    Price = 8000, 
                                    FloorPlan = "Penthouse", 
                                    SqFeet = "3,200", 
                                    IconName = "penthouse.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_4_1.png", "Address_4_2.png", "Address_4_3.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                }

                            },
                            ImageNames = new List<string>()
                            {
                                "Address_4_4.png", "Address_4_5.png", "Address_4_6.png"
                            },
                            HotelPosition = new Position(32.916597874920946, -117.22882867110172),
                            ThumbnailName = "hotel.png"
                },
                new Hotel { HotelID = "4", 
                            Name = "Hilton Homewood Suites", 
                            Address="9880 Mira Mesa Blvd (Unit #111)",
                            City = "San Diego",
                            State = "CA",
                            ZipCode = "92131",
                            Country = "USA",
                            Amentities = new List<Amenity>()
                            {
                                new Amenity { AmenityID ="0", Description ="Full size gym", Name="Gym", IconName="gym.png"},
                                new Amenity { AmenityID ="1", Description ="Large relaxing spa", Name="Spa", IconName="spa.png"},
                                new Amenity { AmenityID ="2", Description ="24/7 Breakfast, Lunch, and Dinner Menu", Name="Room Service", IconName="roomService.png"},
                                new Amenity { AmenityID ="3", Description ="Board your pets!", Name="Pet Boarding",IconName="pets.png"}
                            },
                            AvailableRooms = new List<Room>()
                            {
                                new Room { 
                                    ParentHotelID = "4", 
                                    RoomID = "0", 
                                    Price = 2000, 
                                    FloorPlan = "Studio", 
                                    SqFeet = "900", 
                                    IconName = "studio.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_5_1.png", "Address_5_2.png", "Address_5_3.png", "Address_5_4.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "4", 
                                    RoomID = "1", 
                                    Price = 3800, 
                                    FloorPlan = "Suite", 
                                    SqFeet = "1,500", 
                                    IconName = "suite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_5_1.png", "Address_5_2.png", "Address_5_3.png", "Address_5_4.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "4", 
                                    RoomID = "2", 
                                    Price = 4000, 
                                    FloorPlan = "Suite", 
                                    SqFeet = "1,800", 
                                    IconName = "suite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_5_1.png", "Address_5_2.png", "Address_5_3.png", "Address_5_4.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "4", 
                                    RoomID = "3", 
                                    Price = 5000, 
                                    FloorPlan = "XL Suite", 
                                    SqFeet = "2,200", 
                                    IconName = "xLSuite.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_5_1.png", "Address_5_2.png", "Address_5_3.png", "Address_5_4.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                },
                                new Room { 
                                    ParentHotelID = "4", 
                                    RoomID = "4", 
                                    Price = 8000, 
                                    FloorPlan = "Penthouse", 
                                    SqFeet = "3,200", 
                                    IconName = "penthouse.png",
                                    ImageNames = new List<string>()
                                    {
                                        "Address_5_1.png", "Address_5_2.png", "Address_5_3.png", "Address_5_4.png"
                                    },
                                    Amenities = new List<Amenity>()
                                    {
                                        new Amenity { AmenityID ="0", Description ="King-Sized Bed", Name="King Bed", IconName="kingBed.png"},
                                        new Amenity { AmenityID ="1", Description ="Large spacious closets", Name="Spacious Closet", IconName="closet.png"},
                                        new Amenity { AmenityID ="2", Description ="Stove", Name="Stove", IconName="stove.png"},
                                        new Amenity { AmenityID ="3", Description ="Microwave", Name="Microwave",IconName="microwave.png"},
                                        new Amenity { AmenityID ="4", Description ="Refrigerator", Name="Refrigerator",IconName="fridge.png"},
                                        new Amenity { AmenityID ="5", Description ="Flat Screen TV", Name="Flat Screen TV",IconName="tv.png"},
                                        new Amenity { AmenityID ="6", Description ="Wi-Fi", Name="Wi-Fi",IconName="wifi.png"},
                                        new Amenity { AmenityID ="13", Description ="Desk", Name="Desk",IconName="desk.png"}
                                    }
                                }

                            },
                            ImageNames = new List<string>()
                            {
                                "Address_5_5.png", "Address_5_6.png", "Address_5_7.png"
                            },
                            HotelPosition = new Position(32.91814530075463, -117.1147555019528),
                            ThumbnailName = "hotel.png"
                }
            };
        }

        public async Task<Hotel> GetHotelAsync(string id)
        {
            return await Task.FromResult(hotels.FirstOrDefault(s => s.HotelID == id));
        }
        public async Task<IEnumerable<Hotel>> GetHotelsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(hotels);
        }
    }
}
