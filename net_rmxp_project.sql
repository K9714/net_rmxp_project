/*
MySQL Data Transfer
Source Host: localhost
Source Database: net_rmxp_project
Target Host: localhost
Target Database: net_rmxp_project
Date: 2019-02-27 ���� 11:47:27
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for enemy
-- ----------------------------
CREATE TABLE `enemy` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `name` char(255) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `image` char(255) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `exp` int(10) NOT NULL DEFAULT '0',
  `level` int(10) NOT NULL DEFAULT '1',
  `maxhp` int(10) NOT NULL DEFAULT '100',
  `maxmp` int(10) NOT NULL DEFAULT '100',
  `str` int(10) NOT NULL DEFAULT '5',
  `dex` int(10) NOT NULL DEFAULT '5',
  `int` int(10) NOT NULL DEFAULT '5',
  `luk` int(10) NOT NULL DEFAULT '5',
  `direction` int(10) NOT NULL DEFAULT '2',
  `move_speed` int(10) NOT NULL DEFAULT '4',
  `pattern` int(10) NOT NULL DEFAULT '0',
  `delay` int(10) NOT NULL DEFAULT '10',
  `rebirth_time` int(10) NOT NULL DEFAULT '50',
  `sight` int(10) NOT NULL DEFAULT '3',
  `animation_id` int(10) NOT NULL DEFAULT '7',
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=46 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for enemy_dropitem
-- ----------------------------
CREATE TABLE `enemy_dropitem` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `enemy_no` int(10) NOT NULL,
  `item_no` int(10) NOT NULL,
  `rate` int(10) NOT NULL DEFAULT '0',
  `image` char(255) COLLATE utf8_unicode_ci NOT NULL DEFAULT '193-Support01.png',
  `pattern_x` int(10) NOT NULL DEFAULT '0',
  `pattern_y` int(10) NOT NULL DEFAULT '2',
  `min_price` int(10) NOT NULL DEFAULT '0',
  `max_price` int(10) NOT NULL DEFAULT '0',
  `min_str` int(10) NOT NULL DEFAULT '0',
  `max_str` int(10) NOT NULL DEFAULT '0',
  `min_dex` int(10) NOT NULL DEFAULT '0',
  `max_dex` int(10) NOT NULL DEFAULT '0',
  `min_int` int(10) NOT NULL DEFAULT '0',
  `max_int` int(10) NOT NULL DEFAULT '0',
  `min_luk` int(10) NOT NULL DEFAULT '0',
  `max_luk` int(10) NOT NULL DEFAULT '0',
  `min_hp` int(10) NOT NULL DEFAULT '0',
  `max_hp` int(10) NOT NULL DEFAULT '0',
  `min_mp` int(10) NOT NULL DEFAULT '0',
  `max_mp` int(10) NOT NULL DEFAULT '0',
  `min_solid` int(10) NOT NULL DEFAULT '0',
  `max_solid` int(10) NOT NULL DEFAULT '0',
  `min_ability` int(10) NOT NULL DEFAULT '0',
  `max_ability` int(10) NOT NULL DEFAULT '0',
  `min_cost` int(10) NOT NULL DEFAULT '0',
  `max_cost` int(10) NOT NULL DEFAULT '0',
  `trade` int(10) NOT NULL DEFAULT '1',
  `sell` int(10) NOT NULL DEFAULT '1',
  `use` int(10) NOT NULL DEFAULT '1',
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=48 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for enemy_position
-- ----------------------------
CREATE TABLE `enemy_position` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `enemy_no` int(10) NOT NULL,
  `map_id` int(10) NOT NULL,
  `map_x` int(10) NOT NULL,
  `map_y` int(10) NOT NULL,
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for level_up
-- ----------------------------
CREATE TABLE `level_up` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `next_exp` int(10) NOT NULL DEFAULT '0',
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=40 DEFAULT CHARSET=euckr;

-- ----------------------------
-- Table structure for npc
-- ----------------------------
CREATE TABLE `npc` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `name` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `image` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `id` int(10) NOT NULL DEFAULT '0',
  `map_id` int(10) NOT NULL DEFAULT '0',
  `map_x` int(10) NOT NULL DEFAULT '0',
  `map_y` int(10) NOT NULL DEFAULT '0',
  `direction` int(10) NOT NULL DEFAULT '2',
  `pattern` int(10) NOT NULL DEFAULT '0',
  `move_speed` int(10) NOT NULL DEFAULT '4',
  `default_action` int(10) NOT NULL DEFAULT '0',
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for portal
-- ----------------------------
CREATE TABLE `portal` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `map_id` int(10) NOT NULL,
  `x` int(10) NOT NULL,
  `y` int(10) NOT NULL,
  `move_map_id` int(10) NOT NULL,
  `move_x` int(10) NOT NULL,
  `move_y` int(10) NOT NULL,
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for storage_character
-- ----------------------------
CREATE TABLE `storage_character` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `item_type` int(5) NOT NULL DEFAULT '2',
  `character` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `name` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `description` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `price` int(10) NOT NULL DEFAULT '0',
  `image` char(255) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for storage_equipment
-- ----------------------------
CREATE TABLE `storage_equipment` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `item_no` int(10) NOT NULL,
  `price` int(10) NOT NULL DEFAULT '0',
  `str` int(10) NOT NULL DEFAULT '0',
  `dex` int(10) NOT NULL DEFAULT '0',
  `int` int(10) NOT NULL DEFAULT '0',
  `luk` int(10) NOT NULL DEFAULT '0',
  `hp` int(10) NOT NULL DEFAULT '0',
  `mp` int(10) NOT NULL DEFAULT '0',
  `solid` int(10) NOT NULL DEFAULT '0',
  `max_ability` int(10) NOT NULL DEFAULT '0',
  `ability` int(10) NOT NULL DEFAULT '0',
  `lv_cost` int(10) NOT NULL DEFAULT '0',
  `trade` int(2) NOT NULL DEFAULT '1',
  `sell` int(2) NOT NULL DEFAULT '1',
  `use` int(2) NOT NULL DEFAULT '1',
  `character` char(255) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=1931 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for storage_item
-- ----------------------------
CREATE TABLE `storage_item` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `name` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `type` int(3) NOT NULL DEFAULT '0',
  `equip_type` int(3) NOT NULL DEFAULT '0',
  `icon` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `description` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `price` int(10) NOT NULL DEFAULT '0',
  `str` int(10) NOT NULL DEFAULT '0',
  `dex` int(10) NOT NULL DEFAULT '0',
  `int` int(10) NOT NULL DEFAULT '0',
  `luk` int(10) NOT NULL DEFAULT '0',
  `hp` int(10) NOT NULL DEFAULT '0',
  `mp` int(10) NOT NULL DEFAULT '0',
  `solid` int(10) NOT NULL DEFAULT '0',
  `max_ability` int(10) NOT NULL DEFAULT '0',
  `ability` int(10) NOT NULL DEFAULT '0',
  `lv_cost` int(10) NOT NULL DEFAULT '0',
  `rank` int(10) NOT NULL DEFAULT '0',
  `trade` int(2) NOT NULL DEFAULT '1',
  `sell` int(2) NOT NULL DEFAULT '1',
  `use` int(2) NOT NULL DEFAULT '1',
  `method_name` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `method_arg` int(10) NOT NULL,
  `animation_id` int(10) NOT NULL,
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=72 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for storage_skill
-- ----------------------------
CREATE TABLE `storage_skill` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `name` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `description` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `icon` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `function` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `max_level` int(10) NOT NULL DEFAULT '1',
  `power` int(10) NOT NULL DEFAULT '0',
  `power_factor` int(10) NOT NULL DEFAULT '1',
  `level_power` int(10) NOT NULL DEFAULT '0',
  `cost` int(10) NOT NULL DEFAULT '0',
  `range_type` int(10) NOT NULL DEFAULT '0',
  `range` int(10) NOT NULL DEFAULT '1',
  `count` int(10) NOT NULL DEFAULT '1',
  `delay` int(10) NOT NULL DEFAULT '0',
  `wait_time` int(10) NOT NULL DEFAULT '0',
  `use_animation` int(10) NOT NULL DEFAULT '0',
  `target_animation` int(10) NOT NULL DEFAULT '0',
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for store
-- ----------------------------
CREATE TABLE `store` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `name` char(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for store_item
-- ----------------------------
CREATE TABLE `store_item` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `store_no` int(10) DEFAULT NULL,
  `item_no` int(10) DEFAULT NULL,
  `price` int(10) DEFAULT '0',
  `number` int(10) DEFAULT '0',
  `discount` int(10) DEFAULT '0',
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for user_character
-- ----------------------------
CREATE TABLE `user_character` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `user_no` int(10) NOT NULL,
  `name` char(255) COLLATE utf8_unicode_ci NOT NULL,
  `image` char(255) COLLATE utf8_unicode_ci NOT NULL DEFAULT '001-Fighter01.png',
  `exp` int(10) NOT NULL,
  `gold` int(10) NOT NULL DEFAULT '0',
  `level` int(10) NOT NULL DEFAULT '1',
  `guild` int(10) NOT NULL,
  `job` int(10) NOT NULL DEFAULT '0',
  `maxhp` int(10) NOT NULL DEFAULT '100',
  `maxmp` int(10) NOT NULL DEFAULT '100',
  `hp` int(10) NOT NULL DEFAULT '100',
  `mp` int(10) NOT NULL DEFAULT '100',
  `str` int(10) NOT NULL DEFAULT '5',
  `dex` int(10) NOT NULL DEFAULT '5',
  `int` int(10) NOT NULL DEFAULT '5',
  `luk` int(10) NOT NULL DEFAULT '5',
  `point` int(10) NOT NULL DEFAULT '0',
  `map_id` int(10) NOT NULL DEFAULT '1',
  `map_x` int(10) NOT NULL DEFAULT '0',
  `map_y` int(10) NOT NULL DEFAULT '0',
  `direction` int(10) NOT NULL DEFAULT '2',
  `move_speed` int(10) NOT NULL DEFAULT '4',
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=47 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for user_equipment
-- ----------------------------
CREATE TABLE `user_equipment` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `char_no` int(10) NOT NULL,
  `item_no` int(10) NOT NULL,
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=535 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for user_information
-- ----------------------------
CREATE TABLE `user_information` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `id` char(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `pw` char(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `mail` char(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `pass_question` char(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `pass_answer` char(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `online` int(5) NOT NULL DEFAULT '0',
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=212 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for user_inventory
-- ----------------------------
CREATE TABLE `user_inventory` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `char_no` int(10) NOT NULL,
  `item_no` int(10) NOT NULL,
  `item_type` int(10) NOT NULL,
  `number` int(10) NOT NULL DEFAULT '0',
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=2514 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Table structure for user_skill
-- ----------------------------
CREATE TABLE `user_skill` (
  `no` int(10) NOT NULL AUTO_INCREMENT,
  `char_no` int(10) NOT NULL,
  `skill_no` int(10) NOT NULL,
  `level` int(10) NOT NULL DEFAULT '1',
  `wait_time` int(10) NOT NULL DEFAULT '0',
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records 
-- ----------------------------
INSERT INTO `enemy` VALUES ('37', '다람쥐', '168-Small10.png', '5', '1', '100', '100', '8', '20', '5', '3', '2', '4', '0', '10', '50', '1', '4');
INSERT INTO `enemy` VALUES ('45', '독버섯', '090-Monster04.png', '130', '15', '2500', '100', '40', '140', '5', '100', '2', '5', '0', '7', '50', '3', '9');
INSERT INTO `enemy` VALUES ('39', '들개', '151-Animal01.png', '25', '3', '350', '100', '19', '40', '5', '5', '2', '4', '0', '10', '50', '3', '6');
INSERT INTO `enemy` VALUES ('44', '[보스] 호랑이', '158-Animal08.png', '550', '10', '5000', '100', '200', '145', '5', '150', '2', '7', '0', '4', '600', '3', '6');
INSERT INTO `enemy_dropitem` VALUES ('38', '42', '60', '100', '193-Support01.png', '0', '2', '0', '0', '0', '20', '0', '20', '0', '20', '0', '7', '0', '0', '0', '0', '0', '0', '100', '300', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('37', '41', '60', '100', '193-Support01.png', '0', '2', '0', '0', '0', '20', '0', '20', '0', '20', '0', '7', '0', '0', '0', '0', '0', '0', '100', '300', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('36', '40', '60', '100', '193-Support01.png', '0', '2', '0', '0', '0', '20', '0', '20', '0', '20', '0', '7', '0', '0', '0', '0', '0', '0', '100', '300', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('35', '39', '61', '10', '193-Support01.png', '0', '2', '0', '0', '0', '30', '0', '30', '0', '30', '2', '20', '0', '0', '0', '0', '0', '0', '200', '500', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('34', '39', '60', '100', '193-Support01.png', '0', '2', '0', '100', '0', '10', '0', '10', '0', '10', '0', '7', '0', '0', '0', '0', '0', '0', '100', '300', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('33', '38', '59', '100', '193-Support01.png', '0', '2', '0', '0', '0', '10', '0', '5', '0', '0', '0', '5', '0', '0', '0', '0', '0', '0', '100', '300', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('32', '36', '59', '100', '193-Support01.png', '0', '2', '0', '0', '0', '10', '0', '5', '0', '0', '0', '5', '0', '0', '0', '0', '0', '0', '100', '300', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('31', '35', '59', '100', '193-Support01.png', '0', '2', '0', '0', '0', '10', '0', '5', '0', '0', '0', '5', '0', '0', '0', '0', '0', '0', '100', '300', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('26', '37', '59', '100', '193-Support01.png', '0', '2', '0', '50', '0', '5', '0', '5', '0', '0', '0', '5', '0', '0', '0', '0', '0', '0', '100', '300', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('24', '38', '58', '300', '193-Support01.png', '0', '2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('22', '37', '58', '300', '193-Support01.png', '0', '2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('23', '36', '58', '300', '193-Support01.png', '0', '2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('21', '35', '58', '300', '193-Support01.png', '0', '2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('40', '40', '61', '10', '193-Support01.png', '0', '2', '0', '0', '0', '30', '0', '30', '0', '30', '2', '20', '0', '0', '0', '0', '0', '0', '200', '500', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('39', '43', '60', '100', '193-Support01.png', '0', '2', '0', '0', '0', '20', '0', '20', '0', '20', '0', '7', '0', '0', '0', '0', '0', '0', '100', '300', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('41', '41', '61', '10', '193-Support01.png', '0', '2', '0', '0', '0', '30', '0', '30', '0', '30', '2', '20', '0', '0', '0', '0', '0', '0', '200', '500', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('42', '42', '61', '10', '193-Support01.png', '0', '2', '0', '0', '0', '30', '0', '30', '0', '30', '2', '20', '0', '0', '0', '0', '0', '0', '200', '500', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('43', '43', '61', '10', '193-Support01.png', '0', '2', '0', '0', '0', '30', '0', '30', '0', '30', '2', '20', '0', '0', '0', '0', '0', '0', '200', '500', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('44', '44', '62', '300', '193-Support01.png', '0', '2', '0', '300', '0', '20', '0', '20', '0', '20', '0', '10', '0', '0', '0', '0', '0', '0', '300', '700', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('45', '44', '63', '200', '193-Support01.png', '0', '2', '0', '1000', '0', '50', '0', '50', '0', '50', '0', '25', '0', '0', '0', '0', '0', '0', '500', '1000', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('46', '45', '67', '400', '193-Support01.png', '0', '2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1');
INSERT INTO `enemy_dropitem` VALUES ('47', '44', '68', '150', '193-Support01.png', '0', '2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1');
INSERT INTO `enemy_position` VALUES ('1', '37', '2', '11', '2');
INSERT INTO `enemy_position` VALUES ('2', '37', '2', '11', '12');
INSERT INTO `enemy_position` VALUES ('3', '37', '2', '22', '14');
INSERT INTO `enemy_position` VALUES ('4', '37', '2', '21', '8');
INSERT INTO `enemy_position` VALUES ('5', '39', '3', '9', '2');
INSERT INTO `enemy_position` VALUES ('6', '39', '3', '5', '8');
INSERT INTO `enemy_position` VALUES ('7', '39', '3', '11', '15');
INSERT INTO `enemy_position` VALUES ('8', '39', '3', '6', '26');
INSERT INTO `enemy_position` VALUES ('9', '39', '3', '14', '3');
INSERT INTO `enemy_position` VALUES ('10', '44', '3', '19', '12');
INSERT INTO `enemy_position` VALUES ('11', '45', '4', '12', '2');
INSERT INTO `enemy_position` VALUES ('12', '45', '4', '19', '5');
INSERT INTO `enemy_position` VALUES ('13', '45', '4', '20', '13');
INSERT INTO `enemy_position` VALUES ('14', '45', '4', '12', '13');
INSERT INTO `enemy_position` VALUES ('15', '45', '4', '4', '14');
INSERT INTO `enemy_position` VALUES ('17', '44', '3', '5', '12');
INSERT INTO `enemy_position` VALUES ('18', '44', '3', '5', '27');
INSERT INTO `level_up` VALUES ('1', '20');
INSERT INTO `level_up` VALUES ('2', '40');
INSERT INTO `level_up` VALUES ('3', '80');
INSERT INTO `level_up` VALUES ('4', '120');
INSERT INTO `level_up` VALUES ('5', '160');
INSERT INTO `level_up` VALUES ('6', '200');
INSERT INTO `level_up` VALUES ('7', '300');
INSERT INTO `level_up` VALUES ('8', '400');
INSERT INTO `level_up` VALUES ('9', '500');
INSERT INTO `level_up` VALUES ('10', '600');
INSERT INTO `level_up` VALUES ('11', '800');
INSERT INTO `level_up` VALUES ('12', '1000');
INSERT INTO `level_up` VALUES ('13', '1200');
INSERT INTO `level_up` VALUES ('14', '1400');
INSERT INTO `level_up` VALUES ('15', '1700');
INSERT INTO `level_up` VALUES ('16', '2000');
INSERT INTO `level_up` VALUES ('17', '2400');
INSERT INTO `level_up` VALUES ('18', '2800');
INSERT INTO `level_up` VALUES ('19', '3200');
INSERT INTO `level_up` VALUES ('20', '6400');
INSERT INTO `level_up` VALUES ('21', '9600');
INSERT INTO `level_up` VALUES ('22', '12800');
INSERT INTO `level_up` VALUES ('23', '25600');
INSERT INTO `level_up` VALUES ('24', '51200');
INSERT INTO `level_up` VALUES ('25', '102400');
INSERT INTO `level_up` VALUES ('26', '204800');
INSERT INTO `level_up` VALUES ('27', '409600');
INSERT INTO `level_up` VALUES ('28', '819200');
INSERT INTO `level_up` VALUES ('29', '1638400');
INSERT INTO `npc` VALUES ('10', '테스트NPC', '020-Hunter01.png', '1', '1', '12', '7', '2', '0', '4', '1');
INSERT INTO `npc` VALUES ('12', '어둠의 상인', '018-Thief03.png', '1', '4', '3', '11', '2', '0', '4', '1');
INSERT INTO `npc` VALUES ('13', '테스트상인', '020-Hunter01.png', '0', '1', '13', '7', '2', '0', '4', '1');
INSERT INTO `portal` VALUES ('1', '1', '24', '7', '2', '1', '7');
INSERT INTO `portal` VALUES ('2', '1', '24', '8', '2', '1', '8');
INSERT INTO `portal` VALUES ('3', '2', '0', '7', '1', '23', '7');
INSERT INTO `portal` VALUES ('4', '2', '0', '8', '1', '23', '8');
INSERT INTO `portal` VALUES ('5', '2', '24', '2', '3', '1', '2');
INSERT INTO `portal` VALUES ('6', '2', '24', '3', '3', '1', '3');
INSERT INTO `portal` VALUES ('7', '2', '17', '18', '4', '17', '1');
INSERT INTO `portal` VALUES ('8', '2', '18', '18', '4', '18', '1');
INSERT INTO `portal` VALUES ('9', '3', '0', '2', '2', '23', '2');
INSERT INTO `portal` VALUES ('10', '3', '0', '3', '2', '23', '3');
INSERT INTO `portal` VALUES ('11', '3', '0', '22', '4', '23', '3');
INSERT INTO `portal` VALUES ('12', '3', '0', '23', '4', '23', '4');
INSERT INTO `portal` VALUES ('13', '4', '17', '0', '2', '17', '17');
INSERT INTO `portal` VALUES ('14', '4', '18', '0', '2', '18', '17');
INSERT INTO `portal` VALUES ('15', '4', '24', '3', '3', '1', '22');
INSERT INTO `portal` VALUES ('16', '4', '24', '4', '3', '1', '23');
INSERT INTO `storage_equipment` VALUES ('1696', '59', '38', '5', '5', '0', '5', '0', '0', '0', '212', '212', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1730', '62', '0', '0', '0', '0', '0', '0', '0', '0', '200', '200', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1826', '59', '35', '4', '5', '0', '1', '0', '0', '0', '122', '122', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1699', '59', '2', '3', '5', '0', '5', '0', '0', '0', '218', '218', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1753', '59', '1', '4', '3', '0', '2', '0', '0', '0', '161', '161', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1915', '59', '40', '5', '1', '0', '4', '0', '0', '0', '177', '177', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1811', '61', '0', '16', '24', '13', '16', '0', '0', '0', '365', '365', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1703', '60', '99', '8', '10', '7', '0', '0', '0', '0', '101', '101', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1929', '60', '30', '4', '4', '8', '4', '0', '0', '0', '202', '202', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1706', '61', '0', '26', '23', '20', '19', '0', '0', '0', '405', '405', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1709', '59', '27', '5', '3', '0', '4', '0', '0', '0', '288', '288', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1823', '62', '276', '20', '19', '11', '9', '0', '0', '0', '302', '302', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1748', '61', '0', '28', '8', '12', '14', '0', '0', '0', '360', '360', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1712', '61', '0', '25', '6', '28', '18', '0', '0', '0', '237', '237', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1922', '59', '49', '4', '4', '0', '5', '0', '0', '0', '286', '286', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1760', '66', '0', '0', '0', '0', '0', '0', '0', '0', '200', '200', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1824', '63', '868', '47', '47', '37', '8', '0', '0', '0', '848', '848', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1726', '63', '0', '0', '0', '0', '0', '0', '0', '0', '200', '200', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1921', '60', '25', '7', '3', '0', '2', '0', '0', '0', '134', '134', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1927', '63', '133', '44', '22', '34', '15', '0', '0', '0', '994', '994', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1793', '62', '113', '20', '0', '8', '4', '0', '0', '0', '406', '406', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1745', '60', '12', '10', '8', '5', '2', '0', '0', '0', '153', '153', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1801', '61', '0', '28', '4', '16', '9', '0', '0', '0', '250', '250', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1765', '61', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1725', '60', '68', '9', '10', '2', '3', '0', '0', '0', '125', '125', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1789', '60', '92', '10', '2', '9', '7', '0', '0', '0', '205', '205', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1788', '59', '42', '3', '2', '0', '4', '0', '0', '0', '173', '173', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1890', '60', '47', '10', '10', '10', '6', '0', '0', '0', '294', '294', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1926', '60', '85', '2', '2', '4', '1', '0', '0', '0', '281', '281', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1901', '64', '0', '0', '0', '0', '0', '0', '0', '0', '350', '350', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1770', '64', '0', '0', '0', '0', '0', '0', '0', '0', '350', '350', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1771', '65', '0', '0', '0', '0', '0', '0', '0', '0', '400', '400', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1772', '66', '0', '0', '0', '0', '0', '0', '0', '0', '200', '200', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1918', '59', '4', '0', '0', '0', '2', '0', '0', '0', '175', '175', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1917', '60', '77', '1', '2', '7', '1', '0', '0', '0', '137', '137', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1779', '59', '23', '4', '2', '0', '2', '0', '0', '0', '276', '276', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1930', '62', '259', '20', '14', '11', '3', '0', '0', '0', '655', '655', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1916', '59', '23', '5', '3', '0', '0', '0', '0', '0', '236', '236', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1815', '59', '34', '3', '4', '0', '2', '0', '0', '0', '196', '196', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1818', '66', '0', '0', '0', '0', '0', '0', '0', '0', '200', '200', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1817', '66', '0', '0', '0', '0', '0', '0', '0', '0', '200', '200', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1820', '60', '99', '10', '10', '9', '0', '0', '0', '0', '171', '171', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1881', '60', '48', '9', '9', '6', '6', '0', '0', '0', '120', '120', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1920', '63', '142', '13', '1', '20', '7', '0', '0', '0', '898', '898', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1844', '64', '0', '0', '0', '0', '0', '0', '0', '0', '350', '350', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1845', '64', '0', '0', '0', '0', '0', '0', '0', '0', '350', '350', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1846', '64', '0', '0', '0', '0', '0', '0', '0', '0', '350', '350', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1847', '65', '0', '0', '0', '0', '0', '0', '0', '0', '400', '400', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1848', '65', '0', '0', '0', '0', '0', '0', '0', '0', '400', '400', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1849', '65', '0', '0', '0', '0', '0', '0', '0', '0', '400', '400', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1928', '59', '20', '5', '4', '0', '3', '0', '0', '0', '168', '168', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1900', '60', '88', '1', '10', '0', '1', '0', '0', '0', '230', '230', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1899', '62', '53', '12', '11', '10', '0', '0', '0', '0', '573', '573', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1888', '62', '31', '8', '10', '10', '3', '0', '0', '0', '648', '648', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1898', '62', '106', '4', '10', '5', '7', '0', '0', '0', '541', '541', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1903', '63', '930', '48', '37', '25', '21', '0', '0', '0', '727', '727', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1896', '65', '0', '0', '0', '0', '0', '0', '0', '0', '400', '400', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1923', '60', '3', '10', '8', '0', '5', '0', '0', '0', '119', '119', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1871', '62', '155', '15', '12', '18', '7', '0', '0', '0', '628', '628', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1919', '59', '38', '3', '4', '0', '1', '0', '0', '0', '149', '149', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1924', '59', '37', '3', '2', '0', '2', '0', '0', '0', '252', '252', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1886', '63', '267', '6', '19', '22', '5', '0', '0', '0', '930', '930', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1925', '59', '12', '0', '4', '0', '0', '0', '0', '0', '138', '138', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1884', '62', '193', '17', '2', '1', '2', '0', '0', '0', '538', '538', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1879', '63', '82', '33', '6', '17', '20', '0', '0', '0', '908', '908', '0', '1', '1', '1', '');
INSERT INTO `storage_equipment` VALUES ('1880', '63', '408', '12', '12', '19', '1', '0', '0', '0', '808', '808', '0', '1', '1', '1', '');
INSERT INTO `storage_item` VALUES ('58', '다람쥐의 도토리', '3', '0', '042-Item11.png', '다람쥐가 숨기려던 도토리다.', '5', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1', '', '0', '0');
INSERT INTO `storage_item` VALUES ('59', '다람쥐 귀걸이', '0', '0', 'ear.png', '다람쥐가 실수로 먹은 귀걸이. 그래서 다람쥐 귀걸이라는 이름이 붙여졌다.', '50', '3', '1', '0', '0', '0', '0', '10', '100', '100', '0', '1', '1', '1', '1', '', '0', '0');
INSERT INTO `storage_item` VALUES ('60', '들개가죽 신발', '0', '8', 'shoes.png', '들개의 가죽으로 만들어진 신발이다.', '100', '2', '2', '0', '2', '0', '0', '50', '100', '100', '0', '2', '1', '1', '1', '', '0', '0');
INSERT INTO `storage_item` VALUES ('61', '들개 이름표', '0', '2', 'neck.png', '들개가 사실 유기견이었던 것 같다.', '200', '5', '5', '0', '5', '0', '0', '70', '100', '100', '0', '3', '1', '1', '1', '', '0', '0');
INSERT INTO `storage_item` VALUES ('62', '호랑이 갑옷', '0', '4', 'armor.png', '호랑이 형님의 강인함이 담긴 갑옷이다.', '300', '10', '10', '3', '0', '0', '0', '200', '200', '200', '5', '4', '1', '1', '1', '', '0', '0');
INSERT INTO `storage_item` VALUES ('63', '호랑이 투구', '0', '1', 'helmet.png', '호랑의 형님의 강인함이 담긴 투구이다. 진정한 용사에게만 주어진다는 전설도 있다고 한다.', '500', '15', '15', '5', '5', '0', '0', '500', '200', '200', '5', '5', '1', '1', '1', '', '0', '0');
INSERT INTO `storage_item` VALUES ('64', '어둠의 힘이 깃든 검 + 5', '0', '3', 'weapon.png', '어둠의 힘이 깃들어 더욱 강력한 힘을 발휘하는 검이다. 특별한 경우에만 얻을 수 있다고 전해진다.', '2000', '110', '10', '0', '30', '0', '0', '500', '350', '350', '1', '5', '1', '1', '1', '', '0', '0');
INSERT INTO `storage_item` VALUES ('65', '어둠의 방패 + 5', '0', '5', 'shield.png', '어둠의 힘이 깃들어 더욱 강력한 힘을 발휘하는 방패다. 특별한 경우에만 얻을 수 있다고 전해진다.', '2000', '0', '100', '0', '0', '1000', '0', '500', '400', '400', '1', '5', '1', '1', '1', '', '0', '0');
INSERT INTO `storage_item` VALUES ('66', '어둠의 벨트', '0', '9', 'belt.png', '어둠의 힘이 깃든 벨트지만 이상하게 흔한 벨트다.', '300', '20', '10', '0', '10', '200', '0', '500', '200', '200', '0', '3', '1', '1', '1', '', '0', '0');
INSERT INTO `storage_item` VALUES ('67', '독버섯 잔해', '3', '0', '043-Item12.png', '독버섯의 잔해다.', '130', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1', '', '0', '0');
INSERT INTO `storage_item` VALUES ('68', '호랑이의 정기', '3', '0', '036-Item05.png', '호랑이의 힘이 담겨있는 정기이다.', '1000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1', '', '0', '0');
INSERT INTO `storage_item` VALUES ('69', '회복포션 Lv.1', '1', '0', '021-Potion01.png', '사용시 즉시 200의 HP를 회복합니다.', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1', 'RecoveryHpValue', '200', '15');
INSERT INTO `storage_item` VALUES ('70', '기술의 서 - 파이어', '1', '0', 'book.png', '파이어 기술을 배울 수 있는 기술의 서.', '5000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1', 'LearnCharacterSkill', '1', '0');
INSERT INTO `storage_item` VALUES ('71', '기술의 서 - 프론트 어택', '1', '0', 'book.png', '프론트 어택 기술을 배울 수 있는 기술의 서.', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1', 'LearnCharacterSkill', '2', '0');
INSERT INTO `storage_skill` VALUES ('1', '파이어어택', '공격함', '044-Skill01.png', 'attack', '1', '200', '1', '100', '30', '0', '3', '3', '2', '60', '2', '27');
INSERT INTO `storage_skill` VALUES ('2', '프론트 어택', '공격함', '044-Skill01.png', 'attack', '1', '200', '2', '100', '30', '1', '1', '1', '0', '10', '0', '10');
INSERT INTO `store` VALUES ('1', '이상한 상점');
INSERT INTO `store` VALUES ('2', '어둠의 상점');
INSERT INTO `store_item` VALUES ('11', '1', '61', '300', '-1', '0');
INSERT INTO `store_item` VALUES ('13', '1', '59', '100', '-1', '0');
INSERT INTO `store_item` VALUES ('8', '2', '64', '10000', '1', '0');
INSERT INTO `store_item` VALUES ('9', '2', '65', '10000', '1', '0');
INSERT INTO `store_item` VALUES ('10', '2', '66', '1000', '50', '0');
INSERT INTO `store_item` VALUES ('14', '1', '60', '250', '-1', '0');
INSERT INTO `store_item` VALUES ('15', '1', '62', '400', '10', '0');
INSERT INTO `store_item` VALUES ('16', '1', '63', '500', '10', '0');
INSERT INTO `store_item` VALUES ('17', '1', '69', '2', '-1', '0');
INSERT INTO `store_item` VALUES ('19', '1', '70', '1', '-1', '0');
INSERT INTO `store_item` VALUES ('20', '1', '71', '1', '-1', '0');
INSERT INTO `user_character` VALUES ('33', '201', 'admin', '008-Fighter08.png', '0', '4966196', '1', '0', '0', '100', '100', '1750', '100', '5', '5', '5', '5', '0', '1', '12', '11', '2', '4');
INSERT INTO `user_character` VALUES ('40', '205', 'ㅇ', '003-Fighter03.png', '0', '0', '1', '0', '0', '100', '100', '775', '100', '5', '5', '5', '5', '0', '1', '22', '8', '6', '4');
INSERT INTO `user_information` VALUES ('201', 'admin', 'admin', 'admin@naver.com', '가장 좋아하는 물건은?', 'admin', '0');
INSERT INTO `user_information` VALUES ('205', 'd', 'd', 'd@naver.com', '가장 좋아하는 물건은?', 'ㅇ', '0');
