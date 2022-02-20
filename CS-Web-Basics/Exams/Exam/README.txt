It should be noted that whenever POST request with invalid data are made, the Login/Register/Add pages don't refresh, but error views are displayed instead. It isn't mentioned in the problem description but it significantly improves the UX.

Also, whenever the image url contains symbols such as & or =, the model binding fails to parse it and an error message that the URL is invalid is displayed. 