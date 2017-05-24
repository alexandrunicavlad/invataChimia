package md51bcda0a8b5b18daf6954f79fd451c70c;


public class Callbacks
	extends android.support.v4.widget.ViewDragHelper.Callback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_tryCaptureView:(Landroid/view/View;I)Z:GetTryCaptureView_Landroid_view_View_IHandler\n" +
			"n_onViewPositionChanged:(Landroid/view/View;IIII)V:GetOnViewPositionChanged_Landroid_view_View_IIIIHandler\n" +
			"n_clampViewPositionHorizontal:(Landroid/view/View;II)I:GetClampViewPositionHorizontal_Landroid_view_View_IIHandler\n" +
			"n_clampViewPositionVertical:(Landroid/view/View;II)I:GetClampViewPositionVertical_Landroid_view_View_IIHandler\n" +
			"n_onViewCaptured:(Landroid/view/View;I)V:GetOnViewCaptured_Landroid_view_View_IHandler\n" +
			"";
		mono.android.Runtime.register ("InvataChimie.Callbacks, InvataChimie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Callbacks.class, __md_methods);
	}


	public Callbacks () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Callbacks.class)
			mono.android.TypeManager.Activate ("InvataChimie.Callbacks, InvataChimie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public Callbacks (md51bcda0a8b5b18daf6954f79fd451c70c.DragFrameLayout p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == Callbacks.class)
			mono.android.TypeManager.Activate ("InvataChimie.Callbacks, InvataChimie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "InvataChimie.DragFrameLayout, InvataChimie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public boolean tryCaptureView (android.view.View p0, int p1)
	{
		return n_tryCaptureView (p0, p1);
	}

	private native boolean n_tryCaptureView (android.view.View p0, int p1);


	public void onViewPositionChanged (android.view.View p0, int p1, int p2, int p3, int p4)
	{
		n_onViewPositionChanged (p0, p1, p2, p3, p4);
	}

	private native void n_onViewPositionChanged (android.view.View p0, int p1, int p2, int p3, int p4);


	public int clampViewPositionHorizontal (android.view.View p0, int p1, int p2)
	{
		return n_clampViewPositionHorizontal (p0, p1, p2);
	}

	private native int n_clampViewPositionHorizontal (android.view.View p0, int p1, int p2);


	public int clampViewPositionVertical (android.view.View p0, int p1, int p2)
	{
		return n_clampViewPositionVertical (p0, p1, p2);
	}

	private native int n_clampViewPositionVertical (android.view.View p0, int p1, int p2);


	public void onViewCaptured (android.view.View p0, int p1)
	{
		n_onViewCaptured (p0, p1);
	}

	private native void n_onViewCaptured (android.view.View p0, int p1);

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
