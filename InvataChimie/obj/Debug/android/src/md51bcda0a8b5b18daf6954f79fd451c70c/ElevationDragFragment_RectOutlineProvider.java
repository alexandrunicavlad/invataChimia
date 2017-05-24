package md51bcda0a8b5b18daf6954f79fd451c70c;


public class ElevationDragFragment_RectOutlineProvider
	extends android.view.ViewOutlineProvider
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getOutline:(Landroid/view/View;Landroid/graphics/Outline;)V:GetGetOutline_Landroid_view_View_Landroid_graphics_Outline_Handler\n" +
			"";
		mono.android.Runtime.register ("InvataChimie.ElevationDragFragment+RectOutlineProvider, InvataChimie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ElevationDragFragment_RectOutlineProvider.class, __md_methods);
	}


	public ElevationDragFragment_RectOutlineProvider () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ElevationDragFragment_RectOutlineProvider.class)
			mono.android.TypeManager.Activate ("InvataChimie.ElevationDragFragment+RectOutlineProvider, InvataChimie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void getOutline (android.view.View p0, android.graphics.Outline p1)
	{
		n_getOutline (p0, p1);
	}

	private native void n_getOutline (android.view.View p0, android.graphics.Outline p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
