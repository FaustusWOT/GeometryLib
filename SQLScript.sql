-- Для случая если имеются две отдельные таблицы mb_item - товары, и mb_category- категории в каждой из которых имеются колонки id - ключ и sName - наименование,
-- а данные по принадлежности товара к категриям внесены в таблицу mb_link, то в данных условиях поставленная задача решается следующим запросом
select i.sName, c.sName from mb_item as i
left join mb_link as l on i.id = l.idItem
left join mb_category as c on l.idCategory = c.id
order by i.id,c.id

-- второй вариант - хранение перечня категорий (или их ID) в отдельном текстовом поле в таблице товаров. К примеру отдельныен категории в этом поле могут быть разделены запятыми.
-- в этом случае для разбора id из текстового поля удобно использовать CROSS APP и функцию из текстового поля создающую таблицу. Однако данныей вариант неудобен при работе с категориями, например
-- в данном случае придется заморачиваться с текстовым представлением при изменении принадлежности товара к категриям...
