namespace AppSWS;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow? Window { get; set; }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        // create a UIViewController
        var vc = new UIViewController
        {
            View = { BackgroundColor = UIColor.Black } // Set the background color to black
        };

        // Create and configure the UILabel
        var label = new UILabel(new CGRect(0, 100, Window!.Frame.Width, 50))
        {
            BackgroundColor = UIColor.SystemBackground,
            TextAlignment = UITextAlignment.Center,
            Text = "Hello World, Welcome on SWS Corp APP !",
            Font = UIFont.FromName("Helvetica-Bold", 24f), // Change the font and size
            TextColor = UIColor.Green,
            AutoresizingMask = UIViewAutoresizing.All,
        };

        // Create and configure the UIImageView
        var imageView = new UIImageView
        {
            Image = UIImage.FromFile(
                NSBundle.MainBundle.PathForResource("logo", "png")), // Ensure the image is in the Resources/img folder
            ContentMode = UIViewContentMode.ScaleAspectFit,
            TranslatesAutoresizingMaskIntoConstraints = false // Enable Auto Layout
        };

        // Add the UILabel and UIImageView to the view
        vc.View!.AddSubview(imageView);
        vc.View!.AddSubview(label);

        // Center the imageView
        NSLayoutConstraint.ActivateConstraints(new[]
        {
            imageView.CenterXAnchor.ConstraintEqualTo(vc.View.CenterXAnchor),
            imageView.CenterYAnchor.ConstraintEqualTo(vc.View.CenterYAnchor),
            imageView.WidthAnchor.ConstraintEqualTo(150),
            imageView.HeightAnchor.ConstraintEqualTo(150)
        });

        Window.RootViewController = vc;

        // make the window visible
        Window.MakeKeyAndVisible();

        return true;
    }
}