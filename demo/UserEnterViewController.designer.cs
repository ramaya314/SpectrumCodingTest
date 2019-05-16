// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace demo
{
    [Register ("UserEnterViewController")]
    partial class UserEnterViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ConfirmPasswordEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField NameEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordEntry { get; set; }

        [Action ("EnterButtonClicked:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EnterButtonClicked (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ConfirmPasswordEntry != null) {
                ConfirmPasswordEntry.Dispose ();
                ConfirmPasswordEntry = null;
            }

            if (NameEntry != null) {
                NameEntry.Dispose ();
                NameEntry = null;
            }

            if (PasswordEntry != null) {
                PasswordEntry.Dispose ();
                PasswordEntry = null;
            }
        }
    }
}