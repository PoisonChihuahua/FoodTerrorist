/// <reference types='codeceptjs' />
type steps_file = typeof import('./steps_file.js');

declare namespace CodeceptJS {
  interface SupportObject { I: CodeceptJS.I }
  interface CallbackOrder { [0]: CodeceptJS.I }
  interface Methods extends CodeceptJS.Puppeteer {}
  interface I extends ReturnType<steps_file> {}
  namespace Translation {
    interface Actions {
  "amOutsideAngularApp": "Angularの外に出る",
  "amInsideAngularApp": "Angularの中に入る",
  "waitForElement": "要素を待つ",
  "waitForClickable": "クリック可能になるまで待つ",
  "waitForVisible": "要素が見えるようになるまで待つ",
  "waitForText": "テキストが表示されるまで待つ",
  "moveTo": "移動する",
  "refresh": "更新する",
  "haveModule": "モジュールを持っている",
  "resetModule": "モジュールをリセットする",
  "amOnPage": "ページを移動する",
  "click": "クリックする",
  "doubleClick": "ダブルクリックする",
  "see": "テキストがあるか確認する",
  "dontSee": "テキストがないことを確認する",
  "selectOption": "オプションを選ぶ",
  "fillField": "フィールドに入力する",
  "pressKey": "キー入力する",
  "triggerMouseEvent": "マウスイベントを発火させる",
  "attachFile": "ファイルを添付する",
  "seeInField": "フィールドに文字が入っているか確認する",
  "dontSeeInField": "フィールドに文字が入っていないか確認する",
  "appendField": "フィールドに文字を追加する",
  "checkOption": "オプションをチェックする",
  "seeCheckboxIsChecked": "チェックされているか確認する",
  "dontSeeCheckboxIsChecked": "チェックされていないことを確認する",
  "grabTextFrom": "テキストを取得する",
  "grabValueFrom": "入力値を取得する",
  "grabAttributeFrom": "要素を取得する",
  "seeInTitle": "タイトルに文字が含まれるか確認する",
  "dontSeeInTitle": "タイトルに文字が含まれないことを確認する",
  "grabTitle": "タイトルを取得する",
  "seeElement": "要素があるか確認する",
  "dontSeeElement": "要素がないことを確認する",
  "seeInSource": "ソースにあるか確認する",
  "dontSeeInSource": "ソースにないことを確認する",
  "executeScript": "スクリプトを実行する",
  "executeAsyncScript": "非同期スクリプトを実行する",
  "seeInCurrentUrl": "URLに含まれるか確認する",
  "dontSeeInCurrentUrl": "URLに含まれないことを確認する",
  "seeCurrentUrlEquals": "URLが等しいか確認する",
  "dontSeeCurrentUrlEquals": "URLが等しくないことを確認する",
  "saveScreenshot": "スクリーンショットを保存する",
  "setCookie": "Cookieをセットする",
  "clearCookie": "Cookieをクリアする",
  "seeCookie": "Cookieに含まれることを確認する",
  "dontSeeCookie": "Cookieに含まれないことを確認する",
  "grabCookie": "Cookieを取得する",
  "resizeWindow": "ウィンドウをリサイズする",
  "wait": "待つ"
}
  }
}
