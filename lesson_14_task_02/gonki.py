from turtle import *
from random import randint
from time import *
colormode(255)

screen = Screen()
finish = 200 #дистанция гонки

t1 = Turtle() #создали обьект класса черепаха
t1.shape("turtle") #поменяли форму обьекта
t1.color(randint(0, 255), randint(0, 255), randint(0, 255)) #поменяли цвет обьекта
t1.penup() #поднимаем черепашку, чтобы не рисовала
t1.goto(-200, 20) #перемещаем черепашку по координатам
t1.pendown() #опускаем черепашку чтобы потом рисовала
t1.speed(3)

t2 = Turtle() #создали обьект класса черепаха
t2.shape("turtle") #поменяли форму обьекта
t2.color(randint(0, 255), randint(0, 255), randint(0, 255)) #поменяли цвет обьекта
t2.penup() #поднимаем черепашку, чтобы не рисовала
t2.goto(-200, -20) #перемещаем черепашку по координатам
t2.pendown() #опускаем черепашку чтобы потом рисовала
t2.speed(3)

t3 = Turtle() #создали обьект класса черепаха
t3.shape("turtle") #поменяли форму обьекта
t3.color(randint(0, 255), randint(0, 255), randint(0, 255)) #поменяли цвет обьекта
t3.penup() #поднимаем черепашку, чтобы не рисовала
t3.goto(-200, -60) #перемещаем черепашку по координатам
t3.pendown() #опускаем черепашку чтобы потом рисовала
t3.speed(3)

t4 = Turtle() #создали обьект класса черепаха
t4.shape("turtle") #поменяли форму обьекта
t4.color(randint(0, 255), randint(0, 255), randint(0, 255)) #поменяли цвет обьекта
t4.penup() #поднимаем черепашку, чтобы не рисовала
t4.goto(-200, -100) #перемещаем черепашку по координатам
t4.pendown() #опускаем черепашку чтобы потом рисовала
t4.speed(3)


def razmetka(): #функция нарисует разметку поля
    t=Turtle()
    t.speed(0)
    for i in range (1,21):
        t.penup()
        t.goto(-200+i*20, 50)
        t.pendown()
        t.goto(-200+i*20, -130)
    t.hideturtle()

razmetka()

def catch1(x,y): # это обработчик события нажатия
    t1.write('Ouch!', font=('Arial', 14, 'normal')) # пишем на экране Ouch!
    t1.fd(randint(10,15)) # черепашка делает случайный шаг

t1.onclick(catch1)

def catch2(x, y):
    t2.write('Мне больно!',  font=('Arial', 14, 'normal'))
    t2.fd(randint(10,15))

t2.onclick(catch2)

def catch3(x, y):
    t3.write('ОЙ!!',  font=('Arial', 14, 'normal'))
    t3.fd(randint(10,15))

t3.onclick(catch3)

def catch4(x, y):
    t4.write('Не надо!',  font=('Arial', 14, 'normal'))
    t4.fd(randint(10,15))

t4.onclick(catch4)

while t1.xcor()<finish and t2.xcor()<finish:#цикл пока дистанция меньше финиш
    t1.forward(randint(2,7)) #здесь черепаха двигается вперед и рисует на случайный шаг от 2 до 7
    t2.forward(randint(2,7))
    t3.forward(randint(2,7))
    t4.forward(randint(2,7))
    sleep(0.03)

screen.exitonclick()
