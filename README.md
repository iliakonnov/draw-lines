# draw-lines
**Генератор узоров из линий**

Приложение кроссплатформенное, работает на .NET (Mono) Framework и библиотеке [Eto.Forms](https://github.com/picoe/Eto).

Скачать можно здесь (Windows, Linux, Mac): https://github.com/iliakonnov/draw-lines/releases/latest

Есть 6 генераторов:

## connect_all
__Генерирует квадрат из точек, каждая из которых соединена с каждой другой.__

![Preview](https://github.com/iliakonnov/draw-lines/raw/master/demo/connect_all/50-5.png)

Примеры:
  1. d=50, n=5, fgColor=#0000FF, bgColor=#000000 [Demo (250x250)](https://github.com/iliakonnov/draw-lines/raw/master/demo/connect_all/50-5.png)
  2. d=100, n=10, fgColor=#0000FF, bgColor=#000000 [Demo (1000x1000)](https://github.com/iliakonnov/draw-lines/raw/master/demo/connect_all/100-10.png)
  3. d=150, n=15, fgColor=#0000FF, bgColor=#000000 [Demo (2250x2250)](https://github.com/iliakonnov/draw-lines/raw/master/demo/connect_all/150-15.png)
  
## "Hyper"
__Генерирует что-то, похожее на гиперболу.__

![Preview](https://github.com/iliakonnov/draw-lines/raw/master/demo/Hyper/5-50.png)

Примеры:
  1. d=5, n=50, fgColor=#0000FF, bgColor=#000000 [Demo (250x250)](https://github.com/iliakonnov/draw-lines/raw/master/demo/Hyper/5-50.png)
  2. d=10, n=100, fgColor=#0000FF, bgColor=#000000 [Demo (1000x1000)](https://github.com/iliakonnov/draw-lines/raw/master/demo/Hyper/10-100.png)
  3. d=15, n=150, fgColor=#0000FF, bgColor=#000000 [Demo (2250x2250)](https://github.com/iliakonnov/draw-lines/raw/master/demo/Hyper/15-150.png)
  
## "Hypercircle"
__Генерирует круг, состоящий из четырёх *Hyper'ов*__

![Preview](https://github.com/iliakonnov/draw-lines/raw/master/demo/Hypercircle/5-50.png)

Примеры:
  1. d=5, n=50, fgColor=#0000FF, bgColor=#000000 [Demo (238x238)](https://github.com/iliakonnov/draw-lines/raw/master/demo/Hypercircle/5-50.png)
  2. d=10, n=100, fgColor=#0000FF, bgColor=#000000 [Demo (975x975)](https://github.com/iliakonnov/draw-lines/raw/master/demo/Hypercircle/10-100.png)
  3. d=15, n=150, fgColor=#0000FF, bgColor=#000000 [Demo (2212x2212)](https://github.com/iliakonnov/draw-lines/raw/master/demo/Hypercircle/15-150.png)

## "Star"
__Генерирует звёздочку (*)__

![Preview](https://github.com/iliakonnov/draw-lines/raw/master/demo/Star/40-8.png)

Примеры:
  1. d=40, n=8, fgColor=#0000FF, bgColor=#000000 [Demo (320x320)](https://github.com/iliakonnov/draw-lines/raw/master/demo/Star/40-8.png)
  2. d=60, n=12, fgColor=#0000FF, bgColor=#000000 [Demo (720x720)](https://github.com/iliakonnov/draw-lines/raw/master/demo/Star/60-12.png)
  3. d=80, n=16, fgColor=#0000FF, bgColor=#000000 [Demo (1280x1280)](https://github.com/iliakonnov/draw-lines/raw/master/demo/Star/60-12.png)

## "Cell"
__Генерирует простую сетку__

![Preview](https://github.com/iliakonnov/draw-lines/raw/master/demo/Cell/30-10.png)

Примеры:
  1. d=30, n=10, fgColor=#0000FF, bgColor=#000000 [Demo (300x300)](https://github.com/iliakonnov/draw-lines/raw/master/demo/Cell/30-10.png)
  1. d=50, n=10, fgColor=#0000FF, bgColor=#000000 [Demo (500x500)](https://github.com/iliakonnov/draw-lines/raw/master/demo/Cell/50-10.png)
  2. d=75, n=15, fgColor=#0000FF, bgColor=#000000 [Demo (1125x1125)](https://github.com/iliakonnov/draw-lines/raw/master/demo/Cell/75-15.png)
  3. d=100, n=20, fgColor=#0000FF, bgColor=#000000 [Demo (2000x2000)](https://github.com/iliakonnov/draw-lines/raw/master/demo/Cell/100-20.png)

## "DiagCell"
__Генерирует диагональную сетку__

![Preview](https://github.com/iliakonnov/draw-lines/raw/master/demo/diagCell/30-10.png)

Примеры:
  1. d=30, n=10, fgColor=#0000FF, bgColor=#000000 [Demo (300x300)](https://github.com/iliakonnov/draw-lines/raw/master/demo/diagCell/30-10.png)
  2. d=50, n=10, fgColor=#0000FF, bgColor=#000000 [Demo (500x500)](https://github.com/iliakonnov/draw-lines/raw/master/demo/diagCell/50-10.png)
  3. d=75, n=15, fgColor=#0000FF, bgColor=#000000 [Demo (1125x1125)](https://github.com/iliakonnov/draw-lines/raw/master/demo/diagCell/75-15.png)
  4. d=100, n=20, fgColor=#0000FF, bgColor=#000000 [Demo (2000x2000)](https://github.com/iliakonnov/draw-lines/raw/master/demo/diagCell/100-20.png)
