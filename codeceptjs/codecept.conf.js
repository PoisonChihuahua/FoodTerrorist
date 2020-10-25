exports.config = {
  tests: './*_test.js',
  output: './output',
  helpers: {
    Puppeteer: {
      url: 'http://localhost:5000/',
      show: true
    }
  },
  include: {
    I: './steps_file.js'
  },
  bootstrap: null,
  mocha: {},
  name: 'codeceptjs',
  translation: 'ja-JP',
  plugins: {
    retryFailedStep: {
      enabled: true
    },
    screenshotOnFail: {
      enabled: true
    },
    stepByStepReport: {
      enabled: true,  // step毎のスクリーンショットを取得する
      deleteSuccessful: false,  // テスト成功時もスクリーンショットを残す
      fullPageScreenshots: true,  // スクリーンショットはフルスクリーンで取得する
    },
  }
}