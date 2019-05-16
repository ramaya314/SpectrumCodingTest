using Foundation;
using System;
using UIKit;

namespace demo
{
    public partial class UserEnterViewController : UIViewController
    {
        public UserEnterViewController (IntPtr handle) : base (handle)
        {
        }
		
		public Action<User> OnUserAdd { get; set; } = user => { };

		partial void EnterButtonClicked(UIButton sender)
		{
			try
			{
				string name = NameEntry.Text;
				string password = PasswordEntry.Text;
				string confirmPassword = ConfirmPasswordEntry.Text;

				User user = new User(name, password);
				user.Validate();

				if (!password.Equals(confirmPassword))
					throw new Exception("The passwords do not match");

				OnUserAdd(user);
				NavigationController.PopViewController(true);

			} catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.StackTrace);
				var alertController = UIAlertController.Create ("Validation Error", e.Message, UIAlertControllerStyle.Alert);
				alertController.AddAction (UIAlertAction.Create ("OK", UIAlertActionStyle.Default, null));
				PresentViewController (alertController, true, null);
			}
		}
	}
}