﻿using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Bugzilla, 60691, "Device.OpenUri(new Uri(\"tel: 123 456\")) crashes the app (space in phone number)", PlatformAffected.iOS)]
	public class Bugzilla60691 : TestContentPage
	{
		protected override void Init()
		{
			Content = new StackLayout
			{
				Children = {
					new Button { Text = "Call 123 4567", AutomationId = "tel", Command = new Command(() => Device.OpenUri(new System.Uri("tel:123 4567"))) },
					new Button { Text = "Go to https://bugzilla.xamarin.com/show_bug.cgi?id=60691", AutomationId = "web", Command = new Command(() => Device.OpenUri(new System.Uri("https://bugzilla.xamarin.com/show_bug.cgi?id=60691"))) }
				}
			};
		}

#if UITEST
		[Test]
		public void Bugzilla60691_Tel()
		{
			RunningApp.WaitForElement(q => q.Marked("tel"));
			RunningApp.Tap(q => q.Marked("tel"));
			RunningApp.Screenshot("Should have loaded phone with 123-4567");
		}

		[Test]
		public void Bugzilla60691_Web()
		{
			RunningApp.WaitForElement(q => q.Marked("web"));
			RunningApp.Tap(q => q.Marked("web"));
			RunningApp.Screenshot("Should have loaded bugzilla 60691");
		}
#endif
	}
}