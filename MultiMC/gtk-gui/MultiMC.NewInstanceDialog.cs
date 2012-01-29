
// This file has been generated by the GUI designer. Do not modify.
namespace MultiMC
{
	public partial class NewInstanceDialog
	{
		private global::Gtk.VBox vboxNewInst;
		private global::Gtk.HBox hboxTextArea;
		private global::Gtk.Label labelNewInstName;
		private global::Gtk.Entry instNameEntry;
		private global::Gtk.Button buttonCancel;
		private global::Gtk.Button buttonOk;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MultiMC.NewInstanceDialog
			this.Name = "MultiMC.NewInstanceDialog";
			this.Title = global::Mono.Unix.Catalog.GetString ("New instance");
			this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.Menu);
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			this.AllowShrink = true;
			// Internal child MultiMC.NewInstanceDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vboxNewInst = new global::Gtk.VBox ();
			this.vboxNewInst.Name = "vboxNewInst";
			this.vboxNewInst.Spacing = 6;
			this.vboxNewInst.BorderWidth = ((uint)(6));
			// Container child vboxNewInst.Gtk.Box+BoxChild
			this.hboxTextArea = new global::Gtk.HBox ();
			this.hboxTextArea.Name = "hboxTextArea";
			this.hboxTextArea.Spacing = 6;
			// Container child hboxTextArea.Gtk.Box+BoxChild
			this.labelNewInstName = new global::Gtk.Label ();
			this.labelNewInstName.Name = "labelNewInstName";
			this.labelNewInstName.LabelProp = global::Mono.Unix.Catalog.GetString ("_New instance name:");
			this.labelNewInstName.UseUnderline = true;
			this.hboxTextArea.Add (this.labelNewInstName);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hboxTextArea [this.labelNewInstName]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hboxTextArea.Gtk.Box+BoxChild
			this.instNameEntry = new global::Gtk.Entry ();
			this.instNameEntry.CanFocus = true;
			this.instNameEntry.Name = "instNameEntry";
			this.instNameEntry.IsEditable = true;
			this.instNameEntry.InvisibleChar = '●';
			this.hboxTextArea.Add (this.instNameEntry);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hboxTextArea [this.instNameEntry]));
			w3.Position = 1;
			this.vboxNewInst.Add (this.hboxTextArea);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vboxNewInst [this.hboxTextArea]));
			w4.Position = 0;
			w1.Add (this.vboxNewInst);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(w1 [this.vboxNewInst]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Internal child MultiMC.NewInstanceDialog.ActionArea
			global::Gtk.HButtonBox w6 = this.ActionArea;
			w6.Name = "dialog1_ActionArea";
			w6.Spacing = 10;
			w6.BorderWidth = ((uint)(5));
			w6.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w7 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w6 [this.buttonCancel]));
			w7.Expand = false;
			w7.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w8 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w6 [this.buttonOk]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 116;
			this.Show ();
			this.instNameEntry.Activated += new global::System.EventHandler (this.OnInstNameEntryActivated);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnCancelClicked);
			this.buttonOk.Clicked += new global::System.EventHandler (this.OnOKClicked);
		}
	}
}