using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Markup; // IAddChild, ContentPropertyAttribute

namespace Microsoft._3DTools
{
    /// <summary>
    /// This class enables a Viewport3D to be enhanced by allowing UIElements to be placed 
    /// behind and in front of the Viewport3D.  These can then be used for various enhancements.  
    /// For examples see the Trackball, or InteractiveViewport3D.
    /// </summary>
    [ContentProperty("Content")]    
    public abstract class Viewport3DDecorator : FrameworkElement, IAddChild
    {
        /// <summary>
        /// Creates the Viewport3DDecorator
        /// </summary>
        public Viewport3DDecorator()
        {
            // create the two lists of children
            _preViewportChildren = new UIElementCollection(this, this);
            _postViewportChildren = new UIElementCollection(this, this);
                    
            // no content yet
            _content = null;
        }           

        /// <summary>
        /// The content/child of the Viewport3DDecorator.  A Viewport3DDecorator only has one
        /// child and this child must be either another Viewport3DDecorator or a Viewport3D.
        /// </summary>
        public UIElement Content
        {
            get
            {
                return _content;
            }

            set
            {
                // check to make sure it is a Viewport3D or a Viewport3DDecorator                
                if (!(value is Viewport3D || value is Viewport3DDecorator))
                {
                    throw new ArgumentException("Not a valid child type", "value");
                }            
                
                // check to make sure we're attempting to set something new
                if (_content != value)
                {
                    UIElement oldContent = _content;
                    UIElement newContent = value;                    
                    
                    // remove the previous child
                    RemoveVisualChild(oldContent);
                    RemoveLogicalChild(oldContent);
                    
                    // set the private variable
                    _content = value;

                    // link in the new child
                    AddLogicalChild(newContent);
                    AddVisualChild(newContent);

                    // let anyone know that derives from us that there was a change
                    OnViewport3DDecoratorContentChange(oldContent, newContent);

                    // data bind to what is below us so that we have the same width/height
                    // as the Viewport3D being enhanced
                    // create the bindings now for use later
                    BindToContentsWidthHeight(newContent);
                                      
                    // Invalidate measure to indicate a layout update may be necessary
                    InvalidateMeasure();
                }
            }
        }

        /// <summary>
        /// Data binds the (Max/Min)Width and (Max/Min)Height properties to the same
        /// ones as the content.  This will make it so we end up being sized to be
        /// exactly the same ActualWidth and ActualHeight as waht is below us.
        /// </summary>
        /// <param name="newContent">What to bind to</param>
        private void BindToContentsWidthHeight(UIElement newContent)
        {
            // bind to width height
            Binding _widthBinding = new Binding("Width");
            _widthBinding.Mode = BindingMode.OneWay;
            Binding _heightBinding = new Binding("Height");
            _heightBinding.Mode = BindingMode.OneWay;

            _widthBinding.Source = newContent;
            _heightBinding.Source = newContent;

            BindingOperations.SetBinding(this, WidthProperty, _widthBinding);
            BindingOperations.SetBinding(this, HeightProperty, _heightBinding);

            
            // bind to max width and max height
            Binding _maxWidthBinding = new Binding("MaxWidth");
            _maxWidthBinding.Mode = BindingMode.OneWay;
            Binding _maxHeightBinding = new Binding("MaxHeight");
            _maxHeightBinding.Mode = BindingMode.OneWay;

            _maxWidthBinding.Source = newContent;
            _maxHeightBinding.Source = newContent;

            BindingOperations.SetBinding(this, MaxWidthProperty, _maxWidthBinding);
            BindingOperations.SetBinding(this, MaxHeightProperty, _maxHeightBinding);

            
            // bind to min width and min height
            Binding _minWidthBinding = new Binding("MinWidth");
            _minWidthBinding.Mode = BindingMode.OneWay;
            Binding _minHeightBinding = new Binding("MinHeight");
            _minHeightBinding.Mode = BindingMode.OneWay;

            _minWidthBinding.Source = newContent;
            _minHeightBinding.Source = newContent;

            BindingOperations.SetBinding(this, MinWidthProperty, _minWidthBinding);
            BindingOperations.SetBinding(this, MinHeightProperty, _minHeightBinding);            
        }

        /// <summary>
        /// Extenders of Viewport3DDecorator can override this function to be notified
        /// when the Content property changes
        /// </summary>
        /// <param name="oldContent">The old value of the Content property</param>
        /// <param name="newContent">The new value of the Content property</param>
        protected virtual void OnViewport3DDecoratorContentChange(UIElement oldContent, UIElement newContent)
        {
        }

        /// <summary>
        /// Property to get the Viewport3D that is being enhanced.
        /// </summary>
        public Viewport3D Viewport3D
        {
            get
            {
                Viewport3D viewport3D = null;
                Viewport3DDecorator currEnhancer = this;

                // we follow the enhancers down until we get the
                // Viewport3D they are enhancing
                while (true)
                {
                    UIElement currContent = currEnhancer.Content;

                    if (currContent == null)
                    {
                        break;
                    }
                    else if (currContent is Viewport3D)
                    {
                        viewport3D = (Viewport3D)currContent;
                        break;
                    }
                    else
                    {
                        currEnhancer = (Viewport3DDecorator)currContent;
                    }                    
                }

                return viewport3D;
            }
        }        

        /// <summary>
        /// The UIElements that occur before the Viewport3D
        /// </summary>
        protected UIElementCollection PreViewportChildren
        {
            get
            {
                return _preViewportChildren;
            }
        }

        /// <summary>
        /// The UIElements that occur after the Viewport3D
        /// </summary>
        protected UIElementCollection PostViewportChildren
        {
            get
            {
                return _postViewportChildren;
            }
        }
       
        /// <summary>
        /// Returns the number of Visual children this element has.
        /// </summary>
        protected override int VisualChildrenCount
        {
            get 
            {
                int contentCount = (Content == null ? 0 : 1);

                return PreViewportChildren.Count +
                       PostViewportChildren.Count + 
                       contentCount; 
            }
        }

        /// <summary>
        /// Returns the child at the specified index.
        /// </summary>
        protected override Visual GetVisualChild(int index)
        {
            int orginalIndex = index;

            // see if index is in the pre viewport children
            if (index < PreViewportChildren.Count)
            {
                return PreViewportChildren[index];
            }
            index -= PreViewportChildren.Count;

            // see if it's the content
            if (Content != null && index == 0)
            {
                return Content;
            }
            index -= (Content == null ? 0 : 1);

            // see if it's the post viewport children
            if (index < PostViewportChildren.Count)
            {
                return PostViewportChildren[index];
            }

            // if we didn't return then the index is out of range - throw an error
            throw new ArgumentOutOfRangeException("index", orginalIndex, "Out of range visual requested");
        }

        /// <summary> 
        /// Returns an enumertor to this element's logical children
        /// </summary>
        protected override IEnumerator LogicalChildren
        {
            get
            {
                Visual[] logicalChildren = new Visual[VisualChildrenCount];

                for (int i = 0; i < VisualChildrenCount; i++)
                {
                    logicalChildren[i] = GetVisualChild(i);
                }

                // return an enumerator to the ArrayList
                return logicalChildren.GetEnumerator();
            }
        }

        /// <summary>
        /// Updates the DesiredSize of the Viewport3DDecorator
        /// </summary>
        /// <param name="constraint">The "upper limit" that the return value should not exceed</param>
        /// <returns>The desired size of the Viewport3DDecorator</returns>
        protected override Size MeasureOverride(Size constraint)
        {
            Size finalSize = new Size();    

            MeasurePreViewportChildren(constraint);

            // measure our Viewport3D(Enhancer)
            if (Content != null)
            {
                Content.Measure(constraint);
                finalSize = Content.DesiredSize;
            }

            MeasurePostViewportChildren(constraint);

            return finalSize;
        }

        /// <summary>
        /// Measures the size of all the PreViewportChildren.  If special measuring behavior is needed, this
        /// method should be overridden.
        /// </summary>
        /// <param name="constraint">The "upper limit" on the size of an element</param>
        protected virtual void MeasurePreViewportChildren(Size constraint)
        {
            // measure the pre viewport children
            MeasureUIElementCollection(PreViewportChildren, constraint);
        }

        /// <summary>
        /// Measures the size of all the PostViewportChildren.  If special measuring behavior is needed, this
        /// method should be overridden.
        /// </summary>
        /// <param name="constraint">The "upper limit" on the size of an element</param>
        protected virtual void MeasurePostViewportChildren(Size constraint)
        {
            // measure the post viewport children
            MeasureUIElementCollection(PostViewportChildren, constraint);
        }

        /// <summary>
        /// Measures all of the UIElements in a UIElementCollection
        /// </summary>
        /// <param name="collection">The collection to measure</param>
        /// <param name="constraint">The "upper limit" on the size of an element</param>
        private void MeasureUIElementCollection(UIElementCollection collection, Size constraint)
        {
            // measure the pre viewport visual visuals
            foreach (UIElement uiElem in collection)
            {
                uiElem.Measure(constraint);
            }
        }
        
        /// <summary>
        /// Arranges the Pre and Post Viewport children, and arranges itself
        /// </summary>
        /// <param name="arrangeSize">The final size to use to arrange itself and its children</param>
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            ArrangePreViewportChildren(arrangeSize);

            // arrange our Viewport3D(Enhancer)
            if (Content != null)
            {
                Content.Arrange(new Rect(arrangeSize));
            }

            ArrangePostViewportChildren(arrangeSize);

            return arrangeSize;
        }

        /// <summary>
        /// Arranges all the PreViewportChildren.  If special measuring behavior is needed, this
        /// method should be overridden.
        /// </summary>
        /// <param name="arrangeSize">The final size to use to arrange each child</param>
        protected virtual void ArrangePreViewportChildren(Size arrangeSize)
        {
            ArrangeUIElementCollection(PreViewportChildren, arrangeSize);
        }

        /// <summary>
        /// Arranges all the PostViewportChildren.  If special measuring behavior is needed, this
        /// method should be overridden.
        /// </summary>
        /// <param name="arrangeSize">The final size to use to arrange each child</param>
        protected virtual void ArrangePostViewportChildren(Size arrangeSize)
        {
            ArrangeUIElementCollection(PostViewportChildren, arrangeSize);
        }

        /// <summary>
        /// Arranges all the UIElements in the passed in UIElementCollection
        /// </summary>
        /// <param name="collection">The collection that should be arranged</param>
        /// <param name="constraint">The final size that element should use to arrange itself and its children</param>
        private void ArrangeUIElementCollection(UIElementCollection collection, Size constraint)
        {
            // measure the pre viewport visual visuals
            foreach (UIElement uiElem in collection)
            {
                uiElem.Arrange(new Rect(constraint));
            }
        }

        //------------------------------------------------------
        //
        //  IAddChild implementation
        //
        //------------------------------------------------------

        void IAddChild.AddChild(Object value)
        {
            // check against null
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            // we only can have one child
            if (this.Content != null)
            {
                throw new ArgumentException("Viewport3DDecorator can only have one child");
            }

            // now we can actually set the content
            Content = (UIElement)value;
        }

        void IAddChild.AddText(string text)
        {
            // The only text we accept is whitespace, which we ignore.
            for (int i = 0; i < text.Length; i++)
            {
                if (!Char.IsWhiteSpace(text[i]))
                {
                    throw new ArgumentException("Non whitespace in add text", text);
                }
            }
        }

        //---------------------------------------------------------
        // 
        //  Private data
        //
        //---------------------------------------------------------        
        private UIElementCollection _preViewportChildren;
        private UIElementCollection _postViewportChildren;
        private UIElement _content;
    }
}

