﻿using project_euler.Maths.Sets;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem105 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return SumSpecialSumSets(input).ToString();
        }

        private static int SumSpecialSumSets(List<List<int>> input)
        {
            var sum = 0;
            foreach (var set in input)
            {
                var candidate = new SpecialSumSet();
                if (set.All(x => candidate.Add(x)))
                {
                    sum += set.Sum();
                }
            }
            return sum;
        }

        private readonly List<List<int>> input = new()
        {
            new List<int> { 81, 88, 75, 42, 87, 84, 86, 65 }
                                    ,
            new List<int> { 157, 150, 164, 119, 79, 159, 161, 139, 158 }
                                    ,
            new List<int> { 673, 465, 569, 603, 629, 592, 584, 300, 601, 599, 600 }
                                    ,
            new List<int> { 90, 85, 83, 84, 65, 87, 76, 46 }
                                    ,
            new List<int> { 165, 168, 169, 190, 162, 85, 176, 167, 127 }
                                    ,
            new List<int> { 224, 275, 278, 249, 277, 279, 289, 295, 139 }
                                    ,
            new List<int> { 354, 370, 362, 384, 359, 324, 360, 180, 350, 270 }
                                    ,
            new List<int> { 599, 595, 557, 298, 448, 596, 577, 667, 597, 588, 602 }
                                    ,
            new List<int> { 175, 199, 137, 88, 187, 173, 168, 171, 174 }
                                    ,
            new List<int> { 93, 187, 196, 144, 185, 178, 186, 202, 182 }
                                    ,
            new List<int> { 157, 155, 81, 158, 119, 176, 152, 167, 159 }
                                    ,
            new List<int> { 184, 165, 159, 166, 163, 167, 174, 124, 83 }
                                    ,
            new List<int> { 1211, 1212, 1287, 605, 1208, 1189, 1060, 1216, 1243, 1200, 908, 1210 }
                                    ,
            new List<int> { 339, 299, 153, 305, 282, 304, 313, 306, 302, 228 }
                                    ,
            new List<int> { 94, 104, 63, 112, 80, 84, 93, 96 }
                                    ,
            new List<int> { 41, 88, 82, 85, 61, 74, 83, 81 }
                                    ,
            new List<int> { 90, 67, 84, 83, 82, 97, 86, 41 }
                                    ,
            new List<int> { 299, 303, 151, 301, 291, 302, 307, 377, 333, 280 }
                                    ,
            new List<int> { 55, 40, 48, 44, 25, 42, 41 }
                                    ,
            new List<int> { 1038, 1188, 1255, 1184, 594, 890, 1173, 1151, 1186, 1203, 1187, 1195 }
                                    ,
            new List<int> { 76, 132, 133, 144, 135, 99, 128, 154 }
                                    ,
            new List<int> { 77, 46, 108, 81, 85, 84, 93, 83 }
                                    ,
            new List<int> { 624, 596, 391, 605, 529, 610, 607, 568, 604, 603, 453 }
                                    ,
            new List<int> { 83, 167, 166, 189, 163, 174, 160, 165, 133 }
                                    ,
            new List<int> { 308, 281, 389, 292, 346, 303, 302, 304, 300, 173 }
                                    ,
            new List<int> { 593, 1151, 1187, 1184, 890, 1040, 1173, 1186, 1195, 1255, 1188, 1203 }
                                    ,
            new List<int> { 68, 46, 64, 33, 60, 58, 65 }
                                    ,
            new List<int> { 65, 43, 88, 87, 86, 99, 93, 90 }
                                    ,
            new List<int> { 83, 78, 107, 48, 84, 87, 96, 85 }
                                    ,
            new List<int> { 1188, 1173, 1256, 1038, 1187, 1151, 890, 1186, 1184, 1203, 594, 1195 }
                                    ,
            new List<int> { 302, 324, 280, 296, 294, 160, 367, 298, 264, 299 }
                                    ,
            new List<int> { 521, 760, 682, 687, 646, 664, 342, 698, 692, 686, 672 }
                                    ,
            new List<int> { 56, 95, 86, 97, 96, 89, 108, 120 }
                                    ,
            new List<int> { 344, 356, 262, 343, 340, 382, 337, 175, 361, 330 }
                                    ,
            new List<int> { 47, 44, 42, 27, 41, 40, 37 }
                                    ,
            new List<int> { 139, 155, 161, 158, 118, 166, 154, 156, 78 }
                                    ,
            new List<int> { 118, 157, 164, 158, 161, 79, 139, 150, 159 }
                                    ,
            new List<int> { 299, 292, 371, 150, 300, 301, 281, 303, 306, 262 }
                                    ,
            new List<int> { 85, 77, 86, 84, 44, 88, 91, 67 }
                                    ,
            new List<int> { 88, 85, 84, 44, 65, 91, 76, 86 }
                                    ,
            new List<int> { 138, 141, 127, 96, 136, 154, 135, 76 }
                                    ,
            new List<int> { 292, 308, 302, 346, 300, 324, 304, 305, 238, 166 }
                                    ,
            new List<int> { 354, 342, 341, 257, 348, 343, 345, 321, 170, 301 }
                                    ,
            new List<int> { 84, 178, 168, 167, 131, 170, 193, 166, 162 }
                                    ,
            new List<int> { 686, 701, 706, 673, 694, 687, 652, 343, 683, 606, 518 }
                                    ,
            new List<int> { 295, 293, 301, 367, 296, 279, 297, 263, 323, 159 }
                                    ,
            new List<int> { 1038, 1184, 593, 890, 1188, 1173, 1187, 1186, 1195, 1150, 1203, 1255 }
                                    ,
            new List<int> { 343, 364, 388, 402, 191, 383, 382, 385, 288, 374 }
                                    ,
            new List<int> { 1187, 1036, 1183, 591, 1184, 1175, 888, 1197, 1182, 1219, 1115, 1167 }
                                    ,
            new List<int> { 151, 291, 307, 303, 345, 238, 299, 323, 301, 302 }
                                    ,
            new List<int> { 140, 151, 143, 138, 99, 69, 131, 137 }
                                    ,
            new List<int> { 29, 44, 42, 59, 41, 36, 40 }
                                    ,
            new List<int> { 348, 329, 343, 344, 338, 315, 169, 359, 375, 271 }
                                    ,
            new List<int> { 48, 39, 34, 37, 50, 40, 41 }
                                    ,
            new List<int> { 593, 445, 595, 558, 662, 602, 591, 297, 610, 580, 594 }
                                    ,
            new List<int> { 686, 651, 681, 342, 541, 687, 691, 707, 604, 675, 699 }
                                    ,
            new List<int> { 180, 99, 189, 166, 194, 188, 144, 187, 199 }
                                    ,
            new List<int> { 321, 349, 335, 343, 377, 176, 265, 356, 344, 332 }
                                    ,
            new List<int> { 1151, 1255, 1195, 1173, 1184, 1186, 1188, 1187, 1203, 593, 1038, 891 }
                                    ,
            new List<int> { 90, 88, 100, 83, 62, 113, 80, 89 }
                                    ,
            new List<int> { 308, 303, 238, 300, 151, 304, 324, 293, 346, 302 }
                                    ,
            new List<int> { 59, 38, 50, 41, 42, 35, 40 }
                                    ,
            new List<int> { 352, 366, 174, 355, 344, 265, 343, 310, 338, 331 }
                                    ,
            new List<int> { 91, 89, 93, 90, 117, 85, 60, 106 }
                                    ,
            new List<int> { 146, 186, 166, 175, 202, 92, 184, 183, 189 }
                                    ,
            new List<int> { 82, 67, 96, 44, 80, 79, 88, 76 }
                                    ,
            new List<int> { 54, 50, 58, 66, 31, 61, 64 }
                                    ,
            new List<int> { 343, 266, 344, 172, 308, 336, 364, 350, 359, 333 }
                                    ,
            new List<int> { 88, 49, 87, 82, 90, 98, 86, 115 }
                                    ,
            new List<int> { 20, 47, 49, 51, 54, 48, 40 }
                                    ,
            new List<int> { 159, 79, 177, 158, 157, 152, 155, 167, 118 }
                                    ,
            new List<int> { 1219, 1183, 1182, 1115, 1035, 1186, 591, 1197, 1167, 887, 1184, 1175 }
                                    ,
            new List<int> { 611, 518, 693, 343, 704, 667, 686, 682, 677, 687, 725 }
                                    ,
            new List<int> { 607, 599, 634, 305, 677, 604, 603, 580, 452, 605, 591 }
                                    ,
            new List<int> { 682, 686, 635, 675, 692, 730, 687, 342, 517, 658, 695 }
                                    ,
            new List<int> { 662, 296, 573, 598, 592, 584, 553, 593, 595, 443, 591 }
                                    ,
            new List<int> { 180, 185, 186, 199, 187, 210, 93, 177, 149 }
                                    ,
            new List<int> { 197, 136, 179, 185, 156, 182, 180, 178, 99 }
                                    ,
            new List<int> { 271, 298, 218, 279, 285, 282, 280, 238, 140 }
                                    ,
            new List<int> { 1187, 1151, 890, 593, 1194, 1188, 1184, 1173, 1038, 1186, 1255, 1203 }
                                    ,
            new List<int> { 169, 161, 177, 192, 130, 165, 84, 167, 168 }
                                    ,
            new List<int> { 50, 42, 43, 41, 66, 39, 36 }
                                    ,
            new List<int> { 590, 669, 604, 579, 448, 599, 560, 299, 601, 597, 598 }
                                    ,
            new List<int> { 174, 191, 206, 179, 184, 142, 177, 180, 90 }
                                    ,
            new List<int> { 298, 299, 297, 306, 164, 285, 374, 269, 329, 295 }
                                    ,
            new List<int> { 181, 172, 162, 138, 170, 195, 86, 169, 168 }
                                    ,
            new List<int> { 1184, 1197, 591, 1182, 1186, 889, 1167, 1219, 1183, 1033, 1115, 1175 }
                                    ,
            new List<int> { 644, 695, 691, 679, 667, 687, 340, 681, 770, 686, 517 }
                                    ,
            new List<int> { 606, 524, 592, 576, 628, 593, 591, 584, 296, 444, 595 }
                                    ,
            new List<int> { 94, 127, 154, 138, 135, 74, 136, 141 }
                                    ,
            new List<int> { 179, 168, 172, 178, 177, 89, 198, 186, 137 }
                                    ,
            new List<int> { 302, 299, 291, 300, 298, 149, 260, 305, 280, 370 }
                                    ,
            new List<int> { 678, 517, 670, 686, 682, 768, 687, 648, 342, 692, 702 }
                                    ,
            new List<int> { 302, 290, 304, 376, 333, 303, 306, 298, 279, 153 }
                                    ,
            new List<int> { 95, 102, 109, 54, 96, 75, 85, 97 }
                                    ,
            new List<int> { 150, 154, 146, 78, 152, 151, 162, 173, 119 }
                                    ,
            new List<int> { 150, 143, 157, 152, 184, 112, 154, 151, 132 }
                                    ,
            new List<int> { 36, 41, 54, 40, 25, 44, 42 }
                                    ,
            new List<int> { 37, 48, 34, 59, 39, 41, 40 }
                                    ,
            new List<int> { 681, 603, 638, 611, 584, 303, 454, 607, 606, 605, 596 }
        };
    }
}
