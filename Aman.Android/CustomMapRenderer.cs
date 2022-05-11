using Aman.Droid;
using Aman.Models;
using Aman.ViewModels;
using Aman.Views;
using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace Aman.Droid
{
    class CustomMapRenderer: MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        List<CustomPin> customPins;
        public CustomMapRenderer(Context context): base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                //NativeMap.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
                
            }

        }
        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            //NativeMap.InfoWindowClick += OnInfoWindowClick;
            NativeMap.SetInfoWindowAdapter(this);
        }
        /*private async void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            throw new NotImplementedException();
        }*/
        public Android.Views.View GetInfoWindow(Marker marker)
        {
            //return null to call GetInfoContents method
            return null;
        }
        public Android.Views.View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;

                var customPin = GetCustomPin(marker);
                if (customPin == null)
                {
                    throw new Exception("Custom pin not found");
                }

                if (customPin.Label.Equals("Specific Address"))
                {
                    view = inflater.Inflate(Resource.Layout.CustomMapInfoWindow, null);
                }
                else
                {
                    view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
                }

                var infoTitle = view.FindViewById<TextView>(Resource.Id.textView1);
                var infoRegion = view.FindViewById<TextView>(Resource.Id.textView2);
                var infoAvailableRoomsTitle = view.FindViewById<TextView>(Resource.Id.textView3);
                var infoAvailableRooms = view.FindViewById<TextView>(Resource.Id.textView4);

                if (infoTitle != null)
                {
                    infoTitle.Text = marker.Title;
                }
                if (infoRegion != null)
                {
                    infoRegion.Text = customPin.Address;
                }
                if (infoAvailableRoomsTitle != null)
                {
                    infoAvailableRoomsTitle.Text = "Available Rooms:";
                }
                if (infoAvailableRooms != null)
                {
                    infoAvailableRooms.Text = ListifyAvailableRooms(customPin.AvailableRooms);
                }

                return view;
            }
            return null;
        }
        private string ListifyAvailableRooms(List<Room> availableRooms)
        {
            string roomsList;
            int numStudios = 0;
            int numSuites = 0;
            int numXlSuites = 0;
            int numPenthouses = 0;

            foreach(Room room in availableRooms)
            {
                switch (room.FloorPlan)
                {
                    case "Studio":
                        numStudios++;
                        break;
                    case "Suite":
                        numSuites++;
                        break;
                    case "XL Suite":
                    case "Xl Suite":
                        numXlSuites++;
                        break;
                    case "Penthouse":
                        numPenthouses++;
                        break;
                }
            }
            roomsList = $"{numStudios} Studios\n{numSuites} Suites\n{numXlSuites} XL Suites\n{numPenthouses} Penthouses";
            return roomsList;
        }
        private CustomPin GetCustomPin(Marker marker)
        {
            var markerId = marker.Id;
            var pinId = markerId.Split("m")[1];
            CustomPin x = customPins.Find(s => s.PinId == pinId);
            return x;
        }
    }
}