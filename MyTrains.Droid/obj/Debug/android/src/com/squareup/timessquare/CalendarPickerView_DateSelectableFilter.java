package com.squareup.timessquare;


public abstract class CalendarPickerView_DateSelectableFilter
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.squareup.timessquare.CalendarPickerView.DateSelectableFilter
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_isDateSelectable:(Ljava/util/Date;)Z:GetIsDateSelectable_Ljava_util_Date_Handler:Square.TimesSquare.CalendarPickerView/IDateSelectableFilterInvoker, Square.AndroidTimesSquare\n" +
			"";
		mono.android.Runtime.register ("Square.TimesSquare.CalendarPickerView+DateSelectableFilter, Square.AndroidTimesSquare, Version=1.6.5.0, Culture=neutral, PublicKeyToken=null", CalendarPickerView_DateSelectableFilter.class, __md_methods);
	}


	public CalendarPickerView_DateSelectableFilter ()
	{
		super ();
		if (getClass () == CalendarPickerView_DateSelectableFilter.class)
			mono.android.TypeManager.Activate ("Square.TimesSquare.CalendarPickerView+DateSelectableFilter, Square.AndroidTimesSquare, Version=1.6.5.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean isDateSelectable (java.util.Date p0)
	{
		return n_isDateSelectable (p0);
	}

	private native boolean n_isDateSelectable (java.util.Date p0);

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
