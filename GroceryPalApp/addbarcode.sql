select* from item_info;
select * from ITEM_INVENTORY;
select * from User_Account;
select * from ITEM_INVENTORY i,ITEM_INFO info where (i.INVENTORY_USER_ID=2) and (i.INVENTORY_BARCODE_NO=info.BARCODE_NO);
select * from ITEM_DICTIONARY;  ///item_name in item_info to match it
insert into ITEM_INFO(BARCODE_NO,ITEM_NAME,MANUFACTURED_DATE,EXPIRY_DATE,WEIGHT,DESCRIPTION,PRICE,BRAND) values (788821151278,'Shan Seekh Kabab Masala','2020-23-04','2021-07-30',50,'Shan Seekh Kabab Masala',70,'Shan');
insert into ITEM_INVENTORY (INVENTORY_BARCODE_NO,TOTAL_ITEM_PRICE,QUANTITY_OF_ITEM,INVENTORY_USER_ID) values (788821151278,70,1,2);		
select * from shopping_suggestion;
insert into shopping_suggestion (BRAND,DISCOUNT,MARKET_NAME,MARKET_LOCATION) values ('Shan',0,'Imtiaz','Tariq road branch');		

insert into ITEM_INFO(BARCODE_NO,ITEM_NAME,MANUFACTURED_DATE,EXPIRY_DATE,WEIGHT,DESCRIPTION,PRICE,BRAND,CATEGORY_NO) values (016000790704,'Super Moist Vanilla','2017-12-2','2019-06-1',500,'Betty Crocker French Vanilla Cake Mix',350,'Betty Crocker',1);
insert into ITEM_INVENTORY (INVENTORY_BARCODE_NO,TOTAL_ITEM_PRICE,QUANTITY_OF_ITEM,INVENTORY_USER_ID) values (016000790704,350,1,2);


insert into ITEM_INFO(BARCODE_NO,ITEM_NAME,EXPIRY_DATE) values (1235,'UNKNOWN','2019-12-3');
insert into ITEM_INVENTORY (INVENTORY_BARCODE_NO,INVENTORY_USER_ID) values (1235,1);
delete from ITEM_DICTIONARY;
delete from ITEM_INVENTORY where INVENTORY_BARCODE_NO='123';
delete from ITEM_INFO where BARCODE_NO='123';
select * from ITEM_INVENTORY i , ITEM_INFO info where  (info.BARCODE_NO =i.INVENTORY_BARCODE_NO) and(i.INVENTORY_USER_ID=1) 
select * from ITEM_INVENTORY i , ITEM_INFO info, ITEM_DICTIONARY d where  (info.BARCODE_NO =i.INVENTORY_BARCODE_NO) and(i.INVENTORY_USER_ID=1)  AND (info.ITEM_NAME=d.ITEM_NAME);
select * from Recipe_List; 
delete from Recipe_List;
select * from Recipe_List r where (r.user_id=1);
insert into Recipe_List(ITEM_NAME,DESCRIPTION,user_id,Recipe_name,Ingredients,EXPIRY_DATE) values ('Super Moist',' INSTRUCTIONS
Preheat oven to 350º F (175°C). Lightly grease an 8-inch round cake pan with non stick cooking oil spraying.
CHOCOLATE CAKE:
Combine flour, sugar, cocoa powder, baking powder and salt in a large bowl. Whisk thoroughly to combine well.
Add oil, egg, vanilla and milk to the flour mixture and beat well to combine. Pour in the boiling water (with the coffee), and mix until glossy.
Pour the cake batter into the prepared pan. Bake for about 40 - 45 minutes, until a toothpick inserted in the centre of the chocolate cake comes out semi-clean with small amount of cake (not runny batter) on it due to the fudgy texture.
Remove from oven and allow to cool for 20 minutes. Transfer cake from the pan to a wire rack and cool completely before frosting.
CHOCOLATE GANACHE:
Pour the cream into a small saucepan and heat over low heat for a few minutes. Watch that it doesnt boil or simmer it. Once the cream is hot, turn stove off and take the saucepan off the heat.
Add in the chocolate chips; cover saucepan with a lid and let sit for a good 5 minutes to soften and melt the chocolate. 
Uncover, and stir slowly first, with a spatula or wooden spoon, gradually mixing faster until ganache is smooth, creamy and glossy. Refrigerate for one hour or hour and a half until thick enough to spread (similar consistency to Nutella).
Spread evenly over the cake.',1,'Chocolate fudge','CHOCOLATE CAKE:
1 1/2 cups (7 oz / 200 g) all-purpose or plain flour
1 1/2 cups (11 oz / 310 g) white granulated sugar (or a natural granulated baking sweetener measuring 1:1 with sugar)
1/2 cup (1.7 oz / 50 g) unsweetened cocoa powder
1 1/2 teaspoons baking powder*
1/2 teaspoon salt
1/3 cup (80 ml) vegetable oil
1 large egg
1 tablespoon (20 ml) pure vanilla extract
3/4 cup (190 ml) milk
3/4 cup (190 ml) boiling water mixed with 2 teaspoons instant coffee powder
CHOCOLATE GANACHE:
1 cup (250 ml) heavy cream or thickened cream 8 ounces (250 grams) semi sweet or dark chocolate chips','2019-01-07');


delete from Recipe_List where ITEM_NAME='Super Moist Vanilla';

insert into Recipe_List(ITEM_NAME,DESCRIPTION,user_id,Recipe_name,Ingredients,EXPIRY_DATE) values ('Super Moist Vanilla',' Directions PREHEAT oven to 350 degrees. Butter three 9 inch cake pans and dust the inside with flour and tap out excess. Line the bottom of the pans with wax or parchment paper. Put the cake pans on a baking sheet lined with parchment paper or a silicone mat. Sift the dry ingredients together and set aside. Beat the butter for 3 minutes until light and fluffy. Add the sugar and beat another 3 minutes. Add the eggs, one at a time, and beat thoroughly after each addition. Start adding the flour mixture one cup at a time, and alternate with the milk; ending with the flour mixture. Add the vanilla, mix well and pour into prepared cake pans. Bake for 25-30 minutes or when a knife inserted in the center of the cake comes out clean. Transfer to a rack and cool for 5 minutes, then run a knife around the sides of the cakes, unmold them and peel off the paper liners. Invert and cool to room temperature, right side up. (These cooled cakes may be wrapped airtight and stored at room temperature overnight or frozen for up to two months.)',2,'French Vanilla Cake Mix','Ingredients
1 cup homemade unsalted butter, softened
2 cups white sugar
4 eggs, room temperature
2-3/4 cups all purpose flour
2-1/4 tsp baking powder
3/4 tsp salt
1 cup milk
2 TBS pure vanilla extrac','2019-06-1');

insert into Recipe_List(ITEM_NAME,DESCRIPTION,user_id,Recipe_name,Ingredients,EXPIRY_DATE) values ('Shan Seekh Kabab Masala',' STEPS OF COOKING
Mix all the above ingredients except butter and run in a chopper for 1 minute. Set aside for about 2-3 hours.
Add butter and mix well.
Make small round meat balls. Thread each through a skewer. Flatten the grounded meat in a thin layer around each skewer with wet hand.
Barbeque on low heat of coal/gas grill (or in a hot oven 275°F). Periodically turn skewer, until the kababs change color. Do not over grill / brown the kabab.',2,'Seekh Kabab','INGREDIENT REQUIRED
Ground / Minced Meat
1kg / 2.2lbs
& 200g fat/suet, minced twice


Green Chilies
2-3 tablespoons
coarsely grounded


Onion
1 small / 75g
finely diced (squeeze to remove liquid)


Cilantro/Fresh Coriander
2 tablespoons
chopped


Garlic Paste
2 tablespoons

Cooking Oil
1/2 -1 cup 85-175ml

Shan Seekh Kabab Mix
1 packet','2021-07-30');

insert into Recipe_List(ITEM_NAME,DESCRIPTION,user_id,Recipe_name,Ingredients,EXPIRY_DATE) values ('123',' INSTRUCTIONS
Preheat oven to 350º F (175°C). Lightly grease an 8-inch round cake pan with non stick cooking oil spraying.
CHOCOLATE CAKE:
Combine flour, sugar, cocoa powder, baking powder and salt in a large bowl. Whisk thoroughly to combine well.
Add oil, egg, vanilla and milk to the flour mixture and beat well to combine. Pour in the boiling water (with the coffee), and mix until glossy.
Pour the cake batter into the prepared pan. Bake for about 40 - 45 minutes, until a toothpick inserted in the centre of the chocolate cake comes out semi-clean with small amount of cake (not runny batter) on it due to the fudgy texture.
Remove from oven and allow to cool for 20 minutes. Transfer cake from the pan to a wire rack and cool completely before frosting.
CHOCOLATE GANACHE:
Pour the cream into a small saucepan and heat over low heat for a few minutes. Watch that it doesnt boil or simmer it. Once the cream is hot, turn stove off and take the saucepan off the heat.
Add in the chocolate chips; cover saucepan with a lid and let sit for a good 5 minutes to soften and melt the chocolate. 
Uncover, and stir slowly first, with a spatula or wooden spoon, gradually mixing faster until ganache is smooth, creamy and glossy. Refrigerate for one hour or hour and a half until thick enough to spread (similar consistency to Nutella).
Spread evenly over the cake.',1,'Chocolate fudge','CHOCOLATE CAKE:
1 1/2 cups (7 oz / 200 g) all-purpose or plain flour
1 1/2 cups (11 oz / 310 g) white granulated sugar (or a natural granulated baking sweetener measuring 1:1 with sugar)
1/2 cup (1.7 oz / 50 g) unsweetened cocoa powder
1 1/2 teaspoons baking powder*
1/2 teaspoon salt
1/3 cup (80 ml) vegetable oil
1 large egg
1 tablespoon (20 ml) pure vanilla extract
3/4 cup (190 ml) milk
3/4 cup (190 ml) boiling water mixed with 2 teaspoons instant coffee powder
CHOCOLATE GANACHE:
1 cup (250 ml) heavy cream or thickened cream 8 ounces (250 grams) semi sweet or dark chocolate chips','2019-03-12 ');

SET ansi_warnings OFF
INSERT INTO ITEM_DICTIONARY
	(IMAGE_ID,ITEM_NAME, ITEM_IMG)
	SELECT ROW_NUMBER() OVER( ORDER BY (select 100)),'Super Moist', 
		BulkColumn FROM OPENROWSET(
			Bulk 'D:\sem7\ipt\grocerpal new proj\images\betty.jpg', SINGLE_BLOB) AS BLOB

SET ansi_warnings OFF
INSERT INTO ITEM_DICTIONARY 
	(IMAGE_ID,ITEM_NAME, ITEM_IMG)
	SELECT  (SELECT MAX(image_id) FROM ITEM_DICTIONARY)+1,'Super Moist Vanilla', 
		BulkColumn FROM OPENROWSET(
			Bulk 'D:\sem7\ipt\grocerpal new proj\images\vanilla.jpg', SINGLE_BLOB) AS BLOB

SET ansi_warnings OFF
INSERT INTO ITEM_DICTIONARY 
	(IMAGE_ID,ITEM_NAME, ITEM_IMG)
	SELECT  (SELECT MAX(image_id) FROM ITEM_DICTIONARY)+1,'Shan Seekh Kabab Masala', 
		BulkColumn FROM OPENROWSET(
			Bulk 'D:\sem7\ipt\grocerpal new proj\images\seekh.jpg', SINGLE_BLOB) AS BLOB


SET ansi_warnings OFF
INSERT INTO ITEM_DICTIONARY 
	(IMAGE_ID,ITEM_NAME, ITEM_IMG)
	SELECT  (SELECT MAX(image_id) FROM ITEM_DICTIONARY)+1,'UNKNOWN', 
		BulkColumn FROM OPENROWSET(
			Bulk 'D:\sem7\ipt\grocerpal new proj\images\no.jpg', SINGLE_BLOB) AS BLOB

select * from ITEM_INVENTORY i, NUTRITION_METER n where  (n.ITEM_BARCODE_NO =i.INVENTORY_BARCODE_NO)  and(i.INVENTORY_USER_ID=1);

select * from ITEM_INVENTORY i , ITEM_INFO info, ITEM_DICTIONARY d where  (info.BARCODE_NO =i.INVENTORY_BARCODE_NO) and(i.INVENTORY_USER_ID=@user_id) and;

insert into NUTRITION_METER(ITEM_BARCODE_NO,SATURATED_FAT,SODIUM,CARBOHYDRATE,FIBRE,SUGAR) values (16000790704,9.7,0.623,33.4,0.4,20.4);
insert into NUTRITION_METER(ITEM_BARCODE_NO,SATURATED_FAT,SODIUM,CARBOHYDRATE,FIBRE,SUGAR) values (788821151278,1,0.85,4,2,0);

select * from ITEM_INVENTORY i, NUTRITION_METER n,ITEM_INFO info where  (n.ITEM_BARCODE_NO =i.INVENTORY_BARCODE_NO)  and(i.INVENTORY_USER_ID=2) and (i.INVENTORY_BARCODE_NO=info.BARCODE_NO);

insert into Calorie_Calculator (USER_ID,BMR,sedentary,lightly_active,moderatetely_active,very_active,extra_active,BMR) values (123,0.2) ;
select * from Calorie_Calculator;

