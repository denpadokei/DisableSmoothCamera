# DisableSmoothCamera

[![Build and Release](https://github.com/denpadokei/DisableSmoothCamera/actions/workflows/build-and-release.yml/badge.svg)](https://github.com/denpadokei/DisableSmoothCamera/actions/workflows/build-and-release.yml)

SmoothCamera を常に無効の状態に固定する MOD です。設定ファイルの値を起動時に書き換え、メニューから有効にしてもすぐ元に戻します。

## 機能

- 起動時に `settings.cfg` の `smoothCameraEnabled` が `1` なら `0` に書き換えて保存する
- メニューシーン読み込み時に `MainSettingsModelSO` の SmoothCamera 設定を取得する
- SmoothCamera の値が変化したときに `true` へ変わったら即座に `false` へ戻す
- 設定画面で有効にしても無効のままになる (トグルの変更を検知して打ち消す)
- 独自の設定ファイルや設定画面は持たない

## 動作環境

| 項目 | 内容 |
| --- | --- |
| Beat Saber | 1.9.0 |
| 依存 MOD | なし (manifest の `dependsOn` は空) |

コードは BS Utils の `BSEvents` を参照しているため、BS Utils がインストールされている必要があります。

## インストール

1. Beat Saber を 1.9.0 に合わせる (BSManager などのバージョン管理ツールを推奨)
2. BSIPA と上記の依存 MOD をインストールする
3. [Releases](https://github.com/denpadokei/DisableSmoothCamera/releases) から `DisableSmoothCamera-0.0.1-bs1.9.0.zip` をダウンロードし、`Plugins` フォルダをゲームフォルダへ上書きコピーする

## ビルド

CodeTaskFactory を使う従来形式の targets (`BuildTargets.targets`) を含むため、`dotnet build` ではなく Visual Studio または Developer PowerShell の `msbuild` でビルドします。

```powershell
git clone https://github.com/denpadokei/DisableSmoothCamera.git
cd DisableSmoothCamera
msbuild .\DisableSmoothCamera\DisableSmoothCamera.csproj /t:Build /p:Configuration=Release
```

`BeatSaberDir` に Beat Saber のインストール先を `/p:BeatSaberDir="C:\Program Files\Beat Saber"` のように指定すると、ゲームの参照アセンブリを解決できます。

GitHub Actions の `build-and-release.yml` が push ごとにビルドし、`X.X.X` 形式のタグを push するとリリースを作成します。

## ライセンス

MIT License (`LICENSE`)
