using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// Control which allows user to select items from a list by giving
    /// them the flexibility to enter comma separated values in an Edit text box
    /// OR for them to call up a MultiSelectControl dialog window to 
    /// select the chosen values from a listbox control.
    /// Control performs validation on user entered data and highlights
    /// items which are not valid.
    /// </summary>
    public partial class EditSelector : UserControl
    {
        #region Private Fields
        // default titles for the two list boxes
        private static readonly string AVAILABLE_TITLE = "_Available Items:";
        private static readonly string SELECTED_TITLE = "_Selected Items:";
        private static readonly Brush DEFAULT_ERROR_BRUSH = new SolidColorBrush(Colors.Red);
        private static readonly string DEFAULT_PLUS_ACCESSKEY = "+";
        private static readonly char DEFAULT_DELIMITER = ',';
        private static readonly string DEFAULT_EDITTOOLTIP = "Enter valid values separated by comma";
        private static readonly string DEFAULT_BUTTONTOOLTIP = "Click to choose valid values";
        private static readonly string DEFAULT_SELECTWINTITLE = "Select Items";
        private static readonly string DEFAULT_SELECTWINOKCONTENT = "_OK";
        private static readonly string DEFAULT_SELECTWINCANCELCONTENT = "_Cancel";
        private static readonly string DEFAULT_SELECTWINOKTOOLTIP = "Click to save selection";
        private static readonly string DEFAULT_SELECTWINCANCELTOOLTIP = "Click to cancel selection";
        private static readonly string DEFAULT_ERRORCONTENT = "Remove invalid values";

        // list of valid values that the user can enter in the
        // Edit TextBox - ALL UPPER CASE
        private HashSet<string> codes;
        // dictionary of codes to the actual object that they represent
        private Dictionary<string, object> codesDict;

        // variables to store delimiter processing data
        private char[] delimiters;
        private string delimiterString;
        // flag indicating the text box has been changed
        private bool textChanged;
        // instance of the select window
        private SelectWindow selectWindow;
        
        #endregion

        #region Constructor
        public EditSelector()
        {
            InitializeComponent();

            // initialize member variables
            // used in Split
            delimiters = new char[] { DEFAULT_DELIMITER };
            // used to recreate the delimited text (offset by space for readability)
            delimiterString = DEFAULT_DELIMITER + " ";
            // register default access key
            AccessKeyManager.Register(DEFAULT_PLUS_ACCESSKEY, PlusButton);
            // create select window instance
            selectWindow = new SelectWindow();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Validate the user entered data in the Edit TextBox.
        /// Invoke this method to force validation only as by default validation
        /// always occurs when the text box loses keyboard focus.
        /// </summary>
        public void Validate()
        {
            ValidateEditTextBox();
        }
        #endregion

        #region Dependency Properties
        /// <summary>
        /// Identifies the IsReadOnly dependency property
        /// </summary>
        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(EditSelector),
            new FrameworkPropertyMetadata(false));
        /// <summary>
        /// Gets or sets if the control is Read Only.
        /// Default value is false.
        /// </summary>
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        /// <summary>
        /// Identifies the ItemsSource dependency property
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(EditSelector), 
            new FrameworkPropertyMetadata(new PropertyChangedCallback(ItemsSourcePropertyChanged)));
        /// <summary>
        /// Gets or sets a collection of all items that are available for selection. This collection includes the selected items also.
        /// </summary>
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // clear the code hashset as it will need to be initialized
        private static void ItemsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            IEnumerable source = e.NewValue as IEnumerable;
            EditSelector control = sender as EditSelector;
            if (source == null || control == null)
            {
                return;
            }
            control.codes = null;
            control.codesDict = null;
        }

        /// <summary>
        /// Identifies the SelectedItems dependency property
        /// </summary>
        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(IList), typeof(EditSelector),
            new FrameworkPropertyMetadata(new List<object>(), new PropertyChangedCallback(SelectedItemsPropertyChanged)));
        /// <summary>
        /// Gets the currently selected items. 
        /// Selected Items can be entered in the Edit TextBox as CSV using the CodeMemberPath attributes of the object OR
        /// can be selected using the MultiSelectControl via the Plus Button.
        /// </summary>
        public IList SelectedItems
        {
            get { return (IList)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        private static void SelectedItemsPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            IList source = e.NewValue as IList;
            EditSelector control = sender as EditSelector;
            if (source == null || control == null)
            {
                return;
            }
            control.EditTextBox.TextChanged -= control.EditTextBox_TextChanged;
            control.ConvertSelectedItemstoText();
            control.EditTextBox.TextChanged += control.EditTextBox_TextChanged;
        }

        /// <summary>
        /// Identifies the ErrorItems dependency property
        /// </summary>
        public static readonly DependencyProperty ErrorItemsProperty = DependencyProperty.Register("ErrorItems", typeof(IList<string>), typeof(EditSelector), 
            new FrameworkPropertyMetadata(new List<string>()));
        /// <summary>
        /// Gets the items currently entered by the user in Edit TextBox which are invalid.
        /// Invalid values are not present in the ItemsSource list and will be highlighted with the ErrorBackgroundBrush in the 
        /// Edit TextBox.
        /// If there are no errors, then this list will be empty. All values in the list will be strings entered by the user.
        /// </summary>
        public IList<string> ErrorItems
        {
            get { return (IList<string>)GetValue(ErrorItemsProperty); }
            set { SetValue(ErrorItemsProperty, value); }
        }

        /// <summary>
        /// Identifies the AvailableTitle dependency property
        /// </summary>
        public static readonly DependencyProperty AvailableTitleProperty = DependencyProperty.Register("AvailableTitle", typeof(string), typeof(EditSelector), 
            new FrameworkPropertyMetadata(AVAILABLE_TITLE));
        /// <summary>
        /// Set the title to be displayed on the MultiSelectControl Available items list box. Defaults to "Available items:"
        /// </summary>
        public string AvailableTitle
        {
            get { return (string)GetValue(AvailableTitleProperty); }
            set { SetValue(AvailableTitleProperty, value); }
        }

        /// <summary>
        /// Identifies the SelectedTitle dependency property
        /// </summary>
        public static readonly DependencyProperty SelectedTitleProperty = DependencyProperty.Register("SelectedTitle", typeof(string), typeof(EditSelector), 
            new FrameworkPropertyMetadata(SELECTED_TITLE));
        /// <summary>
        /// Set the title to be displayed on the MultiSelectControl Selected items list box. Defaults to "Selected items:"
        /// </summary>
        public string SelectedTitle
        {
            get { return (string)GetValue(SelectedTitleProperty); }
            set { SetValue(SelectedTitleProperty, value); }
        }

        /// <summary>
        /// Identifies the DisplayMemberPath dependency property
        /// </summary>
        public static readonly DependencyProperty DisplayMemberPathProperty = DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(EditSelector), 
            new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Gets or sets a path to a value on the source object to serve as the visual representation of the object.
        /// This visual representation is displayed in the two list boxes of the MultiSelectControl.
        /// </summary>
        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }

        /// <summary>
        /// Identifies the FilterMemberPath dependency property
        /// </summary>
        public static readonly DependencyProperty FilterMemberPathProperty = DependencyProperty.Register("FilterMemberPath", typeof(string), typeof(EditSelector),
            new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Gets or sets a path to a value on the source object to serve as the check for filtering on the MultiSelectControl.
        /// The filter text is compared with this property ToString() value.
        /// Usually set the same as DisplayMemberPath.
        /// </summary>
        public string FilterMemberPath
        {
            get { return (string)GetValue(FilterMemberPathProperty); }
            set { SetValue(FilterMemberPathProperty, value); }
        }

        /// <summary>
        /// Identifies the CodeMemberPath dependency property
        /// </summary>
        public static readonly DependencyProperty CodeMemberPathProperty = DependencyProperty.Register("CodeMemberPath", typeof(string), typeof(EditSelector),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(CodeMemberPathPropertyChanged)));
        /// <summary>
        /// Gets or sets a path to a value on the source object to serve as the check for values entered by user in Edit TextBox.
        /// The user entered values in the Edit TextBox are compared to this property ToString() value.
        /// Usually set to a unique code property in the source object.
        /// </summary>
        public string CodeMemberPath
        {
            get { return (string)GetValue(CodeMemberPathProperty); }
            set { SetValue(CodeMemberPathProperty, value); }
        }

        // clear the codes hashset
        private static void CodeMemberPathPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            string source = e.NewValue as string;
            string old = e.OldValue as string;
            EditSelector control = sender as EditSelector;
            if (source == null || control == null)
            {
                return;
            }
            // clear the hashset as the data structure will need to be initialized
            control.codes = null;
            control.codesDict = null;
        }

        /// <summary>
        /// Identifies the PlusButtonAccessKey dependency property
        /// </summary>
        public static readonly DependencyProperty PlusButtonAccessKeyProperty = DependencyProperty.Register("PlusButtonAccessKey", typeof(string), typeof(EditSelector),
            new FrameworkPropertyMetadata(DEFAULT_PLUS_ACCESSKEY, new PropertyChangedCallback(PlusButtonAccessKeyPropertyChanged)));
        /// <summary>
        /// Set the Access Key used for the Plus Button to invoke the MultiSelectControl.
        /// Default value is the "+" key.
        /// </summary>
        public string PlusButtonAccessKey
        {
            get { return (string)GetValue(PlusButtonAccessKeyProperty); }
            set { SetValue(PlusButtonAccessKeyProperty, value); }
        }

        // initialize the plus button access key
        private static void PlusButtonAccessKeyPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            string source = e.NewValue as string;
            string old = e.OldValue as string;
            EditSelector control = sender as EditSelector;
            if (source == null || control == null)
            {
                return;
            }
            // set the access key for the plus button
            AccessKeyManager.Register(source, control.PlusButton);
            // unregister the old access key if present
            if (old != null)
            {
                AccessKeyManager.Unregister(old, control.PlusButton);
            }
        }

        /// <summary>
        /// Identifies the ErrorBackgroundBrush dependency property
        /// </summary>
        public static readonly DependencyProperty ErrorBackgroundBrushProperty = DependencyProperty.Register("ErrorBackgroundBrush", typeof(Brush), typeof(EditSelector), 
            new FrameworkPropertyMetadata(DEFAULT_ERROR_BRUSH));
        /// <summary>
        /// Set the Brush to be used to highlight invalid user entered values in the Edit TextBox.
        /// Default value is SolidColorBrush in Red.
        /// </summary>
        public Brush ErrorBackgroundBrush
        {
            get { return (Brush)GetValue(ErrorBackgroundBrushProperty); }
            set { SetValue(ErrorBackgroundBrushProperty, value); }
        }

        /// <summary>
        /// Identifies the Delimiter dependency property
        /// </summary>
        public static readonly DependencyProperty DelimiterProperty = DependencyProperty.Register("Delimiter", typeof(char), typeof(EditSelector),
            new FrameworkPropertyMetadata(DEFAULT_DELIMITER, new PropertyChangedCallback(DelimiterPropertyChanged)));
        /// <summary>
        /// Set the Delimiter which user uses to delimit values in the Edit TextBox
        /// Default value is the ",".
        /// </summary>
        public char Delimiter
        {
            get { return (char)GetValue(DelimiterProperty); }
            set { SetValue(DelimiterProperty, value); }
        }

        // initialize the delimiter data structures
        private static void DelimiterPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            EditSelector control = sender as EditSelector;
            if (e.NewValue == null || control == null)
            {
                return;
            }
            // used in Split
            control.delimiters = new char[] { (char)e.NewValue };
            // used to recreate the delimited text (offset by space for readability)
            control.delimiterString = (char)e.NewValue + " ";
        }

        /// <summary>
        /// Identifies the TooltipTextBox dependency property
        /// </summary>
        public static readonly DependencyProperty TooltipTextBoxProperty = DependencyProperty.Register("TooltipTextBox", typeof(string), typeof(EditSelector),
            new FrameworkPropertyMetadata(DEFAULT_EDITTOOLTIP));
        /// <summary>
        /// Get or set the Tooltip applied to the Edit TextBox.
        /// Default value is non-localized text "Enter valid values separated by comma"
        /// </summary>
        public string TooltipTextBox
        {
            get { return (string)GetValue(TooltipTextBoxProperty); }
            set { SetValue(TooltipTextBoxProperty, value); }
        }

        /// <summary>
        /// Identifies the TooltipButton dependency property
        /// </summary>
        public static readonly DependencyProperty TooltipButtonProperty = DependencyProperty.Register("TooltipButton", typeof(string), typeof(EditSelector),
            new FrameworkPropertyMetadata(DEFAULT_BUTTONTOOLTIP));
        /// <summary>
        /// Get or set the Tooltip applied to the Plus Button.
        /// Default value is non-localized text "Click to choose valid values"
        /// </summary>
        public string TooltipButton
        {
            get { return (string)GetValue(TooltipButtonProperty); }
            set { SetValue(TooltipButtonProperty, value); }
        }

        /// <summary>
        /// Identifies the SelectWindowTitle dependency property
        /// </summary>
        public static readonly DependencyProperty SelectWindowTitleProperty = DependencyProperty.Register("SelectWindowTitle", typeof(string), typeof(EditSelector),
            new FrameworkPropertyMetadata(DEFAULT_SELECTWINTITLE));
        /// <summary>
        /// Get or set the Title to be displayed on the Select Items Window.
        /// Default value is non-localized text "Select Items"
        /// </summary>
        public string SelectWindowTitle
        {
            get { return (string)GetValue(SelectWindowTitleProperty); }
            set { SetValue(SelectWindowTitleProperty, value); }
        }

        /// <summary>
        /// Identifies the SelectWindowOKContent dependency property
        /// </summary>
        public static readonly DependencyProperty SelectWindowOKContentProperty = DependencyProperty.Register("SelectWindowOKContent", typeof(object), typeof(EditSelector),
            new FrameworkPropertyMetadata(DEFAULT_SELECTWINOKCONTENT));
        /// <summary>
        /// Get or set the content to be displayed in the OK button on the Select Items Window.
        /// Default value is non-localized text "OK"
        /// </summary>
        public object SelectWindowOKContent
        {
            get { return (object)GetValue(SelectWindowOKContentProperty); }
            set { SetValue(SelectWindowOKContentProperty, value); }
        }

        /// <summary>
        /// Identifies the SelectWindowCancelContent dependency property
        /// </summary>
        public static readonly DependencyProperty SelectWindowCancelContentProperty = DependencyProperty.Register("SelectWindowCancelContent", typeof(object), typeof(EditSelector),
            new FrameworkPropertyMetadata(DEFAULT_SELECTWINCANCELCONTENT));
        /// <summary>
        /// Get or set the content to be displayed in the Cancel button on the Select Items Window.
        /// Default value is non-localized text "Cancel"
        /// </summary>
        public object SelectWindowCancelContent
        {
            get { return (object)GetValue(SelectWindowCancelContentProperty); }
            set { SetValue(SelectWindowCancelContentProperty, value); }
        }

        /// <summary>
        /// Identifies the SelectWindowOKTooltip dependency property
        /// </summary>
        public static readonly DependencyProperty SelectWindowOKTooltipProperty = DependencyProperty.Register("SelectWindowOKTooltip", typeof(string), typeof(EditSelector),
            new FrameworkPropertyMetadata(DEFAULT_SELECTWINOKTOOLTIP));
        /// <summary>
        /// Get or set the Tooltip to be displayed on the OK button in the Select Items Window.
        /// Default value is non-localized text "Click to save selection"
        /// </summary>
        public string SelectWindowOKTooltip
        {
            get { return (string)GetValue(SelectWindowOKTooltipProperty); }
            set { SetValue(SelectWindowOKTooltipProperty, value); }
        }

        /// <summary>
        /// Identifies the SelectWindowCancelTooltip dependency property
        /// </summary>
        public static readonly DependencyProperty SelectWindowCancelTooltipProperty = DependencyProperty.Register("SelectWindowCancelTooltip", typeof(string), typeof(EditSelector),
            new FrameworkPropertyMetadata(DEFAULT_SELECTWINCANCELTOOLTIP));
        /// <summary>
        /// Get or set the Tooltip to be displayed on the Cancel button in the Select Items Window.
        /// Default value is non-localized text "Click to cancel selection"
        /// </summary>
        public string SelectWindowCancelTooltip
        {
            get { return (string)GetValue(SelectWindowCancelTooltipProperty); }
            set { SetValue(SelectWindowCancelTooltipProperty, value); }
        }

        /// <summary>
        /// Identifies the SelectWindowStyle dependency property
        /// </summary>
        public static readonly DependencyProperty SelectWindowStyleProperty = DependencyProperty.Register("SelectWindowStyle", typeof(Style), typeof(EditSelector),
            new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Get or set the Style for the Select Items Window.
        /// Default value will apply default Window style to Select Items Window.
        /// </summary>
        public Style SelectWindowStyle
        {
            get { return (Style)GetValue(SelectWindowStyleProperty); }
            set { SetValue(SelectWindowStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the ErrorContent dependency property
        /// </summary>
        public static readonly DependencyProperty ErrorContentProperty = DependencyProperty.Register("ErrorContent", typeof(string), typeof(EditSelector),
            new FrameworkPropertyMetadata(DEFAULT_ERRORCONTENT));
        /// <summary>
        /// Get or set the Error content to show in the case of Validation Errors.
        /// This is as per the WPF Data binding validation.
        /// Default value is non-localized text "Remove invalid values"
        /// </summary>
        public string ErrorContent
        {
            get { return (string)GetValue(ErrorContentProperty); }
            set { SetValue(ErrorContentProperty, value); }
        }
        #endregion

        #region Event Handlers
        // invoked when plus button is clicked
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // initalize the select window selected items
            selectWindow.SelectWindowSelectedItems = CopySelectedItems();
            selectWindow.ShowDialog();
            if (selectWindow.SelectWindowResult)
            {
                // reset flag
                selectWindow.SelectWindowResult = false;
                // save the new selection
                SaveSelectedItems(selectWindow.SelectWindowSelectedItems);
                // convert to text also
                ConvertSelectedItemstoText();
                // clear any validation errors as no errors
                ClearValidationError();
                // clear error items as none will exist
                ErrorItems.Clear();
            }
        }

        // special handling for any label key accelerators associated with this user control
        private void EditSelectorControl_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            // if this event originates from EditSelectorControl
            // which means that this UserControl has recieved keyboard focus.
            // This will happen when a label associated with this user control has invoked key accelerator tagret
            if (sender == e.OriginalSource)
            {
                // transfer focus to Edit text box within this user control
                Keyboard.Focus(EditTextBox);
            }
        }

        // invoked when EditTextBox loses keyboard focus - validate user entered data
        private void EditTextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            // validate text box only if text has changed
            if (textChanged)
            {
                // disable any text changed events raised by clearing formatting
                EditTextBox.TextChanged -= EditTextBox_TextChanged;
                ValidateEditTextBox();
                EditTextBox.TextChanged += EditTextBox_TextChanged;
                // reset flag to await further user text edits
                textChanged = false;
            }
        }

        // remove any validation formatting when user edits text box
        // this is to improve clarity
        private void EditTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
            // disable any text changed events raised by clearing formatting
            EditTextBox.TextChanged -= EditTextBox_TextChanged;
            ResetEditTextBox();
            EditTextBox.TextChanged += EditTextBox_TextChanged;
        }

        // setup the selected items in the edit text box
        private void EditSelectorControl_Loaded(object sender, RoutedEventArgs e)
        {
            // do nothing in design mode
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

            // set validation error template for edit text box, from user control (if any)
            Validation.SetErrorTemplate(EditTextBox, Validation.GetErrorTemplate(this));
            
            // setup the Select items window
            selectWindow.Owner= GetParentWindow();
            selectWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            selectWindow.DataContext = this;
        }
        #endregion

        #region Helper methods
        // rest any validation colors in the EditTextBox
        private void ResetEditTextBox()
        {
            // get the text
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                EditTextBox.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                EditTextBox.Document.ContentEnd
            );
            // clear all formatting - when user is editing
            textRange.ClearAllProperties();
        }

        // Validate the user entered values in EditTextBox
        private void ValidateEditTextBox()
        {
            // initialize codes hashset, if not done
            if (codes == null)
            {
                InitializeCodes();
            }
            // clear any validation errors
            ClearValidationError();
            // clear current selected and error items
            // these will be recalculated
            SafeClear(SelectedItems);
            SafeClear(ErrorItems);
            
            // create a hashset of selected codes
            // to prevent duplicates
            HashSet<string> selectedCodes = new HashSet<string>();

            // get the plain text
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                EditTextBox.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                EditTextBox.Document.ContentEnd
            );
            string text = textRange.Text;
            // sanity check
            if (text.Trim().Length == 0)
            {
                return;
            }

            // split using the delimiter
            string[] values = text.Split(delimiters);
            
            // create flow document
            FlowDocument fd = new FlowDocument();
            EditTextBox.Document = fd;
            Paragraph para = new Paragraph();
            fd.Blocks.Add(para);
            bool isError = false;

            // iterate the user entered values
            for (int i = 0; i < values.Length; i++)
            {
                string value = values[i].Trim().ToUpper();
                
                string txt = value;
                // add delimiter for all but last value
                if (i > 0)
                {
                    txt = delimiterString + value;
                }
                // does value exist
                if (codes.Contains(value))
                {
                    // check if already present in selected list
                    if (!selectedCodes.Contains(value))
                    {
                        para.Inlines.Add(new Span(new Run(txt)));
                        // add to selected items
                        SafeAdd(SelectedItems, codesDict[value]);
                        // include in already selected items
                        selectedCodes.Add(value);
                    }
                }
                else
                {
                    // this is an error
                    Span span = new Span(new Run(txt));
                    span.Background = ErrorBackgroundBrush;
                    para.Inlines.Add(span);
                    // set validation error, if not done so already
                    if (!isError)
                    {
                        isError = true;
                        SetValidationError();
                    }
                    // add to error items
                    SafeAdd(ErrorItems, value);
                }
            }
        }

        #region Null safe List helper methods
        private void SafeClear(IList list)
        {
            if (list != null)
            {
                list.Clear();
            }
        }

        private void SafeClear(IList<string> list)
        {
            if (list != null)
            {
                list.Clear();
            }
        }

        private void SafeAdd(IList list, object item)
        {
            if (list != null)
            {
                list.Add(item);
            }
        }

        private void SafeAdd(IList<string> list, string item)
        {
            if (list != null)
            {
                list.Add(item);
            }
        }
        #endregion

        // get the parent window of this user control
        private Window GetParentWindow()
        {
            return Window.GetWindow(this);
        }

        // helper method to use reflection to determine value of passed property
        private object GetPropertyValue(object source, string propertyName, BindingFlags flags)
        {
            object value = null;
            // Get the specific field info
            PropertyInfo pInfo = source.GetType().GetProperty(propertyName, flags | BindingFlags.Instance);

            // Make sure the property info is not null
            if (pInfo != null)
            {
                // Retrieve the value from the field.
                value = pInfo.GetValue(source, null);
            }
            return value;
        }

        // helper method to initialize the codes lookup hashset
        // these data structures are used to validate user entered code values
        private void InitializeCodes()
        {
            codes = new HashSet<string>();
            codesDict = new Dictionary<string, object>();
            // sanity check
            if (ItemsSource == null)
            {
                return;
            }
            foreach (object o in ItemsSource)
            {
                // get code value for the object
                object value = GetPropertyValue(o, CodeMemberPath, BindingFlags.Public);
                string code = (value == null ? string.Empty : value.ToString().ToUpper());
                codes.Add(code);
                codesDict[code] = o;
            }
        }

        // helper method to convert selected items list into delimited code text
        private void ConvertSelectedItemstoText()
        {
            // create flow document
            FlowDocument fd = new FlowDocument();
            EditTextBox.Document = fd;
            Paragraph para = new Paragraph();
            fd.Blocks.Add(para);

            string codesList = string.Empty;
            foreach (object o in SelectedItems)
            {
                // get code value for the object
                object value = GetPropertyValue(o, CodeMemberPath, BindingFlags.Public);
                if (value != null)
                {
                    if (codesList.Length > 0)
                    {
                        codesList += delimiterString;
                    }
                    codesList += value.ToString();
                }
            }
            // add to fd
            para.Inlines.Add(new Span(new Run(codesList)));
        }

        // helper method to copy selected items to display in select window
        private ObservableCollection<object> CopySelectedItems()
        {
            ObservableCollection<object> list = new ObservableCollection<object>();
            foreach (object o in SelectedItems)
            {
                list.Add(o);
            }
            return list;
        }

        // helper method to copy the passed list into the SelectedItems list
        private void SaveSelectedItems(IList list)
        {
            SelectedItems.Clear();
            foreach (object o in list)
            {
                SelectedItems.Add(o);
            }
        }

        // helper method to set validation error using data binding
        // in edit text box
        // we want to use data binding to show validation error using the standard mechanism
        // however the content of the RTB is not a DP (FlowDocument) so we hack the binding manually
        // using Validation provider on a dummy data binding
        // This expects the ErrorContent DP set to the error to display and
        // the parent UserControl can customize the Validation.ErrorTemplate by setting that DP appropriately
        private void SetValidationError()
        {
            // create validation error on one of the data bindings on the edit text box
            // Note that since FD is not a DP, we have to choose another existing binding
            // Should not make any difference visually to the user
            ValidationError error = new ValidationError(new DataErrorValidationRule(), EditTextBox.GetBindingExpression(RichTextBox.IsReadOnlyProperty));
            error.ErrorContent = ErrorContent;
            Validation.MarkInvalid(EditTextBox.GetBindingExpression(RichTextBox.IsReadOnlyProperty), error);
        }

        // helper method to clear validation error using data binding
        // in edit text box
        private void ClearValidationError()
        {
            // clear validation error from same binding that we set originally
            Validation.ClearInvalid(EditTextBox.GetBindingExpression(RichTextBox.IsReadOnlyProperty));
        }
        #endregion        
    }
}
