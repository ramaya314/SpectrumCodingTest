
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

using UIKit;
using CoreGraphics;
using Foundation;

namespace demo
{
    public partial class UserListControllerView : UITableViewController
    {
        public UserListControllerView (IntPtr handle) : base (handle)
        {
		}

		List<User> Users = new List<User>();

		partial void OnAddButtonClicked(UIButton sender)
		{
			if (Storyboard.InstantiateViewController("UserEnterViewController") is UserEnterViewController userEnter)
			{
				userEnter.OnUserAdd = OnUserAdd;
				NavigationController.PushViewController(userEnter, true);
			}
		}


		private void OnUserAdd(User user)
		{
			Debug.WriteLine(user);
			if(Users.IndexOf(user) < 0)
			{
				Users.Add(user);
				TableView.Source = new TableSource(Users.Select(u => u.ToString()).ToArray());
			}

		}
    }
}