# מטלה 7 - [לחץ כאן כדי לשחק](https://gamedevrel2024shovhalyon.itch.io/build-3d-world)
## הסבר כללי
במטלה זו לקחנו את [המשחק של אראל](https://github.com/gamedev-at-ariel/06-3d-terrain-ai) שהוא בנה בשיעור והוספנו לו:
1) חדר שינה.
2) שני נשקים לשחקן.
3) אפשרות לקפוץ.
4) אפשרות לרוץ.  
5) אפשרות להרוג את האוייבים.

ההליכה מתבצעת באמצעות מקשי המקלדת WASD.  
לחדר ניתן להגיע מדלת נפתחת בקומת ההתחלה או באמצעות מערכת המדרגות שיוצאת החוצה ממאוחרי המתקן.  
ניתן להחליף בין הנשקים באמצעות המקש Q.  
קפיצה מתבצעת באמצעות מקש הרווח.  
ריצה מתבצעת באמצעות מקש SHIFT.  
ניתן לכוון את הנשק עם העכבר ולעקוב אחר מיקום הכוונת בעזרת סימן ה"+" במרכז המסך.  
## הסברים על הקוד

את [הקוד של התנועה והקפיצה](https://github.com/gameDevCourse24/Week7-Build3DWorld/blob/main/Assets/Scripts/1-player/CharacterKeyboardMover.cs) לקחנו מאראל והוספנו אפשרות קפיצה באמצעות הרווח, ואפשרות ריצה באמצעות מקש השיפט.  
**ריצה:**  
יש משתנים שמחזיקים מהירות הליכה, מהירות ריצה, ומהירות נוכחית. בעצם מהירות נוכחית זה תכלס המהירות שבה השחקן יזוז, ,בלחיצה על כפתור השיפט המשתנה של המהירות הנוכחית ישתנה להיות הערך של מהירות ריצה.  
**קפיצה:**  
יש משתנה עבור תנועה אופקית (על הקרקע) ומשתנה עבור תנועה אנכית ועוד משתנה שמגיע בסוף שתכלס על פיו נקבעת התנועה שמשקלל את שניהם.  
המשתנה של התנועה האנכית פועל כאשר אנחנו לא על הקרקע ובעצם גורם לשחקן ליפול בעזרת כח הכבידה. קפיצה יכולה לעבוד רק כאשר השחקן על הקרקע.  
ואז יש חישוב מתמטי שאומר לנו מה המהירות הנדרשת על ציר הY לכיוון למעלה כדי להגיע לגובה שהגדרנו בinspector.  
ובסוף עושים חישוב של הסכום שלהם והשחקן זז לשם באמצעות פונקציית הmove של הCharacterController.  

ירי מתבצע באמצעות לחיצה על העכבר ([החזרת הסמן](https://github.com/gameDevCourse24/Week7-Build3DWorld/blob/main/Assets/Scripts/1-player/CursorHider.cs) מתבצעת באמצעות כפתור esc). יש פשוט spawner שמוציא חפצים במהירות שהגדרת, לכיוון מרכז המסך (שם תמיד נמצא העכבר) ואמצעות raycast.  
החלפת נשק מתבצעת באמצעות האות Q, כתבנו [סקריפט](https://github.com/gameDevCourse24/Week7-Build3DWorld/blob/main/Assets/Scripts/3-objects/Weapons%20Scripts/WeaponsClickSwitch.cs) שמחליף בין שני פרטים באמצעות כפתור.  
הריגת אוייב מתבצעת באמצעות [סקריפט](https://github.com/gameDevCourse24/Week7-Build3DWorld/blob/main/Assets/Scripts/Destroy%20Object%20Scripts/DeleteObjectByCollisionWithTag.cs) שהורס את האובייקט שהוא נמצא עליו ברגע של מגע עם אחד מהתאגים ברשימה (שניתן לערוך אותה מהinspector).  
הכדור מושמד אוטומטי באמצעות [סקריפט](https://github.com/gameDevCourse24/Week7-Build3DWorld/blob/main/Assets/Scripts/Destroy%20Object%20Scripts/DeleteObjectByTime.cs) לאחר כמות השניות שהגדרת בinspector.
יש [סקריפט](https://github.com/gameDevCourse24/Week7-Build3DWorld/blob/main/Assets/Scripts/GameManagerAndTesting/CollisionAndTriggerChack.cs) כללי (שנכון לעכשיו מוצמד לקליע) שבודק במי האובייקט פגע וכותב הודעה ללוג.  

את סימן ה+ במסך עשינו באמצעות פאנל, ויש [סקריפ](https://github.com/gameDevCourse24/Week7-Build3DWorld/blob/main/Assets/Scripts/3-objects/Weapons%20Scripts/CrosPanelToShow.cs) שמקשר בין הפאנל לבין הנשק המתאים, והפאנל מוחלף ברגע שהחלפתי נשקים.



