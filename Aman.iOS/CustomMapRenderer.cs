using Aman.iOS;
using Aman.Models;
using Aman.ViewModels;
using Foundation;
using MapKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace Aman.iOS
{
    public class CustomMapRenderer: MapRenderer
    {
        UIView customPinView;
        List<CustomPin> customPins;

        //TODO Complete iOS Custom Render for available rooms list on map pin
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var nativeMap = Control as MKMapView;
                if (nativeMap != null)
                {
                    nativeMap.RemoveAnnotations(nativeMap.Annotations);
                    nativeMap.GetViewForAnnotation = null;
                    //nativeMap.CalloutAccessoryControlTapped -= OnCalloutAccessoryControlTapped;
                    //nativeMap.DidSelectAnnotationView -= OnDidSelectAnnotationView;
                    //nativeMap.DidDeselectAnnotationView -= OnDidDeselectAnnotationView;
                }
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                var nativeMap = Control as MKMapView;
                customPins = formsMap.CustomPins;

                nativeMap.GetViewForAnnotation = GetViewForAnnotation;
                //nativeMap.CalloutAccessoryControlTapped += OnCalloutAccessoryControlTapped;
                //nativeMap.DidSelectAnnotationView += OnDidSelectAnnotationView;
                //nativeMap.DidDeselectAnnotationView += OnDidDeselectAnnotationView;
            }
        }
        private string ListifyAvailableRooms(List<Room> availableRooms)
        {
            string roomsList;
            int numStudios = 0;
            int numSuites = 0;
            int numXlSuites = 0;
            int numPenthouses = 0;

            foreach (Room room in availableRooms)
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
        /*private CustomPin GetCustomPin(Marker marker)
        {
            var markerId = marker.Id;
            var pinId = markerId.Split("m")[1];
            CustomPin x = customPins.Find(s => s.PinId == pinId);
            return x;
        }*/
    }
}