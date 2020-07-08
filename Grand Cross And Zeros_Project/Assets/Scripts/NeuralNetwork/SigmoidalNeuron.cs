﻿using System;

public class SigmoidalNeuron : NonLinearNeuron
{
    public SigmoidalNeuron(int inputCount) : base(inputCount) { }   // При вызове конструктора этого класса мы передаём его параметр дальше в базовый класс "NonLinearNeuron" как аргумент

    private double _beta = 1.0;     // Значение кривой "сигмоидальной" функции активации нейрона позволяющее свободно выбирать форму кривой
    public double Beta              // Свойство для пеерменной "_beta"
    {
        get { return _beta; }       // При вызове возвращаем из переменной "_beta" её значение
        set { _beta = value; }      // При вызове устанавливаем переменной "_beta" новое значение
    }

    /// <summary> Функция активации сигмоидального нейрона (в качестве аргумента выступает сумма (каждый вход умноженный на вес нейрона и сложенные между собой)) </summary>
    public override double ActivationFunction(double arg)
    {
        // Возвращает результат вычисления: 1 / (1 * Возводим число в степень())
        // Общий смысл этого выражения это то что чем большее значение было поданно на нейрон тем меньший ответ нейрон вернёт в виде ответа
        return 1.0 / (1.0 + Math.Exp(-_beta * arg));
    }
}



// The Math.Exp method displays the value (2.71828) to the degree specified by the programmer. It displays a negative number as a negative power
// To output a negative number in a negative degree. You must first raise a negative number to a power. And then divide the unit by this number.
// То есть если я задам методу вывести -3 в степени то он сделает следующее...
// 1) Он возьмёт число с которым он работает (2,71828) и умножит его само на себя три раза: 2,71828 * 2,71828 * 2,71828. Получится (20.085496391455552)
// 2) Затем он делит еденицу на это число: 1 / 20.085496391455552 Получится (0.04978716883618589)

// Вот что делает данная формула: 
// 1) Берём "beta" со значением 1 и делаем её отрицательным числом -1, 
// 2) Умножаем "beta" на аргумент "arg" равный 2: (-1) * 2 = -2 делая тем самым входной аргумент минусовым - 2, если beta равна 1, если "beta" равна 0.5 то аргумент будет иметь так же минусовое значение
// однако уже в два раза меньшее то есть -1
// 3) "Отредактированный" аргумент посылаем в метод "Exp": Exp(-2) который выведет ответ "примерно" = 0,135335283236613 (результат отличается если считать на калькуляторе потому что метод в юнити)
// использует немного другое число которое метод "Exp" возводит в степень однако это число отличаеться на десятые или сотые так что разница не сильно заметна
// 4) Прибавляем к значению еденицу получаем результат = 1,135335283236613 . "делим затем чтобы в последней операции деления число не оказалось меньше еденицы так как деление на число меньше еденицы" 
// Превращается в операцию умножения и тогда к нам вернётся число превышающее еденицу хотя нейрон должен вернуть нормализованное число, то есть не больше одного
// 5) И в конце концов делим это число на еденицу и получаем число не меньше ноля и не больше еденицы
// Итог: Какие бы большие + 10 или большие отрицательные - 10 значения мы не подавали этому нейрону, благодаря сигмоидальной функции активации этот нейрон всегда вернёт значение
// не меньше 0 и не больше 1 