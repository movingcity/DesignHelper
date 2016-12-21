using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System;
using System.Windows.Documents;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// An extension of RichTextBox that allows only plain text input.
    /// </summary>
    public class PlainRichTextBox : RichTextBox
    {
        static PlainRichTextBox()
        {
            RegisterCommandHandlers();
        }

        static void RegisterCommandHandlers()
        {
            // Register command handlers for all rich text formatting commands.
            // We disable all commands by returning false in OnCanExecute event handler,
            // thus making this control a "plain text only" RichTextBox.
            foreach (RoutedUICommand command in formattingCommands)
            {
                CommandManager.RegisterClassCommandBinding(typeof(PlainRichTextBox),
                    new CommandBinding(command, new ExecutedRoutedEventHandler(OnFormattingCommand), 
                    new CanExecuteRoutedEventHandler(OnCanExecuteFormattingCommand)));
            }

            // Command handlers for Cut, Copy and Paste commands.
            // To enforce that data can be copied or pasted from the clipboard in text format only.
            CommandManager.RegisterClassCommandBinding(typeof(PlainRichTextBox),
                new CommandBinding(ApplicationCommands.Copy, new ExecutedRoutedEventHandler(OnCopy), 
                new CanExecuteRoutedEventHandler(OnCanExecuteCopy)));
            CommandManager.RegisterClassCommandBinding(typeof(PlainRichTextBox),
                new CommandBinding(ApplicationCommands.Paste, new ExecutedRoutedEventHandler(OnPaste), 
                new CanExecuteRoutedEventHandler(OnCanExecutePaste)));
            CommandManager.RegisterClassCommandBinding(typeof(PlainRichTextBox),
                new CommandBinding(ApplicationCommands.Cut, new ExecutedRoutedEventHandler(OnCut), 
                new CanExecuteRoutedEventHandler(OnCanExecuteCut)));
        }

        #region Event Handlers

        /// <summary>
        /// Event handler for all formatting commands.
        /// </summary>
        private static void OnFormattingCommand(object sender, ExecutedRoutedEventArgs e)
        {
            // Do nothing, and set command handled to true.
            e.Handled = true;
        }

        /// <summary>
        /// Event handler for ApplicationCommands.Copy command.
        /// <remarks>
        /// We want to enforce that data can be set on the clipboard 
        /// only in plain text format from this RichTextBox.
        /// </remarks>
        /// </summary>
        private static void OnCopy(object sender, ExecutedRoutedEventArgs e)
        {
            PlainRichTextBox myRichTextBox = (PlainRichTextBox)sender;
            string selectionText = myRichTextBox.Selection.Text;
            Clipboard.SetText(selectionText);
            e.Handled = true;
        }

        /// <summary>
        /// Event handler for ApplicationCommands.Cut command.
        /// <remarks>
        /// We want to enforce that data can be set on the clipboard 
        /// only in plain text format from this RichTextBox.
        /// </remarks>
        /// </summary>
        private static void OnCut(object sender, ExecutedRoutedEventArgs e)
        {
            PlainRichTextBox myRichTextBox = (PlainRichTextBox)sender;
            string selectionText = myRichTextBox.Selection.Text;
            myRichTextBox.Selection.Text = String.Empty;
            Clipboard.SetText(selectionText);
            e.Handled = true;
        }

        /// <summary>
        /// Event handler for ApplicationCommands.Paste command.
        /// <remarks>
        /// We want to allow paste only in plain text format.
        /// </remarks>
        /// </summary>
        private static void OnPaste(object sender, ExecutedRoutedEventArgs e)
        {
            PlainRichTextBox myRichTextBox = (PlainRichTextBox)sender;
            
            // Handle paste only if clipboard supports text format.
            if (Clipboard.ContainsText())
            {
                myRichTextBox.Selection.Text = Clipboard.GetText();
            }
            e.Handled = true;
        }

        /// <summary>
        /// CanExecute event handler.
        /// </summary>
        private static void OnCanExecuteFormattingCommand(object target, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        /// <summary>
        /// CanExecute event handler for ApplicationCommands.Copy.
        /// </summary>
        private static void OnCanExecuteCopy(object target, CanExecuteRoutedEventArgs args)
        {
            PlainRichTextBox myRichTextBox = (PlainRichTextBox)target;
            args.CanExecute = myRichTextBox.IsEnabled && !myRichTextBox.Selection.IsEmpty;
        }

        /// <summary>
        /// CanExecute event handler for ApplicationCommands.Cut.
        /// </summary>
        private static void OnCanExecuteCut(object target, CanExecuteRoutedEventArgs args)
        {
            PlainRichTextBox myRichTextBox = (PlainRichTextBox)target;
            args.CanExecute = myRichTextBox.IsEnabled && !myRichTextBox.IsReadOnly && !myRichTextBox.Selection.IsEmpty;
        }

        /// <summary>
        /// CanExecute event handler for ApplicationCommand.Paste.
        /// </summary>
        private static void OnCanExecutePaste(object target, CanExecuteRoutedEventArgs args)
        {
            PlainRichTextBox myRichTextBox = (PlainRichTextBox)target;
            args.CanExecute = myRichTextBox.IsEnabled && !myRichTextBox.IsReadOnly && Clipboard.ContainsText();
        }

        #endregion

        #region Private Members
        // Static list of editing formatting commands. In the ctor we disable all these commands.
        private static readonly RoutedUICommand[] formattingCommands = new RoutedUICommand[]
            {
                EditingCommands.ToggleBold,
                EditingCommands.ToggleItalic,
                EditingCommands.ToggleUnderline,
                EditingCommands.ToggleSubscript,
                EditingCommands.ToggleSuperscript,
                EditingCommands.IncreaseFontSize,
                EditingCommands.DecreaseFontSize,
                EditingCommands.ToggleBullets,
                EditingCommands.ToggleNumbering,
            };

        #endregion Private Members
    }
}
