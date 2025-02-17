using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace AVMHomeAutomationDemo.Controls
{
    public class SelectableTreeView : TreeView
    {
        //public SelectableTreeView() : base()
        //{
        //    this.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(___ICH);
        //}

        //void ___ICH(object sender, RoutedPropertyChangedEventArgs<object> e)
        //{
        //    if (SelectedItem != null)
        //    {
        //        SetValue(SelectedItem_Property, SelectedItem);
        //    }
        //}

        //public object SelectedItem_
        //{
        //    get { return (object)GetValue(SelectedItem_Property); }
        //    set { SetValue(SelectedItem_Property, value); }
        //}
        //public static readonly DependencyProperty SelectedItem_Property = DependencyProperty.Register("SelectedItem_", typeof(object), typeof(SelectableTreeView), new UIPropertyMetadata(null));



        /*
        
      	SelectedItemPropertyKey = DependencyProperty.RegisterReadOnly("SelectedItem", typeof(object), typeof(TreeView), new FrameworkPropertyMetadata((object)null));
		SelectedItemProperty = SelectedItemPropertyKey.DependencyProperty;
	 
        SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(Selector), 
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged, CoerceSelectedItem));

        */

        //static SelectableTreeView()
        //{
        //    //SelectedItemProperty.OverrideMetadata(typeof(SelectableTreeView),
        //    //    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged));

        //    //SelectedItemProperty
        //}

        protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedItem = e.NewValue;
            base.OnSelectedItemChanged(e);
        }

        public new static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(SelectableTreeView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged)); 
        
        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as SelectableTreeView)?.OnSelectedItemChanged(e.NewValue, e.OldValue);
        }

        private void OnSelectedItemChanged(object newValue, object oldValue)
        {
            var tvi = this.ItemContainerGenerator.ContainerFromItem(newValue) as TreeViewItem;
            if (tvi != null)
            {
                tvi.IsSelected = true;
            }
        }

        public new object SelectedItem
        {
            get
            {
                return GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }
    }
}

