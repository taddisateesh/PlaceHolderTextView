using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TextViewWithPlaceHolder
{
	[Register("PlaceHolderTextView")]
	public class PlaceHolderTextView: UITextView, IUITextViewDelegate
    {
		int topPadding = 8;
        public PlaceHolderTextView()
        {
        }

		public PlaceHolderTextView(IntPtr handle) : base(handle)
        {
			_placeHolderLabel = new UILabel()
			{
				TextAlignment = this.TextAlignment
			};
             AddSubview(_placeHolderLabel);
            WeakDelegate = this;
        }

		readonly UILabel _placeHolderLabel;
		public UIColor PlaceHolderColor { get; set; } = UIColor.LightGray;
		int placeHolderHeight;

		protected override void Dispose(bool disposing)
        {
             base.Dispose(disposing);
        }

		string _placeholder;
        public string Placeholder
        {
            get { return _placeholder; }
            set
            {
                _placeholder = value;
				_placeHolderLabel.AttributedText = new NSAttributedString(
                    _placeholder,
                    font: Font,
					foregroundColor: PlaceHolderColor 
                );
                  _placeHolderLabel.SizeToFit();
				placeHolderHeight = (int)_placeHolderLabel.Frame.Height;
				_placeHolderLabel.Frame = new CGRect(4, topPadding, Frame.Size.Width, placeHolderHeight);
                //Commented by sateesh
                // _floatingLabel.Frame.Size.Width, _floatingLabel.Frame.Size.Height);
            }

        }

		public override UITextAlignment TextAlignment
		{
			get { return base.TextAlignment; }
			set
			{
				base.TextAlignment = value;
				_placeHolderLabel.TextAlignment = value;
			}
		}

		[Export("textViewDidChange:")]
        public virtual new void Changed(UITextView textView)
        {
            if (string.IsNullOrEmpty(Placeholder))
            {
                return;
            }

            Animate(0.3f, () => {
                if (Text.Length == 0)
                {
					_placeHolderLabel.Hidden = false;
                    LayoutSubviews();
                }
                else
                {
					_placeHolderLabel.Hidden = true;
                    LayoutSubviews();
                }
            });
        }

		public void DidChangeCallExplicitly()
        {
            if (string.IsNullOrEmpty(Placeholder))
            {
                return;
            }

            Animate(0.3f, () => {
                if (Text.Length == 0)
                {
                    LayoutSubviews();
                }
                else
                {
                    LayoutSubviews();
                }
            });
        }

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

   //         Action updateLabel = () =>
   //         {
   //             if (!string.IsNullOrEmpty(Text))
   //             {
			//		_placeHolderLabel.Font = this.Font;
   //                 _placeHolderLabel.Frame = new CGRect(4,topPadding,Frame.Size.Width, placeHolderHeight);
   //              }
   //             else
   //             {
			//		_placeHolderLabel.Font = Font;
			//		_placeHolderLabel.Frame = new CGRect(4, topPadding, Frame.Size.Width, placeHolderHeight);
					   
   //             }
   //         };
			//updateLabel();

		}

	}

}
