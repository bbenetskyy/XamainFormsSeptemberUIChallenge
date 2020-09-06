using System;
using MLToolkit.Forms.SwipeCardView.Core;
using SeptemberUIChallenge.PageModels;
using Xamarin.Forms;

namespace SeptemberUIChallenge.Pages
{
    public partial class CardsPage : ContentPage
    {
        public CardsPage()
        {
            InitializeComponent(); 
        }

        void OnDragging(object sender, DraggingCardEventArgs args)
        {
            var view = (Xamarin.Forms.View)sender;
            var nopeFrame = view.FindByName<Frame>("NopeFrame");
            var likeFrame = view.FindByName<Frame>("LikeFrame");
            var threshold = (BindingContext as CardsPageModel).Threshold;

            var draggedXPercent = args.DistanceDraggedX / threshold;

            var draggedYPercent = args.DistanceDraggedY / threshold;

            switch (args.Position)
            {
                case DraggingCardPosition.Start:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    nopeButton.Scale = 1;
                    likeButton.Scale = 1;
                    break;

                case DraggingCardPosition.UnderThreshold:
                    if (args.Direction == SwipeCardDirection.Left)
                    {
                        nopeFrame.Opacity = (-1) * draggedXPercent;
                        nopeButton.Scale = 1 + draggedXPercent / 2;
                    }
                    else if (args.Direction == SwipeCardDirection.Right)
                    {
                        likeFrame.Opacity = draggedXPercent;
                        likeButton.Scale = 1 - draggedXPercent / 2;
                    }
                    break;

                case DraggingCardPosition.OverThreshold:
                    if (args.Direction == SwipeCardDirection.Left)
                    {
                        nopeFrame.Opacity = 1;
                    }
                    else if (args.Direction == SwipeCardDirection.Right)
                    {
                        likeFrame.Opacity = 1;
                    }
                    else if (args.Direction == SwipeCardDirection.Up)
                    {
                        nopeFrame.Opacity = 0;
                        likeFrame.Opacity = 0;
                    }
                    break;

                case DraggingCardPosition.FinishedUnderThreshold:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    nopeButton.Scale = 1;
                    likeButton.Scale = 1;
                    break;

                case DraggingCardPosition.FinishedOverThreshold:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    nopeButton.Scale = 1;
                    likeButton.Scale = 1;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}