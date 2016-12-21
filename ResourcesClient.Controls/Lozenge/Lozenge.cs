using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace ResourcesClient.Controls
{

    public enum LozengeEnd { Saw, Straight, Arrow }

    /// <summary>
    /// Custom control for the lozenge that is placed in the resource gantt chart
    /// </summary>
    public class Lozenge : ToggleButton
    {
        #region Dependency properties

        // Dependency property backing variables
        public static readonly DependencyProperty IconSourceL1Property;
        public static readonly DependencyProperty IconSourceL2Property;
        public static readonly DependencyProperty IconSourceL3Property;
        public static readonly DependencyProperty IconSourceR1Property;
        public static readonly DependencyProperty IconSourceR2Property;
        public static readonly DependencyProperty IconSourceR3Property;
        public static readonly DependencyProperty LeftShapeProperty;
        public static readonly DependencyProperty RightShapeProperty;
        
        // 9 Labels RowNo.ColumnNo.
        public static readonly DependencyProperty LabelR1C1Property;
        public static readonly DependencyProperty LabelR1C2Property;
        public static readonly DependencyProperty LabelR1C3Property;
        public static readonly DependencyProperty LabelR2C1Property;
        public static readonly DependencyProperty LabelR2C2Property;
        public static readonly DependencyProperty LabelR2C3Property;
        public static readonly DependencyProperty LabelR3C1Property;
        public static readonly DependencyProperty LabelR3C2Property;
        public static readonly DependencyProperty LabelR3C3Property;

        // Left Top and Right Top Labels
        public static readonly DependencyProperty LabelLT1Property;
        public static readonly DependencyProperty LabelLT2Property;
        public static readonly DependencyProperty LabelRT1Property;
        public static readonly DependencyProperty LabelRT2Property;

        // Other Properties
        new public static readonly DependencyProperty BorderThicknessProperty;
        public static readonly DependencyProperty TextColorProperty;
        public static readonly DependencyProperty BackColorProperty;
        public static readonly DependencyProperty HighLightColorProperty;
        public static readonly DependencyProperty SelectionBackColorProperty;
        public static readonly DependencyProperty SelectionTextColorProperty;

        public static readonly DependencyProperty AllowedLinesProperty;
        public static readonly DependencyProperty IsHighlightedProperty;
        public static readonly DependencyProperty BoundKeyProperty;

        #endregion

        #region Routed Events

        public static readonly RoutedEvent BoundKeyDownEvent;
        public static readonly RoutedEvent BoundKeyUpEvent;

        #endregion

        #region Constructors
        static Lozenge()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Lozenge), new FrameworkPropertyMetadata(typeof(Lozenge)));

            // Initialize dependency properties
            IconSourceL1Property = DependencyProperty.Register("IconSourceL1", typeof(ImageSource), typeof(Lozenge), new UIPropertyMetadata(null));
            IconSourceL2Property = DependencyProperty.Register("IconSourceL2", typeof(ImageSource), typeof(Lozenge), new UIPropertyMetadata(null));
            IconSourceL3Property = DependencyProperty.Register("IconSourceL3", typeof(ImageSource), typeof(Lozenge), new UIPropertyMetadata(null));
            IconSourceR1Property = DependencyProperty.Register("IconSourceR1", typeof(ImageSource), typeof(Lozenge), new UIPropertyMetadata(null));
            IconSourceR2Property = DependencyProperty.Register("IconSourceR2", typeof(ImageSource), typeof(Lozenge), new UIPropertyMetadata(null));
            IconSourceR3Property = DependencyProperty.Register("IconSourceR3", typeof(ImageSource), typeof(Lozenge), new UIPropertyMetadata(null));

            LeftShapeProperty = DependencyProperty.Register("LeftShape", typeof(LozengeEnd), typeof(Lozenge), new UIPropertyMetadata(null));
            RightShapeProperty = DependencyProperty.Register("RightShape", typeof(LozengeEnd), typeof(Lozenge), new UIPropertyMetadata(null));

            LabelR1C1Property = DependencyProperty.Register("LabelR1C1", typeof(string), typeof(Lozenge), new UIPropertyMetadata(null));
            LabelR1C2Property = DependencyProperty.Register("LabelR1C2", typeof(string), typeof(Lozenge), new UIPropertyMetadata(null));
            LabelR1C3Property = DependencyProperty.Register("LabelR1C3", typeof(string), typeof(Lozenge), new UIPropertyMetadata(null));
            LabelR2C1Property = DependencyProperty.Register("LabelR2C1", typeof(string), typeof(Lozenge), new UIPropertyMetadata(null));
            LabelR2C2Property = DependencyProperty.Register("LabelR2C2", typeof(string), typeof(Lozenge), new UIPropertyMetadata(null));
            LabelR2C3Property = DependencyProperty.Register("LabelR2C3", typeof(string), typeof(Lozenge), new UIPropertyMetadata(null));
            LabelR3C1Property = DependencyProperty.Register("LabelR3C1", typeof(string), typeof(Lozenge), new UIPropertyMetadata(null));
            LabelR3C2Property = DependencyProperty.Register("LabelR3C2", typeof(string), typeof(Lozenge), new UIPropertyMetadata(null));
            LabelR3C3Property = DependencyProperty.Register("LabelR3C3", typeof(string), typeof(Lozenge), new UIPropertyMetadata(null));

            LabelLT1Property = DependencyProperty.Register("LabelLT1", typeof(string), typeof(Lozenge), new UIPropertyMetadata(null));
            LabelLT2Property = DependencyProperty.Register("LabelLT2", typeof(string), typeof(Lozenge), new UIPropertyMetadata(null));
            LabelRT1Property = DependencyProperty.Register("LabelRT1", typeof(string), typeof(Lozenge), new UIPropertyMetadata(null));
            LabelRT2Property = DependencyProperty.Register("LabelRT2", typeof(string), typeof(Lozenge), new UIPropertyMetadata(null));

            // properties
            BorderThicknessProperty = DependencyProperty.Register("BorderThickness", typeof(double), typeof(Lozenge), new UIPropertyMetadata(null));
            TextColorProperty = DependencyProperty.Register("TextColor", typeof(Brush), typeof(Lozenge), new UIPropertyMetadata(null));
            BackColorProperty = DependencyProperty.Register("BackColor", typeof(Brush), typeof(Lozenge), new UIPropertyMetadata(null));
            HighLightColorProperty = DependencyProperty.Register("HighLightColor", typeof(Brush), typeof(Lozenge), new PropertyMetadata(HighLightColorPropertyChanged));
            AllowedLinesProperty = DependencyProperty.Register("AllowedLines", typeof(int), typeof(Lozenge), new UIPropertyMetadata(null));

            SelectionBackColorProperty = DependencyProperty.Register("SelectionBackColor", typeof(Brush), typeof(Lozenge), new UIPropertyMetadata(null));
            SelectionTextColorProperty = DependencyProperty.Register("SelectionTextColor", typeof(Brush), typeof(Lozenge), new UIPropertyMetadata(null));
            IsHighlightedProperty = DependencyProperty.Register("IsHighlighted", typeof(bool), typeof(Lozenge), new UIPropertyMetadata(null));
            BoundKeyProperty = DependencyProperty.Register("BoundKey", typeof(Key), typeof(Lozenge), new UIPropertyMetadata(null));

            BoundKeyDownEvent = EventManager.RegisterRoutedEvent("BoundKeyDown", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Lozenge));
            BoundKeyUpEvent = EventManager.RegisterRoutedEvent("BoundKeyUp", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Lozenge));
        }

        public Lozenge()
        {
            this.PreviewKeyDown += new KeyEventHandler(Lozenge_PreviewKeyDown);
            this.PreviewKeyUp += new KeyEventHandler(Lozenge_PreviewKeyUp);
        }
        
        private void Lozenge_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == BoundKey || (e.Key == Key.System && e.SystemKey == BoundKey))
            {
                // bound key down by user
                RaiseEvent(new RoutedEventArgs(BoundKeyDownEvent, this));
            }
        }

        private void Lozenge_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == BoundKey || (e.Key == Key.System && e.SystemKey == BoundKey))
            {
                // bound key up by user
                RaiseEvent(new RoutedEventArgs(BoundKeyUpEvent, this));
            }
        }

        #endregion

        #region Custom Control Properties

        #region ImageSource Properties
        public LozengeEnd LeftShape
        {
            get { return (LozengeEnd)GetValue(LeftShapeProperty); }
            set { SetValue(LeftShapeProperty, value); }
        }
        public LozengeEnd RightShape
        {
            get { return (LozengeEnd)GetValue(RightShapeProperty); }
            set { SetValue(RightShapeProperty, value); }
        }

        public ImageSource IconSourceL1
        {
            get { return (ImageSource)GetValue(IconSourceL1Property); }
            set { SetValue(IconSourceL1Property, value); }
        }
        public ImageSource IconSourceL2
        {
            get { return (ImageSource)GetValue(IconSourceL2Property); }
            set { SetValue(IconSourceL2Property, value); }
        }
        public ImageSource IconSourceL3
        {
            get { return (ImageSource)GetValue(IconSourceL3Property); }
            set { SetValue(IconSourceL3Property, value); }
        }
        public ImageSource IconSourceR1
        {
            get { return (ImageSource)GetValue(IconSourceR1Property); }
            set { SetValue(IconSourceR1Property, value); }
        }
        public ImageSource IconSourceR2
        {
            get { return (ImageSource)GetValue(IconSourceR2Property); }
            set { SetValue(IconSourceR2Property, value); }
        }
        public ImageSource IconSourceR3
        {
            get { return (ImageSource)GetValue(IconSourceR3Property); }
            set { SetValue(IconSourceR3Property, value); }
        }
        #endregion

        #region Label Properties
        public string LabelR1C1
        {
            get { return (string)GetValue(LabelR1C1Property); }
            set { SetValue(LabelR1C1Property, value); }
        }

        public string LabelR1C2
        {
            get { return (string)GetValue(LabelR1C2Property); }
            set { SetValue(LabelR1C2Property, value); }
        }

        public string LabelR1C3
        {
            get { return (string)GetValue(LabelR1C3Property); }
            set { SetValue(LabelR1C3Property, value); }
        }

        public string LabelR2C1
        {
            get { return (string)GetValue(LabelR2C1Property); }
            set { SetValue(LabelR2C1Property, value); }
        }

        public string LabelR2C2
        {
            get { return (string)GetValue(LabelR2C2Property); }
            set { SetValue(LabelR2C2Property, value); }
        }

        public string LabelR2C3
        {
            get { return (string)GetValue(LabelR2C3Property); }
            set { SetValue(LabelR2C3Property, value); }
        }

        public string LabelR3C1
        {
            get { return (string)GetValue(LabelR3C1Property); }
            set { SetValue(LabelR3C1Property, value); }
        }


        public string LabelR3C2
        {
            get { return (string)GetValue(LabelR3C2Property); }
            set { SetValue(LabelR3C2Property, value); }
        }

        public string LabelR3C3
        {
            get { return (string)GetValue(LabelR3C3Property); }
            set { SetValue(LabelR3C3Property, value); }
        }

        public string LabelLT1
        {
            get { return (string)GetValue(LabelLT1Property); }
            set { SetValue(LabelLT1Property, value); }
        }

        public string LabelLT2
        {
            get { return (string)GetValue(LabelLT2Property); }
            set { SetValue(LabelLT2Property, value); }
        }

        public string LabelRT1
        {
            get { return (string)GetValue(LabelRT1Property); }
            set { SetValue(LabelRT1Property, value); }
        }

        public string LabelRT2
        {
            get { return (string)GetValue(LabelRT2Property); }
            set { SetValue(LabelRT2Property, value); }
        }

        #endregion

        new public double BorderThickness
        {
            get { return (double)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        public Brush TextColor  //Need to expand for each line (10 labels)
        {
            get { return (Brush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public Brush BackColor  
        {
            get { return (Brush)GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }

        public Brush HighLightColor
        {
            get { return (Brush)GetValue(HighLightColorProperty); }
            set 
            { 
                SetValue(HighLightColorProperty, value);
            }
        }

        public int AllowedLines
        {
            get { return (int)GetValue(AllowedLinesProperty); }
            set { SetValue(AllowedLinesProperty, value); }
        }

        public Brush SelectionTextColor
        {
            get { return (Brush)GetValue(SelectionTextColorProperty); }
            set { SetValue(SelectionTextColorProperty, value); }
        }

        public Brush SelectionBackColor
        {
            get { return (Brush)GetValue(SelectionBackColorProperty); }
            set { SetValue(SelectionBackColorProperty, value); }
        }

        // readonly - use HighLightColor to set Highlight
        public bool IsHighlighted
        {
            get { return (bool)GetValue(IsHighlightedProperty); }
        }

        public Key BoundKey
        {
            get { return (Key)GetValue(BoundKeyProperty); }
            set { SetValue(BoundKeyProperty, value); }
        }

        #endregion

        #region Routed Events

        public event RoutedEventHandler BoundKeyDown
        {
            add { AddHandler(BoundKeyDownEvent, value); }
            remove { RemoveHandler(BoundKeyDownEvent, value);  }
        }

        public event RoutedEventHandler BoundKeyUp
        {
            add { AddHandler(BoundKeyUpEvent, value); }
            remove { RemoveHandler(BoundKeyUpEvent, value); }
        }

        #endregion

        private static void HighLightColorPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            object value = e.NewValue;
            source.SetValue(IsHighlightedProperty, value != null);
        }
    }
}
