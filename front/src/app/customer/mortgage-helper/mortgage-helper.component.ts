import { Component } from '@angular/core';

@Component({
  selector: 'mortgage-helper',
  templateUrl: './mortgage-helper.component.html',
  styleUrl: './mortgage-helper.component.css'
})
export class MortgageHelperComponent {

   tips = [
    {
      title: 'החזר חודשי ',
      description: `ההחזר החודשי הוא הסכום שאתה משלם למלווה בכל חודש עבור ההלוואה שלך, והוא כולל את הקרן (הסכום הראשוני שלקחת בהלוואה) ואת הריבית שנצברה על הקרן. 🏦 חשוב לחשב את ההחזר החודשי מראש ולוודא שהוא תואם ליכולת הכלכלית שלך. תשלום חודשי גבוה מדי עלול להכביד על התקציב החודשי שלך ולפגוע ביציבות הכלכלית. תכנון נכון יכול לסייע לך להימנע מעומסים כלכליים ולהבטיח שהחזרי ההלוואה לא יהפכו למעמסה בלתי נסבלת. 📈`
    },
    {
      title: 'ריבית קבועה ',
      description: `ריבית קבועה היא שיעור ריבית שנשאר קבוע לאורך כל תקופת ההלוואה. 🌟 היתרון של ריבית קבועה הוא שהיא מספקת יציבות וביטחון, מכיוון שההחזרים החודשיים שלך לא משתנים, גם אם שוק הריבית משתנה. זה מאפשר לך לתכנן את התקציב החודשי בצורה מדויקת ולקבל תמונה ברורה של ההוצאות העתידיות. 🔒 עם זאת, לעיתים הריבית הקבועה תהיה גבוהה יותר מההתחלה בהשוואה לריבית משתנה, אך היא מציעה הגנה מפני עליות פתאומיות בריבית. 🛡️`
    },
    {
      title: 'ריבית משתנה ',
      description: `ריבית משתנה היא שיעור ריבית שמותאם לשינויים בשוק הריבית. 💹 זה אומר שהריבית שלך יכולה להשתנות לאורך תקופת ההלוואה, בהתאם לשיעור הריבית הכללי בשוק. בתחילת התקופה, הריבית המשתנה עשויה להיות נמוכה יותר מריבית קבועה, מה שיכול להוביל להחזר חודשי נמוך יותר. 💡 עם זאת, יש לקחת בחשבון את הסיכון לכך שהריבית עשויה לעלות בעתיד, מה שיוביל לעלייה בהחזר החודשי. זו אפשרות שמתאימה למי שמוכן להתמודד עם השינויים האפשריים בריבית. 📉`
    },
    {
      title: 'תקופת הלוואה ',
      description: `תקופת ההלוואה היא פרק הזמן שבו אתה נדרש להחזיר את ההלוואה שלך. ⏳ תקופות הלוואה ארוכות יותר מקטינות את ההחזר החודשי מכיוון שאתה פורש את התשלומים על פני יותר זמן, אבל בסופו של דבר, אתה עשוי לשלם יותר ריבית. 🧮 מצד שני, תקופות הלוואה קצרות יותר מובילות להחזר חודשי גבוה יותר אך מאפשרות לך לשלם פחות ריבית בסך הכל. חשוב לבחור תקופת הלוואה שמתאימה ליכולת הכלכלית שלך וליעדים הפיננסיים שלך. 🎯`
    },
    {
      title: 'ערך הנכס ',
      description: `ערך הנכס הוא המחיר הנוכחי של הנכס שלך, והוא נקבע על פי הערכת שווי או מכירות דומות בשוק. 🏡 ערך הנכס משפיע על סכום ההלוואה שאתה יכול לקבל ועל שיעור הריבית שתשלם. המלווה בודק את ערך הנכס כדי להעריך את הסיכון שלו ולוודא שהלוואה מתאימה למצב הכלכלי שלך. 📏 עדכון קבוע של ערך הנכס שלך חשוב כדי להבטיח שאתה מקבל את ההצעות הטובות ביותר מהמלווה. זה גם מאפשר לך להבין את עמדתך הפיננסית ולהתמודד בצורה טובה יותר עם שינויים בשוק. 💼`
    },
    {
      title: 'יחס חוב להכנסה ',
      description: `יחס חוב להכנסה הוא מדד פיננסי שמחשב את החזר ההלוואה החודשי שלך ביחס להכנסה החודשית שלך. 📊 הוא מסייע להעריך את יציבותך הכלכלית ומצביע על כמות מהכנסתך המוקדשת להחזר הלוואות. יחס חוב להכנסה נמוך מצביע על יציבות פיננסית גבוהה יותר ומפחית את הסיכון לאי יכולת להחזיר את ההלוואות בעתיד. 💪 המטרה היא לשמור על יחס נמוך כדי להבטיח שאתה לא לוקח על עצמך יותר מדי חוב ביחס להכנסותיך, וכך לשמור על יציבות כלכלית וביטחון פיננסי. 🛡️`
    }
  ];
   
}
