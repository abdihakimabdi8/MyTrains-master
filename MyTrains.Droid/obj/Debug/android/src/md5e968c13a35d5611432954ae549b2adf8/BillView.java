package md5e968c13a35d5611432954ae549b2adf8;


public class BillView
	extends md5c293e307133ee8f46151deed2480c6a8.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MyTrains.Droid.Views.BillView, MyTrains.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BillView.class, __md_methods);
	}


	public BillView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == BillView.class)
			mono.android.TypeManager.Activate ("MyTrains.Droid.Views.BillView, MyTrains.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
