using UnityEngine;
using System.Collections;

public class ApplicationData {
	public static IList wishList = new ArrayList();

	public static void addToWishList(string item) {
		wishList.Add(item);
	}

	public static IList getWishList() {
		return wishList;
	}
}
