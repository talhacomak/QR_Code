﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Droid.services;
using App1;
using ZXing.Mobile;
using Xamarin.Forms;

[assembly: Dependency(typeof(App1.Droid.services.QRScanner))]

namespace App1.Droid.services
{
    public class QRScanner : Interface1
    {
        public async Task<string> ScanAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Scan the QR Code",
                BottomText = "Please Wait",
            };

            var scanResult = await scanner.Scan(optionsCustom);
            if (scanResult != null) { 
                return scanResult.Text; 
            } else { 
                return null; 
            }
        }
    }
}