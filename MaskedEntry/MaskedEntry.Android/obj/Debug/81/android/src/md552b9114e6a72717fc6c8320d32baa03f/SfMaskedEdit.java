package md552b9114e6a72717fc6c8320d32baa03f;


public class SfMaskedEdit
	extends android.widget.EditText
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getInputType:()I:GetGetInputTypeHandler\n" +
			"n_setInputType:(I)V:GetSetInputType_IHandler\n" +
			"n_getTypeface:()Landroid/graphics/Typeface;:GetGetTypefaceHandler\n" +
			"n_setTypeface:(Landroid/graphics/Typeface;)V:GetSetTypeface_Landroid_graphics_Typeface_Handler\n" +
			"n_setTextSize:(IF)V:GetSetTextSize_IFHandler\n" +
			"n_setTypeface:(Landroid/graphics/Typeface;I)V:GetSetTypeface_Landroid_graphics_Typeface_IHandler\n" +
			"n_onTextContextMenuItem:(I)Z:GetOnTextContextMenuItem_IHandler\n" +
			"n_onAttachedToWindow:()V:GetOnAttachedToWindowHandler\n" +
			"n_onDetachedFromWindow:()V:GetOnDetachedFromWindowHandler\n" +
			"n_onFocusChanged:(ZILandroid/graphics/Rect;)V:GetOnFocusChanged_ZILandroid_graphics_Rect_Handler\n" +
			"n_onSelectionChanged:(II)V:GetOnSelectionChanged_IIHandler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.Android.MaskedEdit.SfMaskedEdit, Syncfusion.SfMaskedEdit.XForms.Android", SfMaskedEdit.class, __md_methods);
	}


	public SfMaskedEdit (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SfMaskedEdit.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.MaskedEdit.SfMaskedEdit, Syncfusion.SfMaskedEdit.XForms.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SfMaskedEdit (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SfMaskedEdit.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.MaskedEdit.SfMaskedEdit, Syncfusion.SfMaskedEdit.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SfMaskedEdit (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SfMaskedEdit.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.MaskedEdit.SfMaskedEdit, Syncfusion.SfMaskedEdit.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SfMaskedEdit (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == SfMaskedEdit.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.MaskedEdit.SfMaskedEdit, Syncfusion.SfMaskedEdit.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public int getInputType ()
	{
		return n_getInputType ();
	}

	private native int n_getInputType ();


	public void setInputType (int p0)
	{
		n_setInputType (p0);
	}

	private native void n_setInputType (int p0);


	public android.graphics.Typeface getTypeface ()
	{
		return n_getTypeface ();
	}

	private native android.graphics.Typeface n_getTypeface ();


	public void setTypeface (android.graphics.Typeface p0)
	{
		n_setTypeface (p0);
	}

	private native void n_setTypeface (android.graphics.Typeface p0);


	public void setTextSize (int p0, float p1)
	{
		n_setTextSize (p0, p1);
	}

	private native void n_setTextSize (int p0, float p1);


	public void setTypeface (android.graphics.Typeface p0, int p1)
	{
		n_setTypeface (p0, p1);
	}

	private native void n_setTypeface (android.graphics.Typeface p0, int p1);


	public boolean onTextContextMenuItem (int p0)
	{
		return n_onTextContextMenuItem (p0);
	}

	private native boolean n_onTextContextMenuItem (int p0);


	public void onAttachedToWindow ()
	{
		n_onAttachedToWindow ();
	}

	private native void n_onAttachedToWindow ();


	public void onDetachedFromWindow ()
	{
		n_onDetachedFromWindow ();
	}

	private native void n_onDetachedFromWindow ();


	public void onFocusChanged (boolean p0, int p1, android.graphics.Rect p2)
	{
		n_onFocusChanged (p0, p1, p2);
	}

	private native void n_onFocusChanged (boolean p0, int p1, android.graphics.Rect p2);


	public void onSelectionChanged (int p0, int p1)
	{
		n_onSelectionChanged (p0, p1);
	}

	private native void n_onSelectionChanged (int p0, int p1);

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
