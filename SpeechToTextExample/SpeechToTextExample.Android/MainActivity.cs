﻿using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Plugin.CurrentActivity;
using Plugin.Permissions;

namespace SpeechToTextExample.Droid
{
    [Activity(Label = "SpeechToTextExample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            //if (CheckSelfPermission(Manifest.Permission.RecordAudio) != Permission.Granted)
            //{
            //    RequestPermissions(new String[] { Manifest.Permission.RecordAudio },100);
            //}

            //if (CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != Permission.Granted)
            //{
            //    RequestPermissions(new String[] { Manifest.Permission.WriteExternalStorage }, 100);
            //}

            //if (CheckSelfPermission(Manifest.Permission.ReadExternalStorage) != Permission.Granted)
            //{
            //    RequestPermissions(new String[] { Manifest.Permission.ReadExternalStorage }, 100);
            //}

            //if (CheckSelfPermission(Manifest.Permission.ModifyAudioSettings) != Permission.Granted)
            //{
            //    RequestPermissions(new String[] { Manifest.Permission.ModifyAudioSettings }, 100);
            //}

        }

        private void ShowDialog()
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Confirm delete");
            alert.SetMessage("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.");
            alert.SetPositiveButton("Delete", (senderAlert, args) => {
                Toast.MakeText(this, "Deleted!", ToastLength.Short).Show();
            });

            alert.SetNegativeButton("Cancel", (senderAlert, args) => {
                Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}