# Colors for GB
Description

Жанр:

 Казуальная аркада с элементами головоломки и экшена.

Геймплей:

 Игровой экран состоит из ограниченной с боков наклонной дорожки для скатывания по ней, раставленых в случайном порядке,
шариков трёх цветов: красного(1,0,0), зеленого(0,1,0) и голубого(0,0,1). Игрок мышкой (или пальцем в мобильной версии) управляет своим шариком и ловит
другие шарики.

Правила игры:

 Все шарики коснувшиеся игрока удаляются.
Цвет игрока дополняется цветом столкнувшегося шарика пока не станет белым(1,1,1). Белый шарик принимает цвет столкнувшегося с ним шарика. 
При совпадении цветов игрок получает очко и секунду которая добавляется к таймеру отсчитывающему время до конца игры. Не пойманые шарики уменьшают оставшееся время. Когда шарики скатываются до определённого уровня наклон дорожки увеличивается и появляються новые шарики.
Игра кончается когда заканчивается время на таймере.

Стратегия:

Основная задача собрать как можно больше шариков совпадающего цвета. Для этого нужно менять свой цвет как можно реже.
Возможен вариант стратегии берсерк.

Возможные дополнения:

 Нарастающие бонусы за серию шаров одного цвета.
 Штрафы за подобранные шары одного цвета но отличающиеся от игрока.
 Бонусные серии шаров одного цвета.
 Бонусные шары дающие новые возможности (кратковременно замедлить/направить вспять шары, телепорт для игрока, мультицвет...)
 Переодическая или бонусная смена цветовой модели. 


Скрипты:





    	GameManager

Принимает из инспектора все настраиваемые параметры игры:
Количество столбцов и строк игровых шариков.
Начальное количество секунд.
Скорость перемещения игрока.
Начальный наклон игровой комнаты.
Значение на которое увеличивается угол после каждой серии.

Последовательно задает стартовые параметры в зависимости от введеных данных.

Переключает состояния игры.

Объект - GameManager.

Методы:

    private void Awake()

Присваивает значение глобальной переменной PlayerSpeed.
Задает стартовые параметры:
levelRoomParamScript.SetParametrs(float columns, float rows);
lavelRoomRotateScript.SetParametrs(float roomAngle, float roomAngleBoost);
seriesCreationScript.SetParametrs(int columns,int rows);
timerScript.SetParametrs(int seconds);

    public void Pause()

Управляет элементами UI.
Задает значение Time.timeScale.

    public void Restart()

Задает значение Time.timeScale.
Перезапускает сцену

    public void QuitGame()

Выход из игры.

    public void GameOver()

Задает значение Time.timeScale.
Управляет элементами UI.
Останавливает выполнение метода Pause().





      AudioManagerScript

Управляет звуком.
Объект - GameManager.

Методы:

    private void Awake()

Получает компонент AudioSource.
Задаёт значение Mute в AudioSource.

    public void Mute()

Присваивает значение переменной GlobalVars.Mute AudioSource.mute.
Меняет значение GlobalVars.Mute.

    CollisionAudioPlay(GameObject collision)

Получает Clip у GameObject collision и воспроизводит его.





	   PlayerInputScript

Отслеживает ввод с клавиатуры/мыши.
Вызывает методы в класах PlayerMovementScript и GameManager.
Объект - Player.

Методы:

    private void Awake()

Получение компонента PlayerMovementScript.

    void Update()

Вызывает методы MouseTargetPosition() и EscPush().

    private void MouseTargetPosition()

Получает проекцию луча из координат курсора на объект слоя и передает методу 
Movement(Vector3) класс PlayerMovementScript.

    private void EscPush()

При нажатии клавиши Esc вызывает метод Pause() класс GameManager.





	   PlayerMovementScript

Задает значение скорости у компонента Rigidbody игрока.
В инспекторе задается множитель скорости.
Объект - Player.

Методы:

    private void Awake()

Получение компонента Rigidbody.

    public void Movement(Vector3)

Задает значение скорости у компонента Rigidbody игрока умножая получаемый Vector3 на глобальную переменную PlayerSpeed.





	   PlayerCollisionScript

Содержит игровую логику обработки коллизий, в соответствии с ней
меняет свойства игрока. Это основная игровая механика.
Дополнительные функции: начисление и вывод игровых очков.
Объект - Player.

Методы:

    private void Awake()

Получение MeshRenderer игрока.

    private void OnCollisionEnter(Collision collision)

Проверяет тег и если это не Ground вызывает методы public void AudioPlay(collision.gameObject) из класса AudioManagerScript,  ColorChange(GameObject) и удаляет объект коллизии.

    private void ColorChange(GameObject collision)

Основная игровая механика.
Получает компонент MeshRenderer объекта коллизии и сравнивает 
material.color игрока и коснувшегося объекта:

1) Совпадение: Начисляются и выводятся очки. Проигрывается ParticleSystem. Вызывается метод TimeIncreasing() класса TimerScript.

2) Не совпадает но цвет объекта  содержит все три единичные значения цвета: Цвет игрока становится как у объекта коллизии.

3) Не совпадает: Цвет игрока задается максимальным значением каждого составляющего цвета. Пример: (1, 0, 0,) х (1, 1, 0) = (1, 1, 0).





        LevelRoomParamScript

Задает параметры игровой комнаты:
Размер стола, расположение бордюров, игрока, камеры, Roll, тригеров конца серии и уничтожения шариков.
Объект - LavelRoom.

Метооды:

public void SetParametrs(float columns, float rows).





        LavelRoomRotateScript

Управляет наклоном  объекта содержащего игровое поле.
Усложняет прохождение игры.
В инспекторе задается начальный угол и увеличение угла.
Объект - LavelRoom.

Методы:

    public void SetParametrs(float Angle, float AngleBoost)

Задает значение приватным переменным и вызывает метод public void LavelRoomRotate().

    public void LavelRoomRotate()

Поварачивает игровую комнату на angle.
Увеличивае значение переменной angle на angleBoost.





	   SeriesCreationScript

Создает серию объектов из префабов для сбора игроком и объект контролирующий
их проход по игровому полю.
Объект -  Series.
Методы:

    public void SetParametrs(int Columns, int Rows)

Задает значение приватным переменным columns, rows.
Получает компонент Transform для родительского объекта создаваемых объектов.
Определяет координату Х первого создаваемого объекта.
Вызывает метод SeriesCreation().

    SeriesCreation(int offset)

Создает серию объектов из префабов для сбора игроком и объект контролирующий
их проход по игровому полю.





	   SeriesFinishCollisionScript

Объект - SeriesFinish.

Метод:

    private void OnTriggerEnter(Collider other) 

Определяет прохождение последнего объекта серии.
Вызывает метод LavelRoomRotate() класса  lavelRoomRotateScript.
Вызывает метод SeriesCreation() класса seriesCreationScript.





	   LostBallsScript

Объект - DestroyCube.

Метод:

    private void OnTriggerEnter(Collider other) 

Удаляет объекты.
Вызывается метод TimeIncreasing() класса TimerScript.





	   TimerScript

Управляет отсчетом времени до конца игры.
Объект - GameManager.

Методы:

    public void SetParametrs(int seconds)

присваивает приватной переменной начальное значение таймера.
Получает компонент GameManager.
Вызывает метод TimerPrint().
Запускает отсчет StartCoroutine(Timer()).

    IEnumerator Timer()

При положительном значении таймера раз в секунду уменьшает значение на секунду.
Вызывает метод  TimerPrint().
При отрицательном значении таймера вызывает метод GameOver() класса GameManager.

    private void TimerPrint()

Выводит на экран значение таймера.

    public void TimeIncreasing()

Увеличивает значение таймера.
Вызывает метод  TimerPrint().

    public void TimeDecrease()

Уменьшает значение таймера.
Вызывает метод  TimerPrint().





     OpeningSceneScript

Объект - Canvas.

Методы:

    IEnumerator Start()

С задержкой загружает игровую сцену.





        GlobalVars

Содержит переменные:
public static float PlayerSpeed;
public static bool Mute;
