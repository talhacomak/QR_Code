﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.iOS.services;
using App1;
using ZXing.Mobile;
using Xamarin.Forms;

[assembly: Dependency(typeof(App1.iOS.services.QRScanner))]

namespace App1.iOS.services
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
            if (scanResult != null)
            {
                return scanResult.Text;
            }
            else
            {
                return null;
            }
        }
    }
}