import numpy
cimport numpy
import math
import collections
import torch
cimport libc.math
cdef class Mut0:
    cdef public unsigned long long v0
    def __init__(self, unsigned long long v0): self.v0 = v0
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # Call
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # Fold
    def __init__(self): self.tag = 1
cdef class US1_2(US1): # RaiseTo
    cdef readonly signed short v0
    def __init__(self, signed short v0): self.tag = 2; self.v0 = v0
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # C1of2
    cdef readonly signed char v0
    def __init__(self, signed char v0): self.tag = 0; self.v0 = v0
cdef class US0_1(US0): # C2of2
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 1; self.v0 = v0
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # Cons
    cdef readonly US0 v0
    cdef readonly UH0 v1
    def __init__(self, US0 v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # Nil
    def __init__(self): self.tag = 1
cdef class Tuple0:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly signed char v8
    cdef readonly signed char v9
    cdef readonly unsigned char v10
    cdef readonly signed short v11
    cdef readonly signed char v12
    cdef readonly signed char v13
    cdef readonly unsigned char v14
    cdef readonly signed short v15
    cdef readonly object v16
    cdef readonly signed short v17
    cdef readonly signed short v18
    cdef readonly bint v19
    cdef readonly unsigned char v20
    cdef readonly signed short v21
    cdef readonly bint v22
    cdef readonly bint v23
    cdef readonly signed short v24
    cdef readonly signed short v25
    cdef readonly signed short v26
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, signed char v8, signed char v9, unsigned char v10, signed short v11, signed char v12, signed char v13, unsigned char v14, signed short v15, v16, signed short v17, signed short v18, bint v19, unsigned char v20, signed short v21, bint v22, bint v23, signed short v24, signed short v25, signed short v26): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23; self.v24 = v24; self.v25 = v25; self.v26 = v26
cdef class Tuple1:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly US1 v2
    def __init__(self, float v0, float v1, US1 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure1():
    def __init__(self): pass
    def __call__(self, v0):
        return v0
cdef class Tuple2:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Closure0():
    def __init__(self): pass
    def __call__(self, list v0):
        cdef unsigned long long v1
        cdef numpy.ndarray[object,ndim=1] v2
        cdef Mut0 v3
        cdef unsigned long long v5
        cdef float v6
        cdef float v7
        cdef UH0 v8
        cdef float v9
        cdef float v10
        cdef UH0 v11
        cdef float v12
        cdef float v13
        cdef signed char v14
        cdef signed char v15
        cdef unsigned char v16
        cdef signed short v17
        cdef signed char v18
        cdef signed char v19
        cdef unsigned char v20
        cdef signed short v21
        cdef numpy.ndarray[signed char,ndim=1] v22
        cdef signed short v23
        cdef signed short v24
        cdef bint v25
        cdef unsigned char v26
        cdef signed short v27
        cdef bint v28
        cdef bint v29
        cdef signed short v30
        cdef signed short v31
        cdef signed short v32
        cdef Tuple0 tmp0
        cdef US1 v33
        cdef unsigned long long v34
        cdef object v35
        v1 = len(v0)
        v2 = numpy.empty(v1,dtype=object)
        v3 = Mut0((<unsigned long long>0))
        while method0(v1, v3):
            v5 = v3.v0
            tmp0 = v0[v5]
            v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16, tmp0.v17, tmp0.v18, tmp0.v19, tmp0.v20, tmp0.v21, tmp0.v22, tmp0.v23, tmp0.v24, tmp0.v25, tmp0.v26
            del tmp0
            del v8; del v11; del v22
            v33 = US1_0()
            v2[v5] = Tuple1((<float>0), (<float>0), v33)
            del v33
            v34 = v5 + (<unsigned long long>1)
            v3.v0 = v34
        del v3
        v35 = Closure1()
        return Tuple2(v2, v35)
cdef class Mut1:
    cdef public unsigned long long v0
    cdef public unsigned long long v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, unsigned long long v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple3:
    cdef readonly signed char v0
    cdef readonly signed char v1
    cdef readonly signed char v2
    cdef readonly signed char v3
    cdef readonly signed char v4
    cdef readonly signed char v5
    def __init__(self, signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5
cdef class Mut2:
    cdef public signed short v0
    cdef public unsigned long long v1
    def __init__(self, signed short v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
cdef class Tuple4:
    cdef readonly signed char v0
    cdef readonly signed char v1
    cdef readonly signed char v2
    cdef readonly signed char v3
    cdef readonly signed char v4
    def __init__(self, signed char v0, signed char v1, signed char v2, signed char v3, signed char v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple5:
    cdef readonly signed char v0
    cdef readonly signed char v1
    cdef readonly signed char v2
    cdef readonly signed char v3
    def __init__(self, signed char v0, signed char v1, signed char v2, signed char v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class US2:
    cdef readonly signed long tag
cdef class US2_0(US2): # PAction
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 0; self.v0 = v0
cdef class US2_1(US2): # PCardPresent
    cdef readonly signed char v0
    def __init__(self, signed char v0): self.tag = 1; self.v0 = v0
cdef class US2_2(US2): # PInfo
    cdef readonly signed char v0
    cdef readonly signed char v1
    def __init__(self, signed char v0, signed char v1): self.tag = 2; self.v0 = v0; self.v1 = v1
cdef class UH1:
    cdef readonly signed long tag
cdef class UH1_0(UH1): # Cons
    cdef readonly US2 v0
    cdef readonly UH1 v1
    def __init__(self, US2 v0, UH1 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH1_1(UH1): # Nil
    def __init__(self): self.tag = 1
cdef class US3:
    cdef readonly signed long tag
cdef class US3_0(US3): # VCardFuture
    cdef readonly signed char v0
    def __init__(self, signed char v0): self.tag = 0; self.v0 = v0
cdef class US3_1(US3): # VCardOpponent
    cdef readonly signed char v0
    def __init__(self, signed char v0): self.tag = 1; self.v0 = v0
cdef class US3_2(US3): # VInfo
    cdef readonly signed long v0
    cdef readonly signed char v1
    cdef readonly signed char v2
    def __init__(self, signed long v0, signed char v1, signed char v2): self.tag = 2; self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class US3_3(US3): # VPolicy
    cdef readonly US2 v0
    def __init__(self, US2 v0): self.tag = 3; self.v0 = v0
cdef class UH2:
    cdef readonly signed long tag
cdef class UH2_0(UH2): # Cons
    cdef readonly US3 v0
    cdef readonly UH2 v1
    def __init__(self, US3 v0, UH2 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH2_1(UH2): # Nil
    def __init__(self): self.tag = 1
cdef class Mut3:
    cdef public signed short v0
    cdef public UH2 v1
    def __init__(self, signed short v0, UH2 v1): self.v0 = v0; self.v1 = v1
cdef class Mut4:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut5:
    cdef public signed short v0
    def __init__(self, signed short v0): self.v0 = v0
cdef class Closure4():
    cdef signed short v0
    cdef signed short v1
    cdef signed short v2
    cdef signed short v3
    cdef signed short v4
    cdef object v5
    def __init__(self, signed short v0, signed short v1, signed short v2, signed short v3, signed short v4, v5): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5
    def __call__(self, list v6):
        cdef signed short v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed short v4 = self.v4
        cdef object v5 = self.v5
        cdef unsigned long long v7
        cdef bint v8
        cdef numpy.ndarray[object,ndim=1] v9
        cdef object v10
        cdef unsigned long long v11
        cdef unsigned long long v12
        cdef Mut1 v13
        cdef unsigned long long v15
        cdef unsigned long long v16
        cdef unsigned long long v17
        cdef float v18
        cdef float v19
        cdef UH0 v20
        cdef float v21
        cdef float v22
        cdef UH0 v23
        cdef float v24
        cdef float v25
        cdef signed char v26
        cdef signed char v27
        cdef unsigned char v28
        cdef signed short v29
        cdef signed char v30
        cdef signed char v31
        cdef unsigned char v32
        cdef signed short v33
        cdef numpy.ndarray[signed char,ndim=1] v34
        cdef signed short v35
        cdef signed short v36
        cdef bint v37
        cdef unsigned char v38
        cdef signed short v39
        cdef bint v40
        cdef bint v41
        cdef signed short v42
        cdef signed short v43
        cdef signed short v44
        cdef Tuple0 tmp1
        cdef numpy.ndarray[signed char,ndim=1] v45
        cdef numpy.ndarray[signed char,ndim=1] v46
        cdef bint v47
        cdef UH0 v48
        cdef signed char v49
        cdef signed char v50
        cdef signed char v51
        cdef signed char v52
        cdef signed char v53
        cdef signed char v54
        cdef Tuple3 tmp19
        cdef signed char v55
        cdef signed char v56
        cdef signed char v57
        cdef signed char v58
        cdef signed char v59
        cdef signed char v60
        cdef Tuple3 tmp21
        cdef US2 v61
        cdef UH1 v62
        cdef UH1 v63
        cdef UH1 v64
        cdef signed char v65
        cdef signed char v66
        cdef signed char v67
        cdef signed char v68
        cdef signed char v69
        cdef signed char v70
        cdef Tuple3 tmp22
        cdef signed char v71
        cdef signed char v72
        cdef signed char v73
        cdef signed char v74
        cdef signed char v75
        cdef signed char v76
        cdef Tuple3 tmp23
        cdef signed char v77
        cdef signed char v78
        cdef signed char v79
        cdef signed char v80
        cdef signed char v81
        cdef signed char v82
        cdef Tuple3 tmp24
        cdef signed char v83
        cdef signed char v84
        cdef signed char v85
        cdef signed char v86
        cdef signed char v87
        cdef signed char v88
        cdef Tuple3 tmp25
        cdef signed char v89
        cdef signed char v90
        cdef signed char v91
        cdef signed char v92
        cdef signed char v93
        cdef signed char v94
        cdef signed char v95
        cdef signed char v96
        cdef signed char v97
        cdef signed char v98
        cdef bint v99
        cdef signed long v102
        cdef bint v100
        cdef bint v103
        cdef signed long v132
        cdef bint v104
        cdef signed long v107
        cdef bint v105
        cdef bint v108
        cdef bint v109
        cdef signed long v112
        cdef bint v110
        cdef bint v113
        cdef bint v114
        cdef signed long v117
        cdef bint v115
        cdef bint v118
        cdef bint v119
        cdef signed long v122
        cdef bint v120
        cdef bint v123
        cdef bint v124
        cdef bint v125
        cdef signed short v133
        cdef unsigned long long tmp26
        cdef US3 v134
        cdef US3 v135
        cdef US3 v136
        cdef UH2 v137
        cdef UH2 v138
        cdef UH2 v139
        cdef UH2 v140
        cdef Mut3 v141
        cdef signed short v143
        cdef signed short v144
        cdef signed short v145
        cdef signed short v146
        cdef UH2 v147
        cdef signed char v148
        cdef signed short v149
        cdef US3 v150
        cdef UH2 v151
        cdef UH2 v152
        cdef UH2 v153
        cdef unsigned long long v154
        cdef unsigned long long v155
        cdef bint v156
        cdef unsigned long long v157
        cdef unsigned long long v158
        cdef unsigned long long v159
        cdef bint v160
        cdef unsigned long long v161
        cdef unsigned long long v162
        cdef unsigned long long v163
        cdef unsigned long long v164
        cdef numpy.ndarray[float,ndim=3] v165
        cdef numpy.ndarray[signed char,ndim=2] v166
        cdef numpy.ndarray[float,ndim=3] v167
        cdef numpy.ndarray[signed char,ndim=2] v168
        cdef numpy.ndarray[float,ndim=3] v169
        cdef numpy.ndarray[signed char,ndim=2] v170
        cdef numpy.ndarray[object,ndim=1] v171
        cdef numpy.ndarray[float,ndim=1] v172
        cdef unsigned long long v173
        cdef Mut0 v174
        cdef unsigned long long v176
        cdef float v177
        cdef float v178
        cdef UH0 v179
        cdef float v180
        cdef float v181
        cdef UH0 v182
        cdef float v183
        cdef float v184
        cdef signed char v185
        cdef signed char v186
        cdef unsigned char v187
        cdef signed short v188
        cdef signed char v189
        cdef signed char v190
        cdef unsigned char v191
        cdef signed short v192
        cdef numpy.ndarray[signed char,ndim=1] v193
        cdef signed short v194
        cdef signed short v195
        cdef bint v196
        cdef unsigned char v197
        cdef signed short v198
        cdef bint v199
        cdef bint v200
        cdef signed short v201
        cdef signed short v202
        cdef signed short v203
        cdef Tuple0 tmp27
        cdef numpy.ndarray[signed char,ndim=1] v204
        cdef numpy.ndarray[signed char,ndim=1] v205
        cdef bint v206
        cdef UH0 v207
        cdef signed char v208
        cdef signed char v209
        cdef signed char v210
        cdef signed char v211
        cdef signed char v212
        cdef signed char v213
        cdef Tuple3 tmp28
        cdef signed char v214
        cdef signed char v215
        cdef signed char v216
        cdef signed char v217
        cdef signed char v218
        cdef signed char v219
        cdef Tuple3 tmp29
        cdef US2 v220
        cdef UH1 v221
        cdef UH1 v222
        cdef UH1 v223
        cdef signed char v224
        cdef signed char v225
        cdef signed char v226
        cdef signed char v227
        cdef signed char v228
        cdef signed char v229
        cdef Tuple3 tmp30
        cdef signed char v230
        cdef signed char v231
        cdef signed char v232
        cdef signed char v233
        cdef signed char v234
        cdef signed char v235
        cdef Tuple3 tmp31
        cdef signed char v236
        cdef signed char v237
        cdef signed char v238
        cdef signed char v239
        cdef signed char v240
        cdef signed char v241
        cdef Tuple3 tmp32
        cdef signed char v242
        cdef signed char v243
        cdef signed char v244
        cdef signed char v245
        cdef signed char v246
        cdef signed char v247
        cdef Tuple3 tmp33
        cdef signed char v248
        cdef signed char v249
        cdef signed char v250
        cdef signed char v251
        cdef signed char v252
        cdef signed char v253
        cdef signed char v254
        cdef signed char v255
        cdef signed char v256
        cdef signed char v257
        cdef bint v258
        cdef signed long v261
        cdef bint v259
        cdef bint v262
        cdef signed long v291
        cdef bint v263
        cdef signed long v266
        cdef bint v264
        cdef bint v267
        cdef bint v268
        cdef signed long v271
        cdef bint v269
        cdef bint v272
        cdef bint v273
        cdef signed long v276
        cdef bint v274
        cdef bint v277
        cdef bint v278
        cdef signed long v281
        cdef bint v279
        cdef bint v282
        cdef bint v283
        cdef bint v284
        cdef signed short v292
        cdef unsigned long long tmp34
        cdef US3 v293
        cdef US3 v294
        cdef US3 v295
        cdef UH2 v296
        cdef UH2 v297
        cdef UH2 v298
        cdef UH2 v299
        cdef Mut3 v300
        cdef signed short v302
        cdef signed short v303
        cdef signed short v304
        cdef signed short v305
        cdef UH2 v306
        cdef signed char v307
        cdef signed short v308
        cdef US3 v309
        cdef UH2 v310
        cdef UH2 v311
        cdef UH2 v312
        cdef unsigned long long v313
        cdef unsigned long long v314
        cdef unsigned long long v315
        cdef unsigned long long v316
        cdef unsigned long long v317
        cdef unsigned long long v318
        cdef Mut4 v319
        cdef list v320
        cdef US1 v321
        cdef US1 v322
        cdef signed short v323
        cdef signed short v324
        cdef signed short v325
        cdef signed short v326
        cdef bint v327
        cdef Mut5 v328
        cdef signed short v330
        cdef US1 v331
        cdef signed short v332
        cdef signed short v333
        cdef bint v334
        cdef bint v340
        cdef bint v335
        cdef bint v336
        cdef US1 v341
        cdef signed short v342
        cdef bint v343
        cdef bint v349
        cdef bint v344
        cdef bint v345
        cdef US1 v350
        cdef signed short v351
        cdef signed short v352
        cdef signed short v353
        cdef signed short v354
        cdef bint v355
        cdef bint v361
        cdef bint v356
        cdef bint v357
        cdef US1 v362
        cdef signed short v363
        cdef signed short v364
        cdef signed short v365
        cdef bint v366
        cdef bint v372
        cdef bint v367
        cdef bint v368
        cdef US1 v373
        cdef signed short v374
        cdef signed short v375
        cdef signed short v376
        cdef signed short v377
        cdef bint v378
        cdef bint v384
        cdef bint v379
        cdef bint v380
        cdef US1 v385
        cdef signed short v386
        cdef signed short v387
        cdef bint v388
        cdef bint v394
        cdef bint v389
        cdef bint v390
        cdef US1 v395
        cdef signed short v396
        cdef bint v397
        cdef float v398
        cdef float v399
        cdef float v400
        cdef float v402
        cdef float v403
        cdef float v404
        cdef signed short v405
        cdef signed short v406
        cdef bint v407
        cdef bint v413
        cdef bint v408
        cdef bint v409
        cdef US1 v414
        cdef float v415
        cdef float v416
        cdef float v417
        cdef float v418
        cdef float v419
        cdef float v421
        cdef float v422
        cdef float v423
        cdef float v424
        cdef signed short v425
        cdef signed short v426
        cdef bint v427
        cdef bint v433
        cdef bint v428
        cdef bint v429
        cdef US1 v434
        cdef numpy.ndarray[object,ndim=1] v435
        cdef signed short v436
        cdef unsigned long long tmp35
        cdef Mut5 v437
        cdef signed short v439
        cdef US1 v440
        cdef numpy.ndarray[float,ndim=1] v441
        cdef signed short v442
        cdef signed short v443
        cdef signed short v444
        cdef float v445
        cdef unsigned long long v446
        cdef object v447
        cdef object v448
        cdef object v449
        cdef object v450
        cdef object v451
        cdef object v452
        cdef object v453
        cdef object v454
        cdef object v455
        cdef object v456
        cdef object v457
        cdef numpy.ndarray[float,ndim=2] v458
        cdef numpy.ndarray[signed long long,ndim=1] v459
        cdef object v460
        cdef numpy.ndarray[object,ndim=1] v461
        cdef Mut0 v462
        cdef unsigned long long v464
        cdef signed long long v465
        cdef bint v466
        cdef float v468
        cdef float v469
        cdef numpy.ndarray[object,ndim=1] v470
        cdef signed short v471
        cdef US1 v472
        cdef unsigned long long v473
        v7 = len(v6)
        v8 = v7 == (<unsigned long long>0)
        if v8:
            v9 = numpy.empty((<unsigned long long>0),dtype=object)
            v10 = Closure1()
            return Tuple2(v9, v10)
        else:
            pass # import torch
            v11 = len(v6)
            v12 = len(v6)
            v13 = Mut1((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
            while method1(v12, v13):
                v15 = v13.v0
                v16, v17 = v13.v1, v13.v2
                tmp1 = v6[v15]
                v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44 = tmp1.v0, tmp1.v1, tmp1.v2, tmp1.v3, tmp1.v4, tmp1.v5, tmp1.v6, tmp1.v7, tmp1.v8, tmp1.v9, tmp1.v10, tmp1.v11, tmp1.v12, tmp1.v13, tmp1.v14, tmp1.v15, tmp1.v16, tmp1.v17, tmp1.v18, tmp1.v19, tmp1.v20, tmp1.v21, tmp1.v22, tmp1.v23, tmp1.v24, tmp1.v25, tmp1.v26
                del tmp1
                v45 = v34[:v35]
                v46 = v34[v35:]
                v47 = v38 == (<unsigned char>0)
                if v47:
                    v48 = v20
                else:
                    v48 = v23
                del v20; del v23
                tmp19 = method2(v27, v26, v45)
                v49, v50, v51, v52, v53, v54 = tmp19.v0, tmp19.v1, tmp19.v2, tmp19.v3, tmp19.v4, tmp19.v5
                del tmp19
                tmp21 = method23(v45)
                v55, v56, v57, v58, v59, v60 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3, tmp21.v4, tmp21.v5
                del tmp21
                del v45
                v61 = US2_2(v54, v60)
                v62 = UH1_1()
                v63 = UH1_0(v61, v62)
                del v61; del v62
                v64 = method24(v48, v63)
                del v48; del v63
                tmp22 = method2(v27, v26, v34)
                v65, v66, v67, v68, v69, v70 = tmp22.v0, tmp22.v1, tmp22.v2, tmp22.v3, tmp22.v4, tmp22.v5
                del tmp22
                tmp23 = method2(v31, v30, v34)
                v71, v72, v73, v74, v75, v76 = tmp23.v0, tmp23.v1, tmp23.v2, tmp23.v3, tmp23.v4, tmp23.v5
                del tmp23
                tmp24 = method2(v27, v26, v34)
                v77, v78, v79, v80, v81, v82 = tmp24.v0, tmp24.v1, tmp24.v2, tmp24.v3, tmp24.v4, tmp24.v5
                del tmp24
                tmp25 = method2(v31, v30, v34)
                v83, v84, v85, v86, v87, v88 = tmp25.v0, tmp25.v1, tmp25.v2, tmp25.v3, tmp25.v4, tmp25.v5
                del tmp25
                del v34
                v89 = v77 % (<signed char>13)
                v90 = v78 % (<signed char>13)
                v91 = v79 % (<signed char>13)
                v92 = v80 % (<signed char>13)
                v93 = v81 % (<signed char>13)
                v94 = v83 % (<signed char>13)
                v95 = v84 % (<signed char>13)
                v96 = v85 % (<signed char>13)
                v97 = v86 % (<signed char>13)
                v98 = v87 % (<signed char>13)
                v99 = v82 < v88
                if v99:
                    v102 = (<signed long>-1)
                else:
                    v100 = v82 > v88
                    if v100:
                        v102 = (<signed long>1)
                    else:
                        v102 = (<signed long>0)
                v103 = v102 == (<signed long>0)
                if v103:
                    v104 = v89 < v94
                    if v104:
                        v107 = (<signed long>-1)
                    else:
                        v105 = v89 > v94
                        if v105:
                            v107 = (<signed long>1)
                        else:
                            v107 = (<signed long>0)
                    v108 = v107 == (<signed long>0)
                    if v108:
                        v109 = v90 < v95
                        if v109:
                            v112 = (<signed long>-1)
                        else:
                            v110 = v90 > v95
                            if v110:
                                v112 = (<signed long>1)
                            else:
                                v112 = (<signed long>0)
                        v113 = v112 == (<signed long>0)
                        if v113:
                            v114 = v91 < v96
                            if v114:
                                v117 = (<signed long>-1)
                            else:
                                v115 = v91 > v96
                                if v115:
                                    v117 = (<signed long>1)
                                else:
                                    v117 = (<signed long>0)
                            v118 = v117 == (<signed long>0)
                            if v118:
                                v119 = v92 < v97
                                if v119:
                                    v122 = (<signed long>-1)
                                else:
                                    v120 = v92 > v97
                                    if v120:
                                        v122 = (<signed long>1)
                                    else:
                                        v122 = (<signed long>0)
                                v123 = v122 == (<signed long>0)
                                if v123:
                                    v124 = v93 < v98
                                    if v124:
                                        v132 = (<signed long>-1)
                                    else:
                                        v125 = v93 > v98
                                        if v125:
                                            v132 = (<signed long>1)
                                        else:
                                            v132 = (<signed long>0)
                                else:
                                    v132 = v122
                            else:
                                v132 = v117
                        else:
                            v132 = v112
                    else:
                        v132 = v107
                else:
                    v132 = v102
                tmp26 = len(v46)
                if <signed short>tmp26 != tmp26: raise Exception("The conversion to signed short failed.")
                v133 = <signed short>tmp26
                v134 = US3_1(v30)
                v135 = US3_1(v31)
                v136 = US3_2(v132, v76, v70)
                v137 = UH2_1()
                v138 = UH2_0(v136, v137)
                del v136; del v137
                v139 = UH2_0(v135, v138)
                del v135; del v138
                v140 = UH2_0(v134, v139)
                del v134; del v139
                v141 = Mut3((<signed short>0), v140)
                del v140
                while method25(v133, v141):
                    v143 = v141.v0
                    v144 = -v143
                    v145 = v144 + v133
                    v146 = v145 - (<signed short>1)
                    v147 = v141.v1
                    v148 = v46[v146]
                    v149 = v143 + (<signed short>1)
                    v150 = US3_0(v148)
                    v151 = UH2_0(v150, v147)
                    del v147; del v150
                    v141.v0 = v149
                    v141.v1 = v151
                    del v151
                del v46
                v152 = v141.v1
                del v141
                v153 = method26(v64, v152)
                del v152
                v154 = (<unsigned long long>0)
                v155 = method27(v64, v154)
                del v64
                v156 = v16 >= v155
                if v156:
                    v157 = v16
                else:
                    v157 = v155
                v158 = (<unsigned long long>0)
                v159 = method28(v153, v158)
                del v153
                v160 = v17 >= v159
                if v160:
                    v161 = v17
                else:
                    v161 = v159
                v162 = v15 + (<unsigned long long>1)
                v13.v0 = v162
                v13.v1 = v157
                v13.v2 = v161
            v163, v164 = v13.v1, v13.v2
            del v13
            v165 = numpy.zeros((v11,v163,v3),dtype=numpy.float32)
            v166 = numpy.zeros((v11,v163),dtype=numpy.int8)
            v167 = numpy.zeros((v11,v164,v4),dtype=numpy.float32)
            v168 = numpy.zeros((v11,v164),dtype=numpy.int8)
            v169 = numpy.zeros((v11,(<signed short>16),v1),dtype=numpy.float32)
            v170 = numpy.ones((v11,(<signed short>16)),dtype=numpy.int8)
            v171 = numpy.empty(v11,dtype=object)
            v172 = numpy.empty(v11,dtype=numpy.float32)
            v173 = len(v6)
            v174 = Mut0((<unsigned long long>0))
            while method0(v173, v174):
                v176 = v174.v0
                tmp27 = v6[v176]
                v177, v178, v179, v180, v181, v182, v183, v184, v185, v186, v187, v188, v189, v190, v191, v192, v193, v194, v195, v196, v197, v198, v199, v200, v201, v202, v203 = tmp27.v0, tmp27.v1, tmp27.v2, tmp27.v3, tmp27.v4, tmp27.v5, tmp27.v6, tmp27.v7, tmp27.v8, tmp27.v9, tmp27.v10, tmp27.v11, tmp27.v12, tmp27.v13, tmp27.v14, tmp27.v15, tmp27.v16, tmp27.v17, tmp27.v18, tmp27.v19, tmp27.v20, tmp27.v21, tmp27.v22, tmp27.v23, tmp27.v24, tmp27.v25, tmp27.v26
                del tmp27
                v204 = v193[:v194]
                v205 = v193[v194:]
                v206 = v197 == (<unsigned char>0)
                if v206:
                    v207 = v179
                else:
                    v207 = v182
                del v179; del v182
                tmp28 = method2(v186, v185, v204)
                v208, v209, v210, v211, v212, v213 = tmp28.v0, tmp28.v1, tmp28.v2, tmp28.v3, tmp28.v4, tmp28.v5
                del tmp28
                tmp29 = method23(v204)
                v214, v215, v216, v217, v218, v219 = tmp29.v0, tmp29.v1, tmp29.v2, tmp29.v3, tmp29.v4, tmp29.v5
                del tmp29
                del v204
                v220 = US2_2(v213, v219)
                v221 = UH1_1()
                v222 = UH1_0(v220, v221)
                del v220; del v221
                v223 = method24(v207, v222)
                del v207; del v222
                tmp30 = method2(v186, v185, v193)
                v224, v225, v226, v227, v228, v229 = tmp30.v0, tmp30.v1, tmp30.v2, tmp30.v3, tmp30.v4, tmp30.v5
                del tmp30
                tmp31 = method2(v190, v189, v193)
                v230, v231, v232, v233, v234, v235 = tmp31.v0, tmp31.v1, tmp31.v2, tmp31.v3, tmp31.v4, tmp31.v5
                del tmp31
                tmp32 = method2(v186, v185, v193)
                v236, v237, v238, v239, v240, v241 = tmp32.v0, tmp32.v1, tmp32.v2, tmp32.v3, tmp32.v4, tmp32.v5
                del tmp32
                tmp33 = method2(v190, v189, v193)
                v242, v243, v244, v245, v246, v247 = tmp33.v0, tmp33.v1, tmp33.v2, tmp33.v3, tmp33.v4, tmp33.v5
                del tmp33
                del v193
                v248 = v236 % (<signed char>13)
                v249 = v237 % (<signed char>13)
                v250 = v238 % (<signed char>13)
                v251 = v239 % (<signed char>13)
                v252 = v240 % (<signed char>13)
                v253 = v242 % (<signed char>13)
                v254 = v243 % (<signed char>13)
                v255 = v244 % (<signed char>13)
                v256 = v245 % (<signed char>13)
                v257 = v246 % (<signed char>13)
                v258 = v241 < v247
                if v258:
                    v261 = (<signed long>-1)
                else:
                    v259 = v241 > v247
                    if v259:
                        v261 = (<signed long>1)
                    else:
                        v261 = (<signed long>0)
                v262 = v261 == (<signed long>0)
                if v262:
                    v263 = v248 < v253
                    if v263:
                        v266 = (<signed long>-1)
                    else:
                        v264 = v248 > v253
                        if v264:
                            v266 = (<signed long>1)
                        else:
                            v266 = (<signed long>0)
                    v267 = v266 == (<signed long>0)
                    if v267:
                        v268 = v249 < v254
                        if v268:
                            v271 = (<signed long>-1)
                        else:
                            v269 = v249 > v254
                            if v269:
                                v271 = (<signed long>1)
                            else:
                                v271 = (<signed long>0)
                        v272 = v271 == (<signed long>0)
                        if v272:
                            v273 = v250 < v255
                            if v273:
                                v276 = (<signed long>-1)
                            else:
                                v274 = v250 > v255
                                if v274:
                                    v276 = (<signed long>1)
                                else:
                                    v276 = (<signed long>0)
                            v277 = v276 == (<signed long>0)
                            if v277:
                                v278 = v251 < v256
                                if v278:
                                    v281 = (<signed long>-1)
                                else:
                                    v279 = v251 > v256
                                    if v279:
                                        v281 = (<signed long>1)
                                    else:
                                        v281 = (<signed long>0)
                                v282 = v281 == (<signed long>0)
                                if v282:
                                    v283 = v252 < v257
                                    if v283:
                                        v291 = (<signed long>-1)
                                    else:
                                        v284 = v252 > v257
                                        if v284:
                                            v291 = (<signed long>1)
                                        else:
                                            v291 = (<signed long>0)
                                else:
                                    v291 = v281
                            else:
                                v291 = v276
                        else:
                            v291 = v271
                    else:
                        v291 = v266
                else:
                    v291 = v261
                tmp34 = len(v205)
                if <signed short>tmp34 != tmp34: raise Exception("The conversion to signed short failed.")
                v292 = <signed short>tmp34
                v293 = US3_1(v189)
                v294 = US3_1(v190)
                v295 = US3_2(v291, v235, v229)
                v296 = UH2_1()
                v297 = UH2_0(v295, v296)
                del v295; del v296
                v298 = UH2_0(v294, v297)
                del v294; del v297
                v299 = UH2_0(v293, v298)
                del v293; del v298
                v300 = Mut3((<signed short>0), v299)
                del v299
                while method25(v292, v300):
                    v302 = v300.v0
                    v303 = -v302
                    v304 = v303 + v292
                    v305 = v304 - (<signed short>1)
                    v306 = v300.v1
                    v307 = v205[v305]
                    v308 = v302 + (<signed short>1)
                    v309 = US3_0(v307)
                    v310 = UH2_0(v309, v306)
                    del v306; del v309
                    v300.v0 = v308
                    v300.v1 = v310
                    del v310
                del v205
                v311 = v300.v1
                del v300
                v312 = method26(v223, v311)
                del v311
                v313 = (<unsigned long long>0)
                v314 = method29(v0, v1, v2, v3, v4, v165, v176, v223, v313)
                del v223
                method32(v163, v166, v176, v314)
                v315 = (<unsigned long long>0)
                v316 = method33(v0, v1, v2, v3, v4, v167, v176, v312, v315)
                del v312
                method34(v164, v168, v176, v316)
                v317 = (<unsigned long long>3)
                v318 = (<unsigned long long>7)
                v319 = method35(v317, v318)
                v320 = [None]*(<signed short>0)
                if v199:
                    v321 = US1_1()
                    v320.append(v321)
                    del v321
                else:
                    pass
                v322 = US1_0()
                v320.append(v322)
                del v322
                if v200:
                    v323 = len(v320)
                    v324 = (<signed short>16) - v323
                    v325 = (<signed short>1) + v201
                    v326 = v325 - v202
                    v327 = v326 <= v324
                    if v327:
                        v328 = Mut5(v202)
                        while method36(v325, v328):
                            v330 = v328.v0
                            v331 = US1_2(v330)
                            v320.append(v331)
                            del v331
                            v332 = v330 + (<signed short>1)
                            v328.v0 = v332
                        del v328
                    else:
                        v333 = len(v320)
                        v334 = v333 < (<signed short>16)
                        if v334:
                            v335 = v202 <= v202
                            if v335:
                                v336 = v202 <= v201
                                if v336:
                                    v340 = method37(v319, v202)
                                else:
                                    v340 = 0
                            else:
                                v340 = 0
                        else:
                            v340 = 0
                        if v340:
                            v341 = US1_2(v202)
                            v320.append(v341)
                            del v341
                        else:
                            pass
                        v342 = len(v320)
                        v343 = v342 < (<signed short>16)
                        if v343:
                            v344 = v202 <= v201
                            if v344:
                                v345 = v201 <= v201
                                if v345:
                                    v349 = method37(v319, v201)
                                else:
                                    v349 = 0
                            else:
                                v349 = 0
                        else:
                            v349 = 0
                        if v349:
                            v350 = US1_2(v201)
                            v320.append(v350)
                            del v350
                        else:
                            pass
                        v351 = (<signed short>2) * v198
                        v352 = v351 // (<signed short>4)
                        v353 = v198 + v352
                        v354 = len(v320)
                        v355 = v354 < (<signed short>16)
                        if v355:
                            v356 = v202 <= v353
                            if v356:
                                v357 = v353 <= v201
                                if v357:
                                    v361 = method37(v319, v353)
                                else:
                                    v361 = 0
                            else:
                                v361 = 0
                        else:
                            v361 = 0
                        if v361:
                            v362 = US1_2(v353)
                            v320.append(v362)
                            del v362
                        else:
                            pass
                        v363 = v351 // (<signed short>2)
                        v364 = v198 + v363
                        v365 = len(v320)
                        v366 = v365 < (<signed short>16)
                        if v366:
                            v367 = v202 <= v364
                            if v367:
                                v368 = v364 <= v201
                                if v368:
                                    v372 = method37(v319, v364)
                                else:
                                    v372 = 0
                            else:
                                v372 = 0
                        else:
                            v372 = 0
                        if v372:
                            v373 = US1_2(v364)
                            v320.append(v373)
                            del v373
                        else:
                            pass
                        v374 = v351 * (<signed short>3)
                        v375 = v374 // (<signed short>4)
                        v376 = v198 + v375
                        v377 = len(v320)
                        v378 = v377 < (<signed short>16)
                        if v378:
                            v379 = v202 <= v376
                            if v379:
                                v380 = v376 <= v201
                                if v380:
                                    v384 = method37(v319, v376)
                                else:
                                    v384 = 0
                            else:
                                v384 = 0
                        else:
                            v384 = 0
                        if v384:
                            v385 = US1_2(v376)
                            v320.append(v385)
                            del v385
                        else:
                            pass
                        v386 = v198 + v351
                        v387 = len(v320)
                        v388 = v387 < (<signed short>16)
                        if v388:
                            v389 = v202 <= v386
                            if v389:
                                v390 = v386 <= v201
                                if v390:
                                    v394 = method37(v319, v386)
                                else:
                                    v394 = 0
                            else:
                                v394 = 0
                        else:
                            v394 = 0
                        if v394:
                            v395 = US1_2(v386)
                            v320.append(v395)
                            del v395
                        else:
                            pass
                        v396 = v326 * (<signed short>3)
                        v397 = v396 <= v324
                        if v397:
                            v398 = <float>v202
                            v399 = <float>v201
                            v400 = v399 - v398
                            while method42(v320):
                                v402 = numpy.random.rand()
                                v403 = v402 * v400
                                v404 = v403 + v398
                                v405 = round(v404)
                                v406 = len(v320)
                                v407 = v406 < (<signed short>16)
                                if v407:
                                    v408 = v202 <= v405
                                    if v408:
                                        v409 = v405 <= v201
                                        if v409:
                                            v413 = method37(v319, v405)
                                        else:
                                            v413 = 0
                                    else:
                                        v413 = 0
                                else:
                                    v413 = 0
                                if v413:
                                    v414 = US1_2(v405)
                                    v320.append(v414)
                                    del v414
                                else:
                                    pass
                        else:
                            v415 = <float>v202
                            v416 = libc.math.log(v415)
                            v417 = <float>v201
                            v418 = libc.math.log(v417)
                            v419 = v418 - v416
                            while method42(v320):
                                v421 = numpy.random.rand()
                                v422 = v421 * v419
                                v423 = v422 + v416
                                v424 = libc.math.exp(v423)
                                v425 = round(v424)
                                v426 = len(v320)
                                v427 = v426 < (<signed short>16)
                                if v427:
                                    v428 = v202 <= v425
                                    if v428:
                                        v429 = v425 <= v201
                                        if v429:
                                            v433 = method37(v319, v425)
                                        else:
                                            v433 = 0
                                    else:
                                        v433 = 0
                                else:
                                    v433 = 0
                                if v433:
                                    v434 = US1_2(v425)
                                    v320.append(v434)
                                    del v434
                                else:
                                    pass
                else:
                    pass
                del v319
                v435 = numpy.array(v320,copy=False)
                del v320
                v171[v176] = v435
                tmp35 = len(v435)
                if <signed short>tmp35 != tmp35: raise Exception("The conversion to signed short failed.")
                v436 = <signed short>tmp35
                v437 = Mut5((<signed short>0))
                while method36(v436, v437):
                    v439 = v437.v0
                    v440 = v435[v439]
                    v441 = v169[v176,v439]
                    if v440.tag == 0: # Call
                        v441[(<signed short>0)] = (<float>1)
                    elif v440.tag == 1: # Fold
                        v441[(<signed short>1)] = (<float>1)
                    elif v440.tag == 2: # RaiseTo
                        v442 = (<US1_2>v440).v0
                        v443 = (<signed short>2)
                        method30(v0, v442, v441, v443)
                    del v440; del v441
                    v170[v176,v439] = 0
                    v444 = v439 + (<signed short>1)
                    v437.v0 = v444
                del v435
                del v437
                if v206:
                    v445 = (<float>1)
                else:
                    v445 = (<float>-1)
                v172[v176] = v445
                v446 = v176 + (<unsigned long long>1)
                v174.v0 = v446
            del v174
            v447 = torch.from_numpy(v165)
            del v165
            v448 = v166.view('bool')
            del v166
            v449 = torch.from_numpy(v448)
            del v448
            v450 = torch.from_numpy(v167)
            del v167
            v451 = v168.view('bool')
            del v168
            v452 = torch.from_numpy(v451)
            del v451
            v453 = torch.from_numpy(v172)
            del v172
            v454 = torch.from_numpy(v169)
            del v169
            v455 = v170.view('bool')
            del v170
            v456 = torch.from_numpy(v455)
            del v455
            v457 = v5(v447, v449, v450, v452, v453, v454, v456)
            del v447; del v449; del v450; del v452; del v453; del v454; del v456
            v458 = v457[0]
            v459 = v457[1]
            v460 = v457[2]
            del v457
            v461 = numpy.empty(v11,dtype=object)
            v462 = Mut0((<unsigned long long>0))
            while method0(v11, v462):
                v464 = v462.v0
                v465 = v459[v464]
                v466 = v458 is None
                if v466:
                    v468 = (<float>1)
                else:
                    v468 = v458[v464,v465]
                v469 = libc.math.log(v468)
                v470 = v171[v464]
                v471 = <signed short>v465
                v472 = v470[v471]
                del v470
                v461[v464] = Tuple1(v469, v469, v472)
                del v472
                v473 = v464 + (<unsigned long long>1)
                v462.v0 = v473
            del v171; del v458; del v459
            del v462
            return Tuple2(v461, v460)
cdef class Closure3():
    cdef signed short v0
    cdef signed short v1
    cdef signed short v2
    cdef signed short v3
    cdef signed short v4
    def __init__(self, signed short v0, signed short v1, signed short v2, signed short v3, signed short v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self, v5):
        cdef signed short v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed short v4 = self.v4
        return Closure4(v0, v1, v2, v3, v4, v5)
cdef class Closure2():
    def __init__(self): pass
    def __call__(self, signed short v0):
        cdef signed short v1
        cdef signed short v2
        cdef bint v3
        cdef bint v5
        cdef bint v6
        cdef signed short v7
        cdef signed short v8
        cdef signed short v9
        cdef signed short v10
        cdef object v11
        cdef object v12
        v1 = v0 + (<signed short>1)
        pass # import math
        v2 = math.ceil(math.log2(v1))
        v3 = (<signed short>1) <= v2
        if v3:
            v5 = v2 <= (<signed short>64)
        else:
            v5 = 0
        v6 = v5 == 0
        if v6:
            raise Exception("The field size has to be in the [1,64] range.")
        else:
            pass
        v7 = (<signed short>2) + v2
        v8 = v7 + (<signed short>17)
        v9 = v8 + (<signed short>18)
        v10 = (<signed short>55) + v9
        v11 = collections.namedtuple("Size",['action', 'policy', 'value'])(v7, v9, v10)
        v12 = Closure3(v2, v7, v8, v9, v10)
        return collections.namedtuple("Neural",['handler', 'size'])(v12, v11)
cdef class Closure5():
    def __init__(self): pass
    def __call__(self, list v0):
        cdef unsigned long long v1
        cdef numpy.ndarray[object,ndim=1] v2
        cdef Mut0 v3
        cdef unsigned long long v5
        cdef float v6
        cdef float v7
        cdef UH0 v8
        cdef float v9
        cdef float v10
        cdef UH0 v11
        cdef float v12
        cdef float v13
        cdef signed char v14
        cdef signed char v15
        cdef unsigned char v16
        cdef signed short v17
        cdef signed char v18
        cdef signed char v19
        cdef unsigned char v20
        cdef signed short v21
        cdef numpy.ndarray[signed char,ndim=1] v22
        cdef signed short v23
        cdef signed short v24
        cdef bint v25
        cdef unsigned char v26
        cdef signed short v27
        cdef bint v28
        cdef bint v29
        cdef signed short v30
        cdef signed short v31
        cdef signed short v32
        cdef Tuple0 tmp36
        cdef list v33
        cdef US1 v34
        cdef US1 v35
        cdef Mut5 v36
        cdef signed short v38
        cdef US1 v39
        cdef signed short v40
        cdef numpy.ndarray[object,ndim=1] v41
        cdef signed short v42
        cdef unsigned long long tmp37
        cdef float v43
        cdef float v44
        cdef float v45
        cdef US1 v46
        cdef unsigned long long v47
        cdef object v48
        v1 = len(v0)
        v2 = numpy.empty(v1,dtype=object)
        v3 = Mut0((<unsigned long long>0))
        while method0(v1, v3):
            v5 = v3.v0
            tmp36 = v0[v5]
            v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32 = tmp36.v0, tmp36.v1, tmp36.v2, tmp36.v3, tmp36.v4, tmp36.v5, tmp36.v6, tmp36.v7, tmp36.v8, tmp36.v9, tmp36.v10, tmp36.v11, tmp36.v12, tmp36.v13, tmp36.v14, tmp36.v15, tmp36.v16, tmp36.v17, tmp36.v18, tmp36.v19, tmp36.v20, tmp36.v21, tmp36.v22, tmp36.v23, tmp36.v24, tmp36.v25, tmp36.v26
            del tmp36
            del v8; del v11; del v22
            v33 = [None]*(<signed short>0)
            if v28:
                v34 = US1_1()
                v33.append(v34)
                del v34
            else:
                pass
            v35 = US1_0()
            v33.append(v35)
            del v35
            if v29:
                v36 = Mut5(v31)
                while method36(v30, v36):
                    v38 = v36.v0
                    v39 = US1_2(v38)
                    v33.append(v39)
                    del v39
                    v40 = v38 + (<signed short>1)
                    v36.v0 = v40
                del v36
            else:
                pass
            v41 = numpy.array(v33,copy=False)
            del v33
            tmp37 = len(v41)
            if <signed short>tmp37 != tmp37: raise Exception("The conversion to signed short failed.")
            v42 = <signed short>tmp37
            v43 = <float>v42
            v44 = (<float>1) / v43
            v45 = libc.math.log(v44)
            v46 = numpy.random.choice(v41)
            del v41
            v2[v5] = Tuple1(v45, v45, v46)
            del v46
            v47 = v5 + (<unsigned long long>1)
            v3.v0 = v47
        del v3
        v48 = Closure1()
        return Tuple2(v2, v48)
cdef class UH3:
    cdef readonly signed long tag
cdef class UH3_0(UH3): # Action
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly signed char v8
    cdef readonly signed char v9
    cdef readonly unsigned char v10
    cdef readonly signed short v11
    cdef readonly signed char v12
    cdef readonly signed char v13
    cdef readonly unsigned char v14
    cdef readonly signed short v15
    cdef readonly object v16
    cdef readonly signed short v17
    cdef readonly signed short v18
    cdef readonly bint v19
    cdef readonly unsigned char v20
    cdef readonly signed short v21
    cdef readonly bint v22
    cdef readonly bint v23
    cdef readonly signed short v24
    cdef readonly signed short v25
    cdef readonly signed short v26
    cdef readonly object v27
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, signed char v8, signed char v9, unsigned char v10, signed short v11, signed char v12, signed char v13, unsigned char v14, signed short v15, v16, signed short v17, signed short v18, bint v19, unsigned char v20, signed short v21, bint v22, bint v23, signed short v24, signed short v25, signed short v26, v27): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23; self.v24 = v24; self.v25 = v25; self.v26 = v26; self.v27 = v27
cdef class UH3_1(UH3): # Terminal
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly signed char v8
    cdef readonly signed char v9
    cdef readonly unsigned char v10
    cdef readonly signed short v11
    cdef readonly signed char v12
    cdef readonly signed char v13
    cdef readonly unsigned char v14
    cdef readonly signed short v15
    cdef readonly object v16
    cdef readonly signed short v17
    cdef readonly signed short v18
    cdef readonly bint v19
    cdef readonly float v20
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, signed char v8, signed char v9, unsigned char v10, signed short v11, signed char v12, signed char v13, unsigned char v14, signed short v15, v16, signed short v17, signed short v18, bint v19, float v20): self.tag = 1; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20
cdef class Closure12():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef object v8
    cdef signed short v9
    cdef float v10
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, float v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, float v11, float v12, UH0 v13, float v14, float v15, UH0 v16, float v17, float v18):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef signed short v9 = self.v9
        cdef float v10 = self.v10
        return UH3_1(v11, v12, v13, v14, v15, v16, v17, v18, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>0), v9, 1, v10)
cdef class Closure16():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef object v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef UH0 v14
    cdef float v15
    cdef float v16
    cdef float v17
    cdef float v18
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16, float v17, float v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, float v19, float v20, US1 v21):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef float v12 = self.v12
        cdef float v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef float v15 = self.v15
        cdef float v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef bint v22
        cdef float v23
        cdef float v24
        cdef US0 v25
        cdef UH0 v26
        cdef US0 v27
        cdef UH0 v28
        cdef float v30
        cdef float v31
        cdef US0 v32
        cdef UH0 v33
        cdef US0 v34
        cdef UH0 v35
        v22 = v0 == (<unsigned char>0)
        if v22:
            v23 = v20 + v16
            v24 = v19 + v15
            v25 = US0_1(v21)
            v26 = UH0_0(v25, v14)
            del v25
            v27 = US0_1(v21)
            v28 = UH0_0(v27, v11)
            del v27
            return method56(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v21, v17, v18, v26, v24, v23, v28, v12, v13)
        else:
            v30 = v20 + v13
            v31 = v19 + v12
            v32 = US0_1(v21)
            v33 = UH0_0(v32, v14)
            del v32
            v34 = US0_1(v21)
            v35 = UH0_0(v34, v11)
            del v34
            return method56(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v21, v17, v18, v33, v15, v16, v35, v31, v30)
cdef class Closure15():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef signed short v8
    cdef bint v9
    cdef signed short v10
    cdef bint v11
    cdef signed short v12
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, signed short v8, bint v9, signed short v10, bint v11, signed short v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef signed short v8 = self.v8
        cdef bint v9 = self.v9
        cdef signed short v10 = self.v10
        cdef bint v11 = self.v11
        cdef signed short v12 = self.v12
        cdef object v21
        v21 = Closure16(v2, v11, v4, v5, v6, v3, v0, v1, v8, v12, v7, v18, v19, v20, v15, v16, v17, v13, v14)
        return UH3_0(v13, v14, v15, v16, v17, v18, v19, v20, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>5), v8, 0, v2, v3, 0, v9, v8, v10, v8, v21)
cdef class Closure14():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef signed short v10
    cdef object v11
    cdef UH0 v12
    cdef float v13
    cdef float v14
    cdef UH0 v15
    cdef float v16
    cdef float v17
    cdef float v18
    cdef float v19
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, UH0 v12, float v13, float v14, UH0 v15, float v16, float v17, float v18, float v19): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
    def __call__(self, float v20, float v21, US1 v22):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed short v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef float v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef bint v23
        cdef float v24
        cdef float v25
        cdef US0 v26
        cdef UH0 v27
        cdef US0 v28
        cdef UH0 v29
        cdef float v31
        cdef float v32
        cdef US0 v33
        cdef UH0 v34
        cdef US0 v35
        cdef UH0 v36
        v23 = v0 == (<unsigned char>0)
        if v23:
            v24 = v21 + v17
            v25 = v20 + v16
            v26 = US0_1(v22)
            v27 = UH0_0(v26, v15)
            del v26
            v28 = US0_1(v22)
            v29 = UH0_0(v28, v12)
            del v28
            return method53(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v27, v25, v24, v29, v13, v14)
        else:
            v31 = v21 + v14
            v32 = v20 + v13
            v33 = US0_1(v22)
            v34 = UH0_0(v33, v15)
            del v33
            v35 = US0_1(v22)
            v36 = UH0_0(v35, v12)
            del v35
            return method53(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v34, v16, v17, v36, v32, v31)
cdef class Closure13():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef object v8
    cdef signed short v9
    cdef signed short v10
    cdef bint v11
    cdef bint v12
    cdef signed short v13
    cdef bint v14
    cdef signed short v15
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, signed short v10, bint v11, bint v12, signed short v13, bint v14, signed short v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed short v10 = self.v10
        cdef bint v11 = self.v11
        cdef bint v12 = self.v12
        cdef signed short v13 = self.v13
        cdef bint v14 = self.v14
        cdef signed short v15 = self.v15
        cdef object v24
        v24 = Closure14(v2, v14, v4, v5, v6, v7, v0, v1, v3, v9, v15, v8, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH3_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>5), v9, 0, v2, v10, v11, v12, v9, v13, v9, v24)
cdef class Closure11():
    cdef signed char v0
    cdef signed short v1
    cdef signed short v2
    cdef object v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef signed char v8
    cdef signed char v9
    cdef unsigned char v10
    cdef signed short v11
    def __init__(self, signed char v0, signed short v1, signed short v2, numpy.ndarray[signed char,ndim=1] v3, signed char v4, signed char v5, unsigned char v6, signed short v7, signed char v8, signed char v9, unsigned char v10, signed short v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, float v12, float v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19):
        cdef signed char v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef numpy.ndarray[signed char,ndim=1] v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef signed char v8 = self.v8
        cdef signed char v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed short v11 = self.v11
        cdef bint v20
        cdef object v21
        cdef US0 v22
        cdef UH0 v23
        cdef US0 v24
        cdef UH0 v25
        v20 = 1
        v21 = method50(v1, v2, v20, v4, v5, v6, v7, v8, v9, v10, v11, v3)
        v22 = US0_0(v0)
        v23 = UH0_0(v22, v14)
        del v22
        v24 = US0_0(v0)
        v25 = UH0_0(v24, v17)
        del v24
        return v21(v12, v13, v23, v15, v16, v25, v18, v19)
cdef class Closure20():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef object v10
    cdef signed char v11
    cdef UH0 v12
    cdef float v13
    cdef float v14
    cdef UH0 v15
    cdef float v16
    cdef float v17
    cdef float v18
    cdef float v19
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, UH0 v12, float v13, float v14, UH0 v15, float v16, float v17, float v18, float v19): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
    def __call__(self, float v20, float v21, US1 v22):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef float v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef bint v23
        cdef float v24
        cdef float v25
        cdef US0 v26
        cdef UH0 v27
        cdef US0 v28
        cdef UH0 v29
        cdef float v31
        cdef float v32
        cdef US0 v33
        cdef UH0 v34
        cdef US0 v35
        cdef UH0 v36
        v23 = v0 == (<unsigned char>0)
        if v23:
            v24 = v21 + v17
            v25 = v20 + v16
            v26 = US0_1(v22)
            v27 = UH0_0(v26, v15)
            del v26
            v28 = US0_1(v22)
            v29 = UH0_0(v28, v12)
            del v28
            return method60(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v27, v25, v24, v29, v13, v14)
        else:
            v31 = v21 + v14
            v32 = v20 + v13
            v33 = US0_1(v22)
            v34 = UH0_0(v33, v15)
            del v33
            v35 = US0_1(v22)
            v36 = UH0_0(v35, v12)
            del v35
            return method60(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v34, v16, v17, v36, v32, v31)
cdef class Closure19():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef signed short v8
    cdef bint v9
    cdef signed short v10
    cdef bint v11
    cdef signed short v12
    cdef signed char v13
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, signed short v8, bint v9, signed short v10, bint v11, signed short v12, signed char v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef signed short v8 = self.v8
        cdef bint v9 = self.v9
        cdef signed short v10 = self.v10
        cdef bint v11 = self.v11
        cdef signed short v12 = self.v12
        cdef signed char v13 = self.v13
        cdef object v22
        v22 = Closure20(v2, v11, v4, v5, v6, v3, v0, v1, v8, v12, v7, v13, v19, v20, v21, v16, v17, v18, v14, v15)
        return UH3_0(v14, v15, v16, v17, v18, v19, v20, v21, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>4), v8, 0, v2, v3, 0, v9, v8, v10, v8, v22)
cdef class Closure18():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef signed short v10
    cdef object v11
    cdef signed char v12
    cdef UH0 v13
    cdef float v14
    cdef float v15
    cdef UH0 v16
    cdef float v17
    cdef float v18
    cdef float v19
    cdef float v20
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, UH0 v13, float v14, float v15, UH0 v16, float v17, float v18, float v19, float v20): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20
    def __call__(self, float v21, float v22, US1 v23):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed short v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef float v20 = self.v20
        cdef bint v24
        cdef float v25
        cdef float v26
        cdef US0 v27
        cdef UH0 v28
        cdef US0 v29
        cdef UH0 v30
        cdef float v32
        cdef float v33
        cdef US0 v34
        cdef UH0 v35
        cdef US0 v36
        cdef UH0 v37
        v24 = v0 == (<unsigned char>0)
        if v24:
            v25 = v22 + v18
            v26 = v21 + v17
            v27 = US0_1(v23)
            v28 = UH0_0(v27, v16)
            del v27
            v29 = US0_1(v23)
            v30 = UH0_0(v29, v13)
            del v29
            return method57(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v28, v26, v25, v30, v14, v15)
        else:
            v32 = v22 + v15
            v33 = v21 + v14
            v34 = US0_1(v23)
            v35 = UH0_0(v34, v16)
            del v34
            v36 = US0_1(v23)
            v37 = UH0_0(v36, v13)
            del v36
            return method57(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v35, v17, v18, v37, v33, v32)
cdef class Closure17():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef object v8
    cdef signed short v9
    cdef signed short v10
    cdef bint v11
    cdef bint v12
    cdef signed short v13
    cdef bint v14
    cdef signed short v15
    cdef signed char v16
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, signed short v10, bint v11, bint v12, signed short v13, bint v14, signed short v15, signed char v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed short v10 = self.v10
        cdef bint v11 = self.v11
        cdef bint v12 = self.v12
        cdef signed short v13 = self.v13
        cdef bint v14 = self.v14
        cdef signed short v15 = self.v15
        cdef signed char v16 = self.v16
        cdef object v25
        v25 = Closure18(v2, v14, v4, v5, v6, v7, v0, v1, v3, v9, v15, v8, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH3_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>4), v9, 0, v2, v10, v11, v12, v9, v13, v9, v25)
cdef class Closure10():
    cdef signed char v0
    cdef signed short v1
    cdef signed short v2
    cdef signed char v3
    cdef object v4
    cdef signed char v5
    cdef signed char v6
    cdef unsigned char v7
    cdef signed short v8
    cdef signed char v9
    cdef signed char v10
    cdef unsigned char v11
    cdef signed short v12
    def __init__(self, signed char v0, signed short v1, signed short v2, signed char v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, signed short v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
        cdef signed char v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed char v3 = self.v3
        cdef numpy.ndarray[signed char,ndim=1] v4 = self.v4
        cdef signed char v5 = self.v5
        cdef signed char v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed char v9 = self.v9
        cdef signed char v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed short v12 = self.v12
        cdef bint v21
        cdef object v22
        cdef US0 v23
        cdef UH0 v24
        cdef US0 v25
        cdef UH0 v26
        v21 = 1
        v22 = method48(v1, v2, v21, v5, v6, v7, v8, v9, v10, v11, v12, v4, v3)
        v23 = US0_0(v0)
        v24 = UH0_0(v23, v15)
        del v23
        v25 = US0_0(v0)
        v26 = UH0_0(v25, v18)
        del v25
        return v22(v13, v14, v24, v16, v17, v26, v19, v20)
cdef class Closure24():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef UH0 v13
    cdef float v14
    cdef float v15
    cdef UH0 v16
    cdef float v17
    cdef float v18
    cdef float v19
    cdef float v20
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, UH0 v13, float v14, float v15, UH0 v16, float v17, float v18, float v19, float v20): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20
    def __call__(self, float v21, float v22, US1 v23):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef float v20 = self.v20
        cdef bint v24
        cdef float v25
        cdef float v26
        cdef US0 v27
        cdef UH0 v28
        cdef US0 v29
        cdef UH0 v30
        cdef float v32
        cdef float v33
        cdef US0 v34
        cdef UH0 v35
        cdef US0 v36
        cdef UH0 v37
        v24 = v0 == (<unsigned char>0)
        if v24:
            v25 = v22 + v18
            v26 = v21 + v17
            v27 = US0_1(v23)
            v28 = UH0_0(v27, v16)
            del v27
            v29 = US0_1(v23)
            v30 = UH0_0(v29, v13)
            del v29
            return method64(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v28, v26, v25, v30, v14, v15)
        else:
            v32 = v22 + v15
            v33 = v21 + v14
            v34 = US0_1(v23)
            v35 = UH0_0(v34, v16)
            del v34
            v36 = US0_1(v23)
            v37 = UH0_0(v36, v13)
            del v36
            return method64(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v35, v17, v18, v37, v33, v32)
cdef class Closure23():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef signed short v8
    cdef bint v9
    cdef signed short v10
    cdef bint v11
    cdef signed short v12
    cdef signed char v13
    cdef signed char v14
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, signed short v8, bint v9, signed short v10, bint v11, signed short v12, signed char v13, signed char v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef signed short v8 = self.v8
        cdef bint v9 = self.v9
        cdef signed short v10 = self.v10
        cdef bint v11 = self.v11
        cdef signed short v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef object v23
        v23 = Closure24(v2, v11, v4, v5, v6, v3, v0, v1, v8, v12, v7, v13, v14, v20, v21, v22, v17, v18, v19, v15, v16)
        return UH3_0(v15, v16, v17, v18, v19, v20, v21, v22, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>3), v8, 0, v2, v3, 0, v9, v8, v10, v8, v23)
cdef class Closure22():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef signed short v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef UH0 v14
    cdef float v15
    cdef float v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef float v20
    cdef float v21
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19, float v20, float v21): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21
    def __call__(self, float v22, float v23, US1 v24):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed short v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef float v15 = self.v15
        cdef float v16 = self.v16
        cdef UH0 v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef bint v25
        cdef float v26
        cdef float v27
        cdef US0 v28
        cdef UH0 v29
        cdef US0 v30
        cdef UH0 v31
        cdef float v33
        cdef float v34
        cdef US0 v35
        cdef UH0 v36
        cdef US0 v37
        cdef UH0 v38
        v25 = v0 == (<unsigned char>0)
        if v25:
            v26 = v23 + v19
            v27 = v22 + v18
            v28 = US0_1(v24)
            v29 = UH0_0(v28, v17)
            del v28
            v30 = US0_1(v24)
            v31 = UH0_0(v30, v14)
            del v30
            return method61(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v24, v20, v21, v29, v27, v26, v31, v15, v16)
        else:
            v33 = v23 + v16
            v34 = v22 + v15
            v35 = US0_1(v24)
            v36 = UH0_0(v35, v17)
            del v35
            v37 = US0_1(v24)
            v38 = UH0_0(v37, v14)
            del v37
            return method61(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v24, v20, v21, v36, v18, v19, v38, v34, v33)
cdef class Closure21():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef object v8
    cdef signed short v9
    cdef signed short v10
    cdef bint v11
    cdef bint v12
    cdef signed short v13
    cdef bint v14
    cdef signed short v15
    cdef signed char v16
    cdef signed char v17
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, signed short v10, bint v11, bint v12, signed short v13, bint v14, signed short v15, signed char v16, signed char v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed short v10 = self.v10
        cdef bint v11 = self.v11
        cdef bint v12 = self.v12
        cdef signed short v13 = self.v13
        cdef bint v14 = self.v14
        cdef signed short v15 = self.v15
        cdef signed char v16 = self.v16
        cdef signed char v17 = self.v17
        cdef object v26
        v26 = Closure22(v2, v14, v4, v5, v6, v7, v0, v1, v3, v9, v15, v8, v16, v17, v23, v24, v25, v20, v21, v22, v18, v19)
        return UH3_0(v18, v19, v20, v21, v22, v23, v24, v25, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>3), v9, 0, v2, v10, v11, v12, v9, v13, v9, v26)
cdef class Closure9():
    cdef signed char v0
    cdef signed short v1
    cdef signed short v2
    cdef signed char v3
    cdef signed char v4
    cdef signed char v5
    cdef signed char v6
    cdef object v7
    cdef signed char v8
    cdef signed char v9
    cdef unsigned char v10
    cdef signed short v11
    cdef signed char v12
    cdef signed char v13
    cdef unsigned char v14
    cdef signed short v15
    def __init__(self, signed char v0, signed short v1, signed short v2, signed char v3, signed char v4, signed char v5, signed char v6, numpy.ndarray[signed char,ndim=1] v7, signed char v8, signed char v9, unsigned char v10, signed short v11, signed char v12, signed char v13, unsigned char v14, signed short v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
        cdef signed char v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed char v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef signed char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef signed char v8 = self.v8
        cdef signed char v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed short v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef signed short v15 = self.v15
        cdef bint v24
        cdef object v25
        cdef US0 v26
        cdef US0 v27
        cdef US0 v28
        cdef UH0 v29
        cdef UH0 v30
        cdef UH0 v31
        cdef US0 v32
        cdef US0 v33
        cdef US0 v34
        cdef UH0 v35
        cdef UH0 v36
        cdef UH0 v37
        v24 = 1
        v25 = method46(v1, v2, v24, v8, v9, v10, v11, v12, v13, v14, v15, v7, v5, v6)
        v26 = US0_0(v4)
        v27 = US0_0(v3)
        v28 = US0_0(v0)
        v29 = UH0_0(v28, v18)
        del v28
        v30 = UH0_0(v27, v29)
        del v27; del v29
        v31 = UH0_0(v26, v30)
        del v26; del v30
        v32 = US0_0(v4)
        v33 = US0_0(v3)
        v34 = US0_0(v0)
        v35 = UH0_0(v34, v21)
        del v34
        v36 = UH0_0(v33, v35)
        del v33; del v35
        v37 = UH0_0(v32, v36)
        del v32; del v36
        return v25(v16, v17, v31, v19, v20, v37, v22, v23)
cdef class Closure28():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef UH0 v16
    cdef float v17
    cdef float v18
    cdef UH0 v19
    cdef float v20
    cdef float v21
    cdef float v22
    cdef float v23
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21, float v22, float v23): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23
    def __call__(self, float v24, float v25, US1 v26):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef UH0 v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef bint v27
        cdef float v28
        cdef float v29
        cdef US0 v30
        cdef UH0 v31
        cdef US0 v32
        cdef UH0 v33
        cdef float v35
        cdef float v36
        cdef US0 v37
        cdef UH0 v38
        cdef US0 v39
        cdef UH0 v40
        v27 = v0 == (<unsigned char>0)
        if v27:
            v28 = v25 + v21
            v29 = v24 + v20
            v30 = US0_1(v26)
            v31 = UH0_0(v30, v19)
            del v30
            v32 = US0_1(v26)
            v33 = UH0_0(v32, v16)
            del v32
            return method68(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US0_1(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US0_1(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method68(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
cdef class Closure27():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef signed short v8
    cdef bint v9
    cdef signed short v10
    cdef bint v11
    cdef signed short v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    cdef signed char v17
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, signed short v8, bint v9, signed short v10, bint v11, signed short v12, signed char v13, signed char v14, signed char v15, signed char v16, signed char v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef signed short v8 = self.v8
        cdef bint v9 = self.v9
        cdef signed short v10 = self.v10
        cdef bint v11 = self.v11
        cdef signed short v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef signed char v17 = self.v17
        cdef object v26
        v26 = Closure28(v2, v11, v4, v5, v6, v3, v0, v1, v8, v12, v7, v13, v14, v15, v16, v17, v23, v24, v25, v20, v21, v22, v18, v19)
        return UH3_0(v18, v19, v20, v21, v22, v23, v24, v25, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>0), v8, 0, v2, v3, 0, v9, v8, v10, v8, v26)
cdef class Closure26():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef signed short v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef UH0 v20
    cdef float v21
    cdef float v22
    cdef float v23
    cdef float v24
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22, float v23, float v24): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23; self.v24 = v24
    def __call__(self, float v25, float v26, US1 v27):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed short v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef UH0 v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef UH0 v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef float v24 = self.v24
        cdef bint v28
        cdef float v29
        cdef float v30
        cdef US0 v31
        cdef UH0 v32
        cdef US0 v33
        cdef UH0 v34
        cdef float v36
        cdef float v37
        cdef US0 v38
        cdef UH0 v39
        cdef US0 v40
        cdef UH0 v41
        v28 = v0 == (<unsigned char>0)
        if v28:
            v29 = v26 + v22
            v30 = v25 + v21
            v31 = US0_1(v27)
            v32 = UH0_0(v31, v20)
            del v31
            v33 = US0_1(v27)
            v34 = UH0_0(v33, v17)
            del v33
            return method65(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v32, v30, v29, v34, v18, v19)
        else:
            v36 = v26 + v19
            v37 = v25 + v18
            v38 = US0_1(v27)
            v39 = UH0_0(v38, v20)
            del v38
            v40 = US0_1(v27)
            v41 = UH0_0(v40, v17)
            del v40
            return method65(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v39, v21, v22, v41, v37, v36)
cdef class Closure25():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef object v8
    cdef signed short v9
    cdef signed short v10
    cdef bint v11
    cdef bint v12
    cdef signed short v13
    cdef bint v14
    cdef signed short v15
    cdef signed char v16
    cdef signed char v17
    cdef signed char v18
    cdef signed char v19
    cdef signed char v20
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, signed short v10, bint v11, bint v12, signed short v13, bint v14, signed short v15, signed char v16, signed char v17, signed char v18, signed char v19, signed char v20): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20
    def __call__(self, float v21, float v22, UH0 v23, float v24, float v25, UH0 v26, float v27, float v28):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed short v10 = self.v10
        cdef bint v11 = self.v11
        cdef bint v12 = self.v12
        cdef signed short v13 = self.v13
        cdef bint v14 = self.v14
        cdef signed short v15 = self.v15
        cdef signed char v16 = self.v16
        cdef signed char v17 = self.v17
        cdef signed char v18 = self.v18
        cdef signed char v19 = self.v19
        cdef signed char v20 = self.v20
        cdef object v29
        v29 = Closure26(v2, v14, v4, v5, v6, v7, v0, v1, v3, v9, v15, v8, v16, v17, v18, v19, v20, v26, v27, v28, v23, v24, v25, v21, v22)
        return UH3_0(v21, v22, v23, v24, v25, v26, v27, v28, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>0), v9, 0, v2, v10, v11, v12, v9, v13, v9, v29)
cdef class Closure33():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef object v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef UH0 v14
    cdef float v15
    cdef float v16
    cdef float v17
    cdef float v18
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16, float v17, float v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, float v19, float v20, US1 v21):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef float v12 = self.v12
        cdef float v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef float v15 = self.v15
        cdef float v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef bint v22
        cdef float v23
        cdef float v24
        cdef US0 v25
        cdef UH0 v26
        cdef US0 v27
        cdef UH0 v28
        cdef float v30
        cdef float v31
        cdef US0 v32
        cdef UH0 v33
        cdef US0 v34
        cdef UH0 v35
        v22 = v0 == (<unsigned char>0)
        if v22:
            v23 = v20 + v16
            v24 = v19 + v15
            v25 = US0_1(v21)
            v26 = UH0_0(v25, v14)
            del v25
            v27 = US0_1(v21)
            v28 = UH0_0(v27, v11)
            del v27
            return method72(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v21, v17, v18, v26, v24, v23, v28, v12, v13)
        else:
            v30 = v20 + v13
            v31 = v19 + v12
            v32 = US0_1(v21)
            v33 = UH0_0(v32, v14)
            del v32
            v34 = US0_1(v21)
            v35 = UH0_0(v34, v11)
            del v34
            return method72(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v21, v17, v18, v33, v15, v16, v35, v31, v30)
cdef class Closure32():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef signed short v8
    cdef bint v9
    cdef signed short v10
    cdef bint v11
    cdef signed short v12
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, signed short v8, bint v9, signed short v10, bint v11, signed short v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef signed short v8 = self.v8
        cdef bint v9 = self.v9
        cdef signed short v10 = self.v10
        cdef bint v11 = self.v11
        cdef signed short v12 = self.v12
        cdef object v21
        v21 = Closure33(v2, v11, v4, v5, v6, v3, v0, v1, v8, v12, v7, v18, v19, v20, v15, v16, v17, v13, v14)
        return UH3_0(v13, v14, v15, v16, v17, v18, v19, v20, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>3), v8, 0, v2, v3, 0, v9, v8, v10, v8, v21)
cdef class Closure31():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef signed short v10
    cdef object v11
    cdef UH0 v12
    cdef float v13
    cdef float v14
    cdef UH0 v15
    cdef float v16
    cdef float v17
    cdef float v18
    cdef float v19
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, UH0 v12, float v13, float v14, UH0 v15, float v16, float v17, float v18, float v19): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
    def __call__(self, float v20, float v21, US1 v22):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed short v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef float v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef bint v23
        cdef float v24
        cdef float v25
        cdef US0 v26
        cdef UH0 v27
        cdef US0 v28
        cdef UH0 v29
        cdef float v31
        cdef float v32
        cdef US0 v33
        cdef UH0 v34
        cdef US0 v35
        cdef UH0 v36
        v23 = v0 == (<unsigned char>0)
        if v23:
            v24 = v21 + v17
            v25 = v20 + v16
            v26 = US0_1(v22)
            v27 = UH0_0(v26, v15)
            del v26
            v28 = US0_1(v22)
            v29 = UH0_0(v28, v12)
            del v28
            return method70(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v27, v25, v24, v29, v13, v14)
        else:
            v31 = v21 + v14
            v32 = v20 + v13
            v33 = US0_1(v22)
            v34 = UH0_0(v33, v15)
            del v33
            v35 = US0_1(v22)
            v36 = UH0_0(v35, v12)
            del v35
            return method70(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v34, v16, v17, v36, v32, v31)
cdef class Closure30():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef object v8
    cdef signed short v9
    cdef signed short v10
    cdef bint v11
    cdef bint v12
    cdef signed short v13
    cdef bint v14
    cdef signed short v15
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, signed short v10, bint v11, bint v12, signed short v13, bint v14, signed short v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed short v10 = self.v10
        cdef bint v11 = self.v11
        cdef bint v12 = self.v12
        cdef signed short v13 = self.v13
        cdef bint v14 = self.v14
        cdef signed short v15 = self.v15
        cdef object v24
        v24 = Closure31(v2, v14, v4, v5, v6, v7, v0, v1, v3, v9, v15, v8, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH3_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>3), v9, 0, v2, v10, v11, v12, v9, v13, v9, v24)
cdef class Closure29():
    cdef signed char v0
    cdef signed short v1
    cdef signed short v2
    cdef signed char v3
    cdef signed char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed char v9
    cdef signed char v10
    cdef object v11
    def __init__(self, signed char v0, signed short v1, signed short v2, signed char v3, signed char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed char v9, signed char v10, numpy.ndarray[signed char,ndim=1] v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, float v12, float v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19):
        cdef signed char v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed char v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed char v9 = self.v9
        cdef signed char v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef bint v20
        cdef unsigned char v21
        cdef unsigned char v22
        cdef object v23
        cdef US0 v24
        cdef US0 v25
        cdef US0 v26
        cdef UH0 v27
        cdef UH0 v28
        cdef UH0 v29
        cdef US0 v30
        cdef US0 v31
        cdef US0 v32
        cdef UH0 v33
        cdef UH0 v34
        cdef UH0 v35
        v20 = 1
        v21 = (<unsigned char>0)
        v22 = (<unsigned char>1)
        v23 = method69(v1, v2, v20, v6, v7, v22, v8, v3, v4, v21, v5, v11)
        v24 = US0_0(v10)
        v25 = US0_0(v9)
        v26 = US0_0(v0)
        v27 = UH0_0(v26, v14)
        del v26
        v28 = UH0_0(v25, v27)
        del v25; del v27
        v29 = UH0_0(v24, v28)
        del v24; del v28
        v30 = US0_0(v10)
        v31 = US0_0(v9)
        v32 = US0_0(v0)
        v33 = UH0_0(v32, v17)
        del v32
        v34 = UH0_0(v31, v33)
        del v31; del v33
        v35 = UH0_0(v30, v34)
        del v30; del v34
        return v23(v12, v13, v29, v15, v16, v35, v18, v19)
cdef class Closure34():
    cdef signed char v0
    cdef signed short v1
    cdef signed short v2
    cdef signed char v3
    cdef signed char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed char v9
    cdef signed char v10
    cdef signed char v11
    cdef signed char v12
    cdef object v13
    def __init__(self, signed char v0, signed short v1, signed short v2, signed char v3, signed char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed char v9, signed char v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
        cdef signed char v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed char v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed char v9 = self.v9
        cdef signed char v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef numpy.ndarray[signed char,ndim=1] v13 = self.v13
        cdef bint v22
        cdef unsigned char v23
        cdef unsigned char v24
        cdef object v25
        cdef US0 v26
        cdef US0 v27
        cdef US0 v28
        cdef US0 v29
        cdef US0 v30
        cdef UH0 v31
        cdef UH0 v32
        cdef UH0 v33
        cdef UH0 v34
        cdef UH0 v35
        cdef US0 v36
        cdef US0 v37
        cdef US0 v38
        cdef US0 v39
        cdef US0 v40
        cdef UH0 v41
        cdef UH0 v42
        cdef UH0 v43
        cdef UH0 v44
        cdef UH0 v45
        v22 = 1
        v23 = (<unsigned char>0)
        v24 = (<unsigned char>1)
        v25 = method50(v1, v2, v22, v6, v7, v24, v8, v3, v4, v23, v5, v13)
        v26 = US0_0(v12)
        v27 = US0_0(v11)
        v28 = US0_0(v10)
        v29 = US0_0(v9)
        v30 = US0_0(v0)
        v31 = UH0_0(v30, v16)
        del v30
        v32 = UH0_0(v29, v31)
        del v29; del v31
        v33 = UH0_0(v28, v32)
        del v28; del v32
        v34 = UH0_0(v27, v33)
        del v27; del v33
        v35 = UH0_0(v26, v34)
        del v26; del v34
        v36 = US0_0(v12)
        v37 = US0_0(v11)
        v38 = US0_0(v10)
        v39 = US0_0(v9)
        v40 = US0_0(v0)
        v41 = UH0_0(v40, v19)
        del v40
        v42 = UH0_0(v39, v41)
        del v39; del v41
        v43 = UH0_0(v38, v42)
        del v38; del v42
        v44 = UH0_0(v37, v43)
        del v37; del v43
        v45 = UH0_0(v36, v44)
        del v36; del v44
        return v25(v14, v15, v35, v17, v18, v45, v20, v21)
cdef class Closure8():
    cdef unsigned char v0
    cdef signed short v1
    cdef signed short v2
    cdef signed short v3
    cdef object v4
    cdef object v5
    cdef object v6
    def __init__(self, unsigned char v0, signed short v1, signed short v2, signed short v3, v4, v5, v6): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6
    def __call__(self, unsigned long long v7, v8, v9):
        cdef unsigned char v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed short v3 = self.v3
        cdef object v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v10
        cdef Mut0 v11
        cdef unsigned long long v13
        cdef UH0 v14
        cdef float v15
        cdef float v16
        cdef UH0 v17
        cdef float v18
        cdef float v19
        cdef float v20
        cdef float v21
        cdef UH3 v22
        cdef unsigned long long v23
        v10 = numpy.empty(v7,dtype=object)
        v11 = Mut0((<unsigned long long>0))
        while method0(v7, v11):
            v13 = v11.v0
            v14 = UH0_1()
            v15 = (<float>0)
            v16 = (<float>0)
            v17 = UH0_1()
            v18 = (<float>0)
            v19 = (<float>0)
            v20 = (<float>0)
            v21 = (<float>0)
            v22 = method43(v0, v1, v2, v3, v20, v21, v14, v15, v16, v17, v18, v19)
            del v14; del v17
            v10[v13] = v22
            del v22
            v23 = v13 + (<unsigned long long>1)
            v11.v0 = v23
        del v11
        return method73(v4, v5, v6, v9, v8, v10)
cdef class Closure7():
    cdef unsigned char v0
    cdef signed short v1
    cdef signed short v2
    cdef signed short v3
    def __init__(self, unsigned char v0, signed short v1, signed short v2, signed short v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, v4, v5, v6):
        cdef unsigned char v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed short v3 = self.v3
        return Closure8(v0, v1, v2, v3, v6, v5, v4)
cdef class Closure35():
    cdef unsigned char v0
    cdef signed short v1
    cdef signed short v2
    cdef signed short v3
    def __init__(self, unsigned char v0, signed short v1, signed short v2, signed short v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, unsigned long long v4, v5, v6):
        cdef unsigned char v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed short v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v7
        cdef Mut0 v8
        cdef unsigned long long v10
        cdef UH0 v11
        cdef float v12
        cdef float v13
        cdef UH0 v14
        cdef float v15
        cdef float v16
        cdef float v17
        cdef float v18
        cdef UH3 v19
        cdef unsigned long long v20
        v7 = numpy.empty(v4,dtype=object)
        v8 = Mut0((<unsigned long long>0))
        while method0(v4, v8):
            v10 = v8.v0
            v11 = UH0_1()
            v12 = (<float>0)
            v13 = (<float>0)
            v14 = UH0_1()
            v15 = (<float>0)
            v16 = (<float>0)
            v17 = (<float>0)
            v18 = (<float>0)
            v19 = method43(v0, v1, v2, v3, v17, v18, v11, v12, v13, v14, v15, v16)
            del v11; del v14
            v7[v10] = v19
            del v19
            v20 = v10 + (<unsigned long long>1)
            v8.v0 = v20
        del v8
        return method74(v6, v5, v7)
cdef class Closure6():
    def __init__(self): pass
    def __call__(self, unsigned char v0, signed short v1, signed short v2, signed short v3):
        cdef object v4
        cdef object v5
        v4 = Closure7(v0, v1, v2, v3)
        v5 = Closure35(v0, v1, v2, v3)
        return collections.namedtuple("VsOne",['cat', 'exp'])(v4, v5)
cdef class Closure38():
    cdef unsigned char v0
    cdef signed short v1
    cdef signed short v2
    cdef signed short v3
    cdef object v4
    cdef object v5
    cdef object v6
    def __init__(self, unsigned char v0, signed short v1, signed short v2, signed short v3, v4, v5, v6): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6
    def __call__(self, unsigned long long v7, v8):
        cdef unsigned char v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed short v3 = self.v3
        cdef object v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v9
        cdef Mut0 v10
        cdef unsigned long long v12
        cdef UH0 v13
        cdef float v14
        cdef float v15
        cdef UH0 v16
        cdef float v17
        cdef float v18
        cdef float v19
        cdef float v20
        cdef UH3 v21
        cdef unsigned long long v22
        v9 = numpy.empty(v7,dtype=object)
        v10 = Mut0((<unsigned long long>0))
        while method0(v7, v10):
            v12 = v10.v0
            v13 = UH0_1()
            v14 = (<float>0)
            v15 = (<float>0)
            v16 = UH0_1()
            v17 = (<float>0)
            v18 = (<float>0)
            v19 = (<float>0)
            v20 = (<float>0)
            v21 = method43(v0, v1, v2, v3, v19, v20, v13, v14, v15, v16, v17, v18)
            del v13; del v16
            v9[v12] = v21
            del v21
            v22 = v12 + (<unsigned long long>1)
            v10.v0 = v22
        del v10
        return method75(v4, v5, v6, v8, v9)
cdef class Closure37():
    cdef unsigned char v0
    cdef signed short v1
    cdef signed short v2
    cdef signed short v3
    def __init__(self, unsigned char v0, signed short v1, signed short v2, signed short v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, v4, v5, v6):
        cdef unsigned char v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed short v3 = self.v3
        return Closure38(v0, v1, v2, v3, v6, v5, v4)
cdef class Closure39():
    cdef unsigned char v0
    cdef signed short v1
    cdef signed short v2
    cdef signed short v3
    def __init__(self, unsigned char v0, signed short v1, signed short v2, signed short v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, unsigned long long v4, v5):
        cdef unsigned char v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed short v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v6
        cdef Mut0 v7
        cdef unsigned long long v9
        cdef UH0 v10
        cdef float v11
        cdef float v12
        cdef UH0 v13
        cdef float v14
        cdef float v15
        cdef float v16
        cdef float v17
        cdef UH3 v18
        cdef unsigned long long v19
        v6 = numpy.empty(v4,dtype=object)
        v7 = Mut0((<unsigned long long>0))
        while method0(v4, v7):
            v9 = v7.v0
            v10 = UH0_1()
            v11 = (<float>0)
            v12 = (<float>0)
            v13 = UH0_1()
            v14 = (<float>0)
            v15 = (<float>0)
            v16 = (<float>0)
            v17 = (<float>0)
            v18 = method43(v0, v1, v2, v3, v16, v17, v10, v11, v12, v13, v14, v15)
            del v10; del v13
            v6[v9] = v18
            del v18
            v19 = v9 + (<unsigned long long>1)
            v7.v0 = v19
        del v7
        return method76(v5, v6)
cdef class Closure36():
    def __init__(self): pass
    def __call__(self, unsigned char v0, signed short v1, signed short v2, signed short v3):
        cdef object v4
        cdef object v5
        v4 = Closure37(v0, v1, v2, v3)
        v5 = Closure39(v0, v1, v2, v3)
        return collections.namedtuple("VsSelf",['cat', 'exp'])(v4, v5)
cdef class Closure42():
    cdef object v0
    cdef object v1
    cdef unsigned char v2
    cdef signed short v3
    cdef object v4
    def __init__(self, v0, v1, unsigned char v2, signed short v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef object v4 = self.v4
        cdef US1 v5
        cdef UH3 v6
        v5 = US1_1()
        v6 = v4((<float>0), (<float>0), v5)
        del v5
        method77(v0, v1, v2, v3, v6)
cdef class Closure43():
    cdef object v0
    cdef object v1
    cdef unsigned char v2
    cdef signed short v3
    cdef object v4
    def __init__(self, v0, v1, unsigned char v2, signed short v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self, signed short v5):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef object v4 = self.v4
        cdef US1 v6
        cdef UH3 v7
        v6 = US1_2(v5)
        v7 = v4((<float>0), (<float>0), v6)
        del v6
        method77(v0, v1, v2, v3, v7)
cdef class Closure44():
    cdef object v0
    cdef object v1
    cdef unsigned char v2
    cdef signed short v3
    cdef object v4
    def __init__(self, v0, v1, unsigned char v2, signed short v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef object v4 = self.v4
        cdef US1 v5
        cdef UH3 v6
        v5 = US1_0()
        v6 = v4((<float>0), (<float>0), v5)
        del v5
        method77(v0, v1, v2, v3, v6)
cdef class Closure41():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, unsigned char v1, signed short v2, signed short v3, signed short v4, unsigned char v5, v6):
        cdef object v0 = self.v0
        cdef UH0 v7
        cdef float v8
        cdef float v9
        cdef UH0 v10
        cdef float v11
        cdef float v12
        cdef float v13
        cdef float v14
        cdef UH3 v15
        v7 = UH0_1()
        v8 = (<float>0)
        v9 = (<float>0)
        v10 = UH0_1()
        v11 = (<float>0)
        v12 = (<float>0)
        v13 = (<float>0)
        v14 = (<float>0)
        v15 = method43(v1, v2, v3, v4, v13, v14, v7, v8, v9, v10, v11, v12)
        del v7; del v10
        method77(v0, v6, v5, v4, v15)
cdef class Closure40():
    def __init__(self): pass
    def __call__(self, v0):
        return Closure41(v0)
cdef bint method0(unsigned long long v0, Mut0 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef bint method1(unsigned long long v0, Mut1 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef bint method3(signed short v0, Mut2 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef Tuple3 method5(unsigned long long v0, signed char v1, signed char v2):
    cdef bint v3
    cdef signed char v4
    cdef bint v5
    cdef signed char v7
    cdef signed char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef bint v57
    cdef signed char v15
    cdef bint v16
    cdef signed char v18
    cdef signed char v19
    cdef signed long v20
    cdef unsigned long long v21
    cdef unsigned long long v22
    cdef bint v23
    cdef bint v24
    cdef signed char v25
    cdef bint v26
    cdef signed char v28
    cdef signed char v29
    cdef signed long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    cdef bint v33
    cdef bint v34
    cdef signed char v35
    cdef bint v36
    cdef signed char v38
    cdef signed char v39
    cdef signed long v40
    cdef unsigned long long v41
    cdef unsigned long long v42
    cdef bint v43
    cdef bint v44
    cdef bint v45
    cdef signed char v47
    cdef signed char v48
    cdef signed long v49
    cdef unsigned long long v50
    cdef unsigned long long v51
    cdef bint v52
    cdef signed char v59
    cdef signed char v60
    cdef signed char v61
    cdef bint v62
    cdef signed char v64
    cdef signed char v65
    cdef signed char v66
    cdef bint v67
    cdef signed char v69
    cdef signed char v70
    cdef signed char v71
    cdef bint v72
    cdef signed char v74
    cdef signed char v75
    cdef bint v76
    cdef signed char v78
    cdef signed char v79
    cdef signed char v80
    cdef signed char v93
    v3 = v2 < (<signed char>4)
    if v3:
        v4 = v1 + (<signed char>4)
        v5 = v4 < (<signed char>0)
        if v5:
            v7 = v4 + (<signed char>13)
        else:
            v7 = v4
        v8 = v2 * (<signed char>13)
        v9 = v8 + v7
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = v1 + (<signed char>3)
            v16 = v15 < (<signed char>0)
            if v16:
                v18 = v15 + (<signed char>13)
            else:
                v18 = v15
            v19 = v8 + v18
            v20 = <signed long>v19
            v21 = (<unsigned long long>1) << v20
            v22 = v0 & v21
            v23 = v22 == (<unsigned long long>0)
            v24 = v23 != 1
            if v24:
                v25 = v1 + (<signed char>2)
                v26 = v25 < (<signed char>0)
                if v26:
                    v28 = v25 + (<signed char>13)
                else:
                    v28 = v25
                v29 = v8 + v28
                v30 = <signed long>v29
                v31 = (<unsigned long long>1) << v30
                v32 = v0 & v31
                v33 = v32 == (<unsigned long long>0)
                v34 = v33 != 1
                if v34:
                    v35 = v1 + (<signed char>1)
                    v36 = v35 < (<signed char>0)
                    if v36:
                        v38 = v35 + (<signed char>13)
                    else:
                        v38 = v35
                    v39 = v8 + v38
                    v40 = <signed long>v39
                    v41 = (<unsigned long long>1) << v40
                    v42 = v0 & v41
                    v43 = v42 == (<unsigned long long>0)
                    v44 = v43 != 1
                    if v44:
                        v45 = v1 < (<signed char>0)
                        if v45:
                            v47 = v1 + (<signed char>13)
                        else:
                            v47 = v1
                        v48 = v8 + v47
                        v49 = <signed long>v48
                        v50 = (<unsigned long long>1) << v49
                        v51 = v0 & v50
                        v52 = v51 == (<unsigned long long>0)
                        v57 = v52 != 1
                    else:
                        v57 = 0
                else:
                    v57 = 0
            else:
                v57 = 0
        else:
            v57 = 0
        if v57:
            if v5:
                v59 = v4 + (<signed char>13)
            else:
                v59 = v4
            v60 = v8 + v59
            v61 = v1 + (<signed char>3)
            v62 = v61 < (<signed char>0)
            if v62:
                v64 = v61 + (<signed char>13)
            else:
                v64 = v61
            v65 = v8 + v64
            v66 = v1 + (<signed char>2)
            v67 = v66 < (<signed char>0)
            if v67:
                v69 = v66 + (<signed char>13)
            else:
                v69 = v66
            v70 = v8 + v69
            v71 = v1 + (<signed char>1)
            v72 = v71 < (<signed char>0)
            if v72:
                v74 = v71 + (<signed char>13)
            else:
                v74 = v71
            v75 = v8 + v74
            v76 = v1 < (<signed char>0)
            if v76:
                v78 = v1 + (<signed char>13)
            else:
                v78 = v1
            v79 = v8 + v78
            return Tuple3(v60, v65, v70, v75, v79, (<signed char>8))
        else:
            v80 = v2 + (<signed char>1)
            return method5(v0, v1, v80)
    else:
        v93 = v1 - (<signed char>1)
        return method4(v0, v93)
cdef Tuple4 method8(unsigned long long v0, signed char v1, signed char v2, signed char v3, unsigned char v4, signed char v5, signed char v6, signed char v7, signed char v8, signed char v9):
    cdef bint v10
    cdef signed char v11
    cdef signed char v12
    cdef signed long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef bint v16
    cdef bint v17
    cdef bint v18
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef bint v19
    cdef bint v20
    cdef bint v21
    cdef unsigned char v42
    cdef bint v43
    cdef signed char v44
    cdef signed char v55
    cdef signed char v66
    v10 = v3 < (<signed char>4)
    if v10:
        v11 = v3 * (<signed char>13)
        v12 = v11 + v2
        v13 = <signed long>v12
        v14 = (<unsigned long long>1) << v13
        v15 = v0 & v14
        v16 = v15 == (<unsigned long long>0)
        v17 = v16 != 1
        if v17:
            v18 = v4 == (<unsigned char>0)
            if v18:
                v37, v38, v39, v40, v41 = v12, v6, v7, v8, v9
            else:
                v19 = v4 == (<unsigned char>1)
                if v19:
                    v37, v38, v39, v40, v41 = v5, v12, v7, v8, v9
                else:
                    v20 = v4 == (<unsigned char>2)
                    if v20:
                        v37, v38, v39, v40, v41 = v5, v6, v12, v8, v9
                    else:
                        v21 = v4 == (<unsigned char>3)
                        if v21:
                            v37, v38, v39, v40, v41 = v5, v6, v7, v12, v9
                        else:
                            v37, v38, v39, v40, v41 = v5, v6, v7, v8, v12
            v42 = v4 + (<unsigned char>1)
            v43 = v42 < (<unsigned char>5)
            if v43:
                v44 = v3 + (<signed char>1)
                return method8(v0, v1, v2, v44, v42, v37, v38, v39, v40, v41)
            else:
                return Tuple4(v37, v38, v39, v40, v41)
        else:
            v55 = v3 + (<signed char>1)
            return method8(v0, v1, v2, v55, v4, v5, v6, v7, v8, v9)
    else:
        v66 = v2 - (<signed char>1)
        return method7(v0, v1, v66, v5, v6, v7, v8, v9, v4)
cdef Tuple4 method7(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
    cdef bint v9
    cdef signed char v10
    cdef bint v16
    cdef signed char v17
    v9 = v2 == v1
    if v9:
        v10 = v2 - (<signed char>1)
        return method7(v0, v1, v10, v3, v4, v5, v6, v7, v8)
    else:
        v16 = (<signed char>0) <= v2
        if v16:
            v17 = (<signed char>0)
            return method8(v0, v1, v2, v17, v8, v3, v4, v5, v6, v7)
        else:
            return Tuple4(v3, v4, v5, v6, v7)
cdef Tuple5 method10(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7):
    cdef bint v8
    cdef signed char v9
    cdef signed char v10
    cdef signed long v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef bint v14
    cdef bint v15
    cdef signed char v32
    cdef signed char v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef bint v16
    cdef signed char v27
    cdef signed char v28
    cdef signed char v29
    cdef signed char v30
    cdef bint v17
    cdef bint v18
    cdef signed char v31
    cdef signed char v37
    v8 = v7 < (<signed char>4)
    if v8:
        v9 = v7 * (<signed char>13)
        v10 = v9 + v1
        v11 = <signed long>v10
        v12 = (<unsigned long long>1) << v11
        v13 = v0 & v12
        v14 = v13 == (<unsigned long long>0)
        v15 = v14 != 1
        if v15:
            v16 = v2 == (<signed char>0)
            if v16:
                v27, v28, v29, v30 = v10, v4, v5, v6
            else:
                v17 = v2 == (<signed char>1)
                if v17:
                    v27, v28, v29, v30 = v3, v10, v5, v6
                else:
                    v18 = v2 == (<signed char>2)
                    if v18:
                        v27, v28, v29, v30 = v3, v4, v10, v6
                    else:
                        v27, v28, v29, v30 = v3, v4, v5, v10
            v31 = v2 + (<signed char>1)
            v32, v33, v34, v35, v36 = v27, v28, v29, v30, v31
        else:
            v32, v33, v34, v35, v36 = v3, v4, v5, v6, v2
        v37 = v7 + (<signed char>1)
        return method10(v0, v1, v36, v32, v33, v34, v35, v37)
    else:
        return Tuple5(v3, v4, v5, v6)
cdef Tuple3 method13(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
    cdef signed char v9
    cdef signed char v10
    cdef signed long v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef bint v14
    cdef bint v15
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef unsigned char v46
    cdef bint v16
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef bint v17
    cdef bint v18
    cdef bint v19
    cdef unsigned char v40
    cdef bint v47
    cdef signed char v48
    v9 = v1 * (<signed char>13)
    v10 = v9 + v2
    v11 = <signed long>v10
    v12 = (<unsigned long long>1) << v11
    v13 = v0 & v12
    v14 = v13 == (<unsigned long long>0)
    v15 = v14 != 1
    if v15:
        v16 = v8 == (<unsigned char>0)
        if v16:
            v35, v36, v37, v38, v39 = v10, v4, v5, v6, v7
        else:
            v17 = v8 == (<unsigned char>1)
            if v17:
                v35, v36, v37, v38, v39 = v3, v10, v5, v6, v7
            else:
                v18 = v8 == (<unsigned char>2)
                if v18:
                    v35, v36, v37, v38, v39 = v3, v4, v10, v6, v7
                else:
                    v19 = v8 == (<unsigned char>3)
                    if v19:
                        v35, v36, v37, v38, v39 = v3, v4, v5, v10, v7
                    else:
                        v35, v36, v37, v38, v39 = v3, v4, v5, v6, v10
        v40 = v8 + (<unsigned char>1)
        v41, v42, v43, v44, v45, v46 = v35, v36, v37, v38, v39, v40
    else:
        v41, v42, v43, v44, v45, v46 = v3, v4, v5, v6, v7, v8
    v47 = v46 == (<unsigned char>5)
    if v47:
        return Tuple3(v41, v42, v43, v44, v45, (<signed char>5))
    else:
        v48 = v2 - (<signed char>1)
        return method13(v0, v1, v48, v41, v42, v43, v44, v45, v46)
cdef Tuple4 method19(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, unsigned char v5, signed char v6, signed char v7, signed char v8, signed char v9, signed char v10):
    cdef bint v11
    cdef signed char v12
    cdef signed char v13
    cdef signed long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef bint v17
    cdef bint v18
    cdef bint v19
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef bint v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v43
    cdef bint v44
    cdef signed char v45
    cdef signed char v56
    cdef signed char v67
    v11 = v4 < (<signed char>4)
    if v11:
        v12 = v4 * (<signed char>13)
        v13 = v12 + v3
        v14 = <signed long>v13
        v15 = (<unsigned long long>1) << v14
        v16 = v0 & v15
        v17 = v16 == (<unsigned long long>0)
        v18 = v17 != 1
        if v18:
            v19 = v5 == (<unsigned char>0)
            if v19:
                v38, v39, v40, v41, v42 = v13, v7, v8, v9, v10
            else:
                v20 = v5 == (<unsigned char>1)
                if v20:
                    v38, v39, v40, v41, v42 = v6, v13, v8, v9, v10
                else:
                    v21 = v5 == (<unsigned char>2)
                    if v21:
                        v38, v39, v40, v41, v42 = v6, v7, v13, v9, v10
                    else:
                        v22 = v5 == (<unsigned char>3)
                        if v22:
                            v38, v39, v40, v41, v42 = v6, v7, v8, v13, v10
                        else:
                            v38, v39, v40, v41, v42 = v6, v7, v8, v9, v13
            v43 = v5 + (<unsigned char>1)
            v44 = v43 < (<unsigned char>5)
            if v44:
                v45 = v4 + (<signed char>1)
                return method19(v0, v1, v2, v3, v45, v43, v38, v39, v40, v41, v42)
            else:
                return Tuple4(v38, v39, v40, v41, v42)
        else:
            v56 = v4 + (<signed char>1)
            return method19(v0, v1, v2, v3, v56, v5, v6, v7, v8, v9, v10)
    else:
        v67 = v3 - (<signed char>1)
        return method18(v0, v1, v2, v67, v6, v7, v8, v9, v10, v5)
cdef Tuple4 method18(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8, unsigned char v9):
    cdef bint v10
    cdef bint v12
    cdef signed char v13
    cdef bint v19
    cdef signed char v20
    v10 = v3 == v1
    if v10:
        v12 = 1
    else:
        v12 = v3 == v2
    if v12:
        v13 = v3 - (<signed char>1)
        return method18(v0, v1, v2, v13, v4, v5, v6, v7, v8, v9)
    else:
        v19 = (<signed char>0) <= v3
        if v19:
            v20 = (<signed char>0)
            return method19(v0, v1, v2, v3, v20, v9, v4, v5, v6, v7, v8)
        else:
            return Tuple4(v4, v5, v6, v7, v8)
cdef Tuple4 method22(unsigned long long v0, signed char v1, signed char v2, unsigned char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8):
    cdef bint v9
    cdef signed char v10
    cdef signed char v11
    cdef signed long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef bint v15
    cdef bint v16
    cdef bint v17
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef bint v18
    cdef bint v19
    cdef bint v20
    cdef unsigned char v41
    cdef bint v42
    cdef signed char v43
    cdef signed char v54
    cdef signed char v65
    v9 = v2 < (<signed char>4)
    if v9:
        v10 = v2 * (<signed char>13)
        v11 = v10 + v1
        v12 = <signed long>v11
        v13 = (<unsigned long long>1) << v12
        v14 = v0 & v13
        v15 = v14 == (<unsigned long long>0)
        v16 = v15 != 1
        if v16:
            v17 = v3 == (<unsigned char>0)
            if v17:
                v36, v37, v38, v39, v40 = v11, v5, v6, v7, v8
            else:
                v18 = v3 == (<unsigned char>1)
                if v18:
                    v36, v37, v38, v39, v40 = v4, v11, v6, v7, v8
                else:
                    v19 = v3 == (<unsigned char>2)
                    if v19:
                        v36, v37, v38, v39, v40 = v4, v5, v11, v7, v8
                    else:
                        v20 = v3 == (<unsigned char>3)
                        if v20:
                            v36, v37, v38, v39, v40 = v4, v5, v6, v11, v8
                        else:
                            v36, v37, v38, v39, v40 = v4, v5, v6, v7, v11
            v41 = v3 + (<unsigned char>1)
            v42 = v41 < (<unsigned char>5)
            if v42:
                v43 = v2 + (<signed char>1)
                return method22(v0, v1, v43, v41, v36, v37, v38, v39, v40)
            else:
                return Tuple4(v36, v37, v38, v39, v40)
        else:
            v54 = v2 + (<signed char>1)
            return method22(v0, v1, v54, v3, v4, v5, v6, v7, v8)
    else:
        v65 = v1 - (<signed char>1)
        return method21(v0, v65, v4, v5, v6, v7, v8, v3)
cdef Tuple4 method21(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, unsigned char v7):
    cdef bint v8
    cdef signed char v9
    v8 = (<signed char>0) <= v1
    if v8:
        v9 = (<signed char>0)
        return method22(v0, v1, v9, v7, v2, v3, v4, v5, v6)
    else:
        return Tuple4(v2, v3, v4, v5, v6)
cdef Tuple3 method20(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef Tuple5 tmp16
    cdef signed char v44
    cdef signed char v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef signed char v49
    cdef unsigned char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef signed char v55
    cdef Tuple4 tmp17
    cdef signed char v56
    cdef signed char v69
    cdef signed char v70
    cdef signed char v71
    cdef signed char v72
    cdef signed char v73
    cdef signed char v74
    cdef unsigned char v75
    cdef signed char v76
    cdef signed char v77
    cdef signed char v78
    cdef signed char v79
    cdef signed char v80
    cdef Tuple4 tmp18
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>2)
        if v33:
            v34 = (<signed char>-1)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>0)
            v39 = (<signed char>0)
            tmp16 = method10(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp16.v0, tmp16.v1, tmp16.v2, tmp16.v3
            del tmp16
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp17 = method7(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp17.v0, tmp17.v1, tmp17.v2, tmp17.v3, tmp17.v4
            del tmp17
            return Tuple3(v40, v41, v51, v52, v53, (<signed char>1))
        else:
            v56 = v1 - (<signed char>1)
            return method20(v0, v56)
    else:
        v69 = (<signed char>12)
        v70 = (<signed char>-1)
        v71 = (<signed char>-1)
        v72 = (<signed char>-1)
        v73 = (<signed char>-1)
        v74 = (<signed char>-1)
        v75 = (<unsigned char>0)
        tmp18 = method21(v0, v69, v70, v71, v72, v73, v74, v75)
        v76, v77, v78, v79, v80 = tmp18.v0, tmp18.v1, tmp18.v2, tmp18.v3, tmp18.v4
        del tmp18
        return Tuple3(v76, v77, v78, v79, v80, (<signed char>0))
cdef Tuple3 method17(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4):
    cdef bint v5
    cdef signed char v6
    cdef bint v13
    cdef signed long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef bint v17
    cdef bint v18
    cdef unsigned char v19
    cdef signed char v20
    cdef signed long v21
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef bint v24
    cdef bint v25
    cdef unsigned char v26
    cdef unsigned char v27
    cdef signed char v28
    cdef signed long v29
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef bint v32
    cdef bint v33
    cdef unsigned char v34
    cdef unsigned char v35
    cdef signed char v36
    cdef signed long v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef bint v40
    cdef bint v41
    cdef unsigned char v42
    cdef unsigned char v43
    cdef bint v44
    cdef signed char v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef signed char v49
    cdef signed char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef Tuple5 tmp14
    cdef signed char v55
    cdef signed char v56
    cdef signed char v57
    cdef signed char v58
    cdef signed char v59
    cdef signed char v60
    cdef unsigned char v61
    cdef signed char v62
    cdef signed char v63
    cdef signed char v64
    cdef signed char v65
    cdef signed char v66
    cdef Tuple4 tmp15
    cdef signed char v67
    cdef signed char v80
    v5 = v1 == v4
    if v5:
        v6 = v4 - (<signed char>1)
        return method17(v0, v1, v2, v3, v6)
    else:
        v13 = (<signed char>0) <= v4
        if v13:
            v14 = <signed long>v4
            v15 = (<unsigned long long>1) << v14
            v16 = v0 & v15
            v17 = v16 == (<unsigned long long>0)
            v18 = v17 != 1
            if v18:
                v19 = (<unsigned char>1)
            else:
                v19 = (<unsigned char>0)
            v20 = (<signed char>13) + v4
            v21 = <signed long>v20
            v22 = (<unsigned long long>1) << v21
            v23 = v0 & v22
            v24 = v23 == (<unsigned long long>0)
            v25 = v24 != 1
            if v25:
                v26 = (<unsigned char>1)
            else:
                v26 = (<unsigned char>0)
            v27 = v19 + v26
            v28 = (<signed char>26) + v4
            v29 = <signed long>v28
            v30 = (<unsigned long long>1) << v29
            v31 = v0 & v30
            v32 = v31 == (<unsigned long long>0)
            v33 = v32 != 1
            if v33:
                v34 = (<unsigned char>1)
            else:
                v34 = (<unsigned char>0)
            v35 = v27 + v34
            v36 = (<signed char>39) + v4
            v37 = <signed long>v36
            v38 = (<unsigned long long>1) << v37
            v39 = v0 & v38
            v40 = v39 == (<unsigned long long>0)
            v41 = v40 != 1
            if v41:
                v42 = (<unsigned char>1)
            else:
                v42 = (<unsigned char>0)
            v43 = v35 + v42
            v44 = v43 == (<unsigned char>2)
            if v44:
                v45 = (<signed char>-1)
                v46 = (<signed char>-1)
                v47 = (<signed char>-1)
                v48 = (<signed char>-1)
                v49 = (<signed char>0)
                v50 = (<signed char>0)
                tmp14 = method10(v0, v4, v49, v45, v46, v47, v48, v50)
                v51, v52, v53, v54 = tmp14.v0, tmp14.v1, tmp14.v2, tmp14.v3
                del tmp14
                v55 = (<signed char>12)
                v56 = (<signed char>-1)
                v57 = (<signed char>-1)
                v58 = (<signed char>-1)
                v59 = (<signed char>-1)
                v60 = (<signed char>-1)
                v61 = (<unsigned char>0)
                tmp15 = method18(v0, v1, v4, v55, v56, v57, v58, v59, v60, v61)
                v62, v63, v64, v65, v66 = tmp15.v0, tmp15.v1, tmp15.v2, tmp15.v3, tmp15.v4
                del tmp15
                return Tuple3(v3, v2, v51, v52, v62, (<signed char>2))
            else:
                v67 = v4 - (<signed char>1)
                return method17(v0, v1, v2, v3, v67)
        else:
            v80 = (<signed char>12)
            return method20(v0, v80)
cdef Tuple3 method16(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef Tuple5 tmp13
    cdef signed char v44
    cdef signed char v51
    cdef signed char v64
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>2)
        if v33:
            v34 = (<signed char>-1)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>0)
            v39 = (<signed char>0)
            tmp13 = method10(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp13.v0, tmp13.v1, tmp13.v2, tmp13.v3
            del tmp13
            v44 = (<signed char>12)
            return method17(v0, v1, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method16(v0, v51)
    else:
        v64 = (<signed char>12)
        return method20(v0, v64)
cdef Tuple3 method15(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef Tuple5 tmp11
    cdef signed char v44
    cdef signed char v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef signed char v49
    cdef unsigned char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef signed char v55
    cdef Tuple4 tmp12
    cdef signed char v56
    cdef signed char v69
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>3)
        if v33:
            v34 = (<signed char>-1)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>0)
            v39 = (<signed char>0)
            tmp11 = method10(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp11.v0, tmp11.v1, tmp11.v2, tmp11.v3
            del tmp11
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp12 = method7(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp12.v0, tmp12.v1, tmp12.v2, tmp12.v3, tmp12.v4
            del tmp12
            return Tuple3(v40, v41, v42, v51, v52, (<signed char>3))
        else:
            v56 = v1 - (<signed char>1)
            return method15(v0, v56)
    else:
        v69 = (<signed char>12)
        return method16(v0, v69)
cdef Tuple3 method14(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed char v3
    cdef bint v4
    cdef signed char v6
    cdef signed long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef bint v10
    cdef bint v11
    cdef bint v32
    cdef signed char v12
    cdef signed long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef bint v16
    cdef bint v17
    cdef signed char v18
    cdef signed long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef bint v22
    cdef bint v23
    cdef signed char v24
    cdef signed long v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef bint v28
    cdef bint v155
    cdef signed char v33
    cdef bint v34
    cdef signed char v36
    cdef signed long v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef bint v40
    cdef bint v41
    cdef bint v62
    cdef signed char v42
    cdef signed long v43
    cdef unsigned long long v44
    cdef unsigned long long v45
    cdef bint v46
    cdef bint v47
    cdef signed char v48
    cdef signed long v49
    cdef unsigned long long v50
    cdef unsigned long long v51
    cdef bint v52
    cdef bint v53
    cdef signed char v54
    cdef signed long v55
    cdef unsigned long long v56
    cdef unsigned long long v57
    cdef bint v58
    cdef signed char v63
    cdef bint v64
    cdef signed char v66
    cdef signed long v67
    cdef unsigned long long v68
    cdef unsigned long long v69
    cdef bint v70
    cdef bint v71
    cdef bint v92
    cdef signed char v72
    cdef signed long v73
    cdef unsigned long long v74
    cdef unsigned long long v75
    cdef bint v76
    cdef bint v77
    cdef signed char v78
    cdef signed long v79
    cdef unsigned long long v80
    cdef unsigned long long v81
    cdef bint v82
    cdef bint v83
    cdef signed char v84
    cdef signed long v85
    cdef unsigned long long v86
    cdef unsigned long long v87
    cdef bint v88
    cdef signed char v93
    cdef bint v94
    cdef signed char v96
    cdef signed long v97
    cdef unsigned long long v98
    cdef unsigned long long v99
    cdef bint v100
    cdef bint v101
    cdef bint v122
    cdef signed char v102
    cdef signed long v103
    cdef unsigned long long v104
    cdef unsigned long long v105
    cdef bint v106
    cdef bint v107
    cdef signed char v108
    cdef signed long v109
    cdef unsigned long long v110
    cdef unsigned long long v111
    cdef bint v112
    cdef bint v113
    cdef signed char v114
    cdef signed long v115
    cdef unsigned long long v116
    cdef unsigned long long v117
    cdef bint v118
    cdef bint v123
    cdef signed char v125
    cdef signed long v126
    cdef unsigned long long v127
    cdef unsigned long long v128
    cdef bint v129
    cdef bint v130
    cdef signed char v131
    cdef signed long v132
    cdef unsigned long long v133
    cdef unsigned long long v134
    cdef bint v135
    cdef bint v136
    cdef signed char v137
    cdef signed long v138
    cdef unsigned long long v139
    cdef unsigned long long v140
    cdef bint v141
    cdef bint v142
    cdef signed char v143
    cdef signed long v144
    cdef unsigned long long v145
    cdef unsigned long long v146
    cdef bint v147
    cdef signed char v157
    cdef signed char v158
    cdef signed char v159
    cdef signed char v160
    cdef signed char v161
    cdef signed char v162
    cdef signed char v163
    cdef signed char v164
    cdef signed char v165
    cdef signed char v166
    cdef signed char v167
    cdef Tuple5 tmp6
    cdef signed char v168
    cdef bint v169
    cdef signed char v171
    cdef signed char v172
    cdef signed char v173
    cdef signed char v174
    cdef signed char v175
    cdef signed char v176
    cdef signed char v177
    cdef signed char v178
    cdef signed char v179
    cdef signed char v180
    cdef signed char v181
    cdef Tuple5 tmp7
    cdef signed char v182
    cdef bint v183
    cdef signed char v185
    cdef signed char v186
    cdef signed char v187
    cdef signed char v188
    cdef signed char v189
    cdef signed char v190
    cdef signed char v191
    cdef signed char v192
    cdef signed char v193
    cdef signed char v194
    cdef signed char v195
    cdef Tuple5 tmp8
    cdef signed char v196
    cdef bint v197
    cdef signed char v199
    cdef signed char v200
    cdef signed char v201
    cdef signed char v202
    cdef signed char v203
    cdef signed char v204
    cdef signed char v205
    cdef signed char v206
    cdef signed char v207
    cdef signed char v208
    cdef signed char v209
    cdef Tuple5 tmp9
    cdef bint v210
    cdef signed char v212
    cdef signed char v213
    cdef signed char v214
    cdef signed char v215
    cdef signed char v216
    cdef signed char v217
    cdef signed char v218
    cdef signed char v219
    cdef signed char v220
    cdef signed char v221
    cdef signed char v222
    cdef Tuple5 tmp10
    cdef signed char v223
    cdef signed char v236
    v2 = (<signed char>-1) <= v1
    if v2:
        v3 = v1 + (<signed char>4)
        v4 = v3 < (<signed char>0)
        if v4:
            v6 = v3 + (<signed char>13)
        else:
            v6 = v3
        v7 = <signed long>v6
        v8 = (<unsigned long long>1) << v7
        v9 = v0 & v8
        v10 = v9 == (<unsigned long long>0)
        v11 = v10 != 1
        if v11:
            v32 = 1
        else:
            v12 = (<signed char>13) + v6
            v13 = <signed long>v12
            v14 = (<unsigned long long>1) << v13
            v15 = v0 & v14
            v16 = v15 == (<unsigned long long>0)
            v17 = v16 != 1
            if v17:
                v32 = 1
            else:
                v18 = (<signed char>26) + v6
                v19 = <signed long>v18
                v20 = (<unsigned long long>1) << v19
                v21 = v0 & v20
                v22 = v21 == (<unsigned long long>0)
                v23 = v22 != 1
                if v23:
                    v32 = 1
                else:
                    v24 = (<signed char>39) + v6
                    v25 = <signed long>v24
                    v26 = (<unsigned long long>1) << v25
                    v27 = v0 & v26
                    v28 = v27 == (<unsigned long long>0)
                    v32 = v28 != 1
        if v32:
            v33 = v1 + (<signed char>3)
            v34 = v33 < (<signed char>0)
            if v34:
                v36 = v33 + (<signed char>13)
            else:
                v36 = v33
            v37 = <signed long>v36
            v38 = (<unsigned long long>1) << v37
            v39 = v0 & v38
            v40 = v39 == (<unsigned long long>0)
            v41 = v40 != 1
            if v41:
                v62 = 1
            else:
                v42 = (<signed char>13) + v36
                v43 = <signed long>v42
                v44 = (<unsigned long long>1) << v43
                v45 = v0 & v44
                v46 = v45 == (<unsigned long long>0)
                v47 = v46 != 1
                if v47:
                    v62 = 1
                else:
                    v48 = (<signed char>26) + v36
                    v49 = <signed long>v48
                    v50 = (<unsigned long long>1) << v49
                    v51 = v0 & v50
                    v52 = v51 == (<unsigned long long>0)
                    v53 = v52 != 1
                    if v53:
                        v62 = 1
                    else:
                        v54 = (<signed char>39) + v36
                        v55 = <signed long>v54
                        v56 = (<unsigned long long>1) << v55
                        v57 = v0 & v56
                        v58 = v57 == (<unsigned long long>0)
                        v62 = v58 != 1
            if v62:
                v63 = v1 + (<signed char>2)
                v64 = v63 < (<signed char>0)
                if v64:
                    v66 = v63 + (<signed char>13)
                else:
                    v66 = v63
                v67 = <signed long>v66
                v68 = (<unsigned long long>1) << v67
                v69 = v0 & v68
                v70 = v69 == (<unsigned long long>0)
                v71 = v70 != 1
                if v71:
                    v92 = 1
                else:
                    v72 = (<signed char>13) + v66
                    v73 = <signed long>v72
                    v74 = (<unsigned long long>1) << v73
                    v75 = v0 & v74
                    v76 = v75 == (<unsigned long long>0)
                    v77 = v76 != 1
                    if v77:
                        v92 = 1
                    else:
                        v78 = (<signed char>26) + v66
                        v79 = <signed long>v78
                        v80 = (<unsigned long long>1) << v79
                        v81 = v0 & v80
                        v82 = v81 == (<unsigned long long>0)
                        v83 = v82 != 1
                        if v83:
                            v92 = 1
                        else:
                            v84 = (<signed char>39) + v66
                            v85 = <signed long>v84
                            v86 = (<unsigned long long>1) << v85
                            v87 = v0 & v86
                            v88 = v87 == (<unsigned long long>0)
                            v92 = v88 != 1
                if v92:
                    v93 = v1 + (<signed char>1)
                    v94 = v93 < (<signed char>0)
                    if v94:
                        v96 = v93 + (<signed char>13)
                    else:
                        v96 = v93
                    v97 = <signed long>v96
                    v98 = (<unsigned long long>1) << v97
                    v99 = v0 & v98
                    v100 = v99 == (<unsigned long long>0)
                    v101 = v100 != 1
                    if v101:
                        v122 = 1
                    else:
                        v102 = (<signed char>13) + v96
                        v103 = <signed long>v102
                        v104 = (<unsigned long long>1) << v103
                        v105 = v0 & v104
                        v106 = v105 == (<unsigned long long>0)
                        v107 = v106 != 1
                        if v107:
                            v122 = 1
                        else:
                            v108 = (<signed char>26) + v96
                            v109 = <signed long>v108
                            v110 = (<unsigned long long>1) << v109
                            v111 = v0 & v110
                            v112 = v111 == (<unsigned long long>0)
                            v113 = v112 != 1
                            if v113:
                                v122 = 1
                            else:
                                v114 = (<signed char>39) + v96
                                v115 = <signed long>v114
                                v116 = (<unsigned long long>1) << v115
                                v117 = v0 & v116
                                v118 = v117 == (<unsigned long long>0)
                                v122 = v118 != 1
                    if v122:
                        v123 = v1 < (<signed char>0)
                        if v123:
                            v125 = v1 + (<signed char>13)
                        else:
                            v125 = v1
                        v126 = <signed long>v125
                        v127 = (<unsigned long long>1) << v126
                        v128 = v0 & v127
                        v129 = v128 == (<unsigned long long>0)
                        v130 = v129 != 1
                        if v130:
                            v155 = 1
                        else:
                            v131 = (<signed char>13) + v125
                            v132 = <signed long>v131
                            v133 = (<unsigned long long>1) << v132
                            v134 = v0 & v133
                            v135 = v134 == (<unsigned long long>0)
                            v136 = v135 != 1
                            if v136:
                                v155 = 1
                            else:
                                v137 = (<signed char>26) + v125
                                v138 = <signed long>v137
                                v139 = (<unsigned long long>1) << v138
                                v140 = v0 & v139
                                v141 = v140 == (<unsigned long long>0)
                                v142 = v141 != 1
                                if v142:
                                    v155 = 1
                                else:
                                    v143 = (<signed char>39) + v125
                                    v144 = <signed long>v143
                                    v145 = (<unsigned long long>1) << v144
                                    v146 = v0 & v145
                                    v147 = v146 == (<unsigned long long>0)
                                    v155 = v147 != 1
                    else:
                        v155 = 0
                else:
                    v155 = 0
            else:
                v155 = 0
        else:
            v155 = 0
        if v155:
            if v4:
                v157 = v3 + (<signed char>13)
            else:
                v157 = v3
            v158 = (<signed char>-1)
            v159 = (<signed char>-1)
            v160 = (<signed char>-1)
            v161 = (<signed char>-1)
            v162 = (<signed char>0)
            v163 = (<signed char>0)
            tmp6 = method10(v0, v157, v162, v158, v159, v160, v161, v163)
            v164, v165, v166, v167 = tmp6.v0, tmp6.v1, tmp6.v2, tmp6.v3
            del tmp6
            v168 = v1 + (<signed char>3)
            v169 = v168 < (<signed char>0)
            if v169:
                v171 = v168 + (<signed char>13)
            else:
                v171 = v168
            v172 = (<signed char>-1)
            v173 = (<signed char>-1)
            v174 = (<signed char>-1)
            v175 = (<signed char>-1)
            v176 = (<signed char>0)
            v177 = (<signed char>0)
            tmp7 = method10(v0, v171, v176, v172, v173, v174, v175, v177)
            v178, v179, v180, v181 = tmp7.v0, tmp7.v1, tmp7.v2, tmp7.v3
            del tmp7
            v182 = v1 + (<signed char>2)
            v183 = v182 < (<signed char>0)
            if v183:
                v185 = v182 + (<signed char>13)
            else:
                v185 = v182
            v186 = (<signed char>-1)
            v187 = (<signed char>-1)
            v188 = (<signed char>-1)
            v189 = (<signed char>-1)
            v190 = (<signed char>0)
            v191 = (<signed char>0)
            tmp8 = method10(v0, v185, v190, v186, v187, v188, v189, v191)
            v192, v193, v194, v195 = tmp8.v0, tmp8.v1, tmp8.v2, tmp8.v3
            del tmp8
            v196 = v1 + (<signed char>1)
            v197 = v196 < (<signed char>0)
            if v197:
                v199 = v196 + (<signed char>13)
            else:
                v199 = v196
            v200 = (<signed char>-1)
            v201 = (<signed char>-1)
            v202 = (<signed char>-1)
            v203 = (<signed char>-1)
            v204 = (<signed char>0)
            v205 = (<signed char>0)
            tmp9 = method10(v0, v199, v204, v200, v201, v202, v203, v205)
            v206, v207, v208, v209 = tmp9.v0, tmp9.v1, tmp9.v2, tmp9.v3
            del tmp9
            v210 = v1 < (<signed char>0)
            if v210:
                v212 = v1 + (<signed char>13)
            else:
                v212 = v1
            v213 = (<signed char>-1)
            v214 = (<signed char>-1)
            v215 = (<signed char>-1)
            v216 = (<signed char>-1)
            v217 = (<signed char>0)
            v218 = (<signed char>0)
            tmp10 = method10(v0, v212, v217, v213, v214, v215, v216, v218)
            v219, v220, v221, v222 = tmp10.v0, tmp10.v1, tmp10.v2, tmp10.v3
            del tmp10
            return Tuple3(v164, v178, v192, v206, v219, (<signed char>4))
        else:
            v223 = v1 - (<signed char>1)
            return method14(v0, v223)
    else:
        v236 = (<signed char>12)
        return method15(v0, v236)
cdef Tuple3 method12(unsigned long long v0, signed char v1, unsigned char v2, unsigned char v3, unsigned char v4, unsigned char v5):
    cdef bint v6
    cdef signed long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef bint v10
    cdef bint v11
    cdef unsigned char v12
    cdef unsigned char v13
    cdef signed char v14
    cdef signed long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef bint v18
    cdef bint v19
    cdef unsigned char v20
    cdef unsigned char v21
    cdef signed char v22
    cdef signed long v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef bint v26
    cdef bint v27
    cdef unsigned char v28
    cdef unsigned char v29
    cdef signed char v30
    cdef signed long v31
    cdef unsigned long long v32
    cdef unsigned long long v33
    cdef bint v34
    cdef bint v35
    cdef unsigned char v36
    cdef unsigned char v37
    cdef bint v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef unsigned char v46
    cdef bint v53
    cdef signed char v54
    cdef signed char v55
    cdef signed char v56
    cdef signed char v57
    cdef signed char v58
    cdef signed char v59
    cdef signed char v60
    cdef unsigned char v61
    cdef bint v68
    cdef signed char v69
    cdef signed char v70
    cdef signed char v71
    cdef signed char v72
    cdef signed char v73
    cdef signed char v74
    cdef signed char v75
    cdef unsigned char v76
    cdef bint v83
    cdef signed char v84
    cdef signed char v85
    cdef signed char v86
    cdef signed char v87
    cdef signed char v88
    cdef signed char v89
    cdef signed char v90
    cdef unsigned char v91
    cdef signed char v98
    cdef signed char v129
    v6 = (<signed char>0) <= v1
    if v6:
        v7 = <signed long>v1
        v8 = (<unsigned long long>1) << v7
        v9 = v0 & v8
        v10 = v9 == (<unsigned long long>0)
        v11 = v10 != 1
        if v11:
            v12 = (<unsigned char>1)
        else:
            v12 = (<unsigned char>0)
        v13 = v5 + v12
        v14 = (<signed char>13) + v1
        v15 = <signed long>v14
        v16 = (<unsigned long long>1) << v15
        v17 = v0 & v16
        v18 = v17 == (<unsigned long long>0)
        v19 = v18 != 1
        if v19:
            v20 = (<unsigned char>1)
        else:
            v20 = (<unsigned char>0)
        v21 = v4 + v20
        v22 = (<signed char>26) + v1
        v23 = <signed long>v22
        v24 = (<unsigned long long>1) << v23
        v25 = v0 & v24
        v26 = v25 == (<unsigned long long>0)
        v27 = v26 != 1
        if v27:
            v28 = (<unsigned char>1)
        else:
            v28 = (<unsigned char>0)
        v29 = v3 + v28
        v30 = (<signed char>39) + v1
        v31 = <signed long>v30
        v32 = (<unsigned long long>1) << v31
        v33 = v0 & v32
        v34 = v33 == (<unsigned long long>0)
        v35 = v34 != 1
        if v35:
            v36 = (<unsigned char>1)
        else:
            v36 = (<unsigned char>0)
        v37 = v2 + v36
        v38 = (<unsigned char>5) == v13
        if v38:
            v39 = (<signed char>0)
            v40 = (<signed char>12)
            v41 = (<signed char>-1)
            v42 = (<signed char>-1)
            v43 = (<signed char>-1)
            v44 = (<signed char>-1)
            v45 = (<signed char>-1)
            v46 = (<unsigned char>0)
            return method13(v0, v39, v40, v41, v42, v43, v44, v45, v46)
        else:
            v53 = (<unsigned char>5) == v21
            if v53:
                v54 = (<signed char>1)
                v55 = (<signed char>12)
                v56 = (<signed char>-1)
                v57 = (<signed char>-1)
                v58 = (<signed char>-1)
                v59 = (<signed char>-1)
                v60 = (<signed char>-1)
                v61 = (<unsigned char>0)
                return method13(v0, v54, v55, v56, v57, v58, v59, v60, v61)
            else:
                v68 = (<unsigned char>5) == v29
                if v68:
                    v69 = (<signed char>2)
                    v70 = (<signed char>12)
                    v71 = (<signed char>-1)
                    v72 = (<signed char>-1)
                    v73 = (<signed char>-1)
                    v74 = (<signed char>-1)
                    v75 = (<signed char>-1)
                    v76 = (<unsigned char>0)
                    return method13(v0, v69, v70, v71, v72, v73, v74, v75, v76)
                else:
                    v83 = (<unsigned char>5) == v37
                    if v83:
                        v84 = (<signed char>3)
                        v85 = (<signed char>12)
                        v86 = (<signed char>-1)
                        v87 = (<signed char>-1)
                        v88 = (<signed char>-1)
                        v89 = (<signed char>-1)
                        v90 = (<signed char>-1)
                        v91 = (<unsigned char>0)
                        return method13(v0, v84, v85, v86, v87, v88, v89, v90, v91)
                    else:
                        v98 = v1 - (<signed char>1)
                        return method12(v0, v98, v37, v29, v21, v13)
    else:
        v129 = (<signed char>8)
        return method14(v0, v129)
cdef Tuple3 method11(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5):
    cdef bint v6
    cdef signed char v7
    cdef bint v14
    cdef signed long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef bint v18
    cdef bint v19
    cdef unsigned char v20
    cdef signed char v21
    cdef signed long v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef bint v25
    cdef bint v26
    cdef unsigned char v27
    cdef unsigned char v28
    cdef signed char v29
    cdef signed long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    cdef bint v33
    cdef bint v34
    cdef unsigned char v35
    cdef unsigned char v36
    cdef signed char v37
    cdef signed long v38
    cdef unsigned long long v39
    cdef unsigned long long v40
    cdef bint v41
    cdef bint v42
    cdef unsigned char v43
    cdef unsigned char v44
    cdef bint v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef signed char v49
    cdef signed char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef signed char v55
    cdef Tuple5 tmp5
    cdef signed char v56
    cdef signed char v69
    cdef unsigned char v70
    cdef unsigned char v71
    cdef unsigned char v72
    cdef unsigned char v73
    v6 = v1 == v5
    if v6:
        v7 = v5 - (<signed char>1)
        return method11(v0, v1, v2, v3, v4, v7)
    else:
        v14 = (<signed char>0) <= v5
        if v14:
            v15 = <signed long>v5
            v16 = (<unsigned long long>1) << v15
            v17 = v0 & v16
            v18 = v17 == (<unsigned long long>0)
            v19 = v18 != 1
            if v19:
                v20 = (<unsigned char>1)
            else:
                v20 = (<unsigned char>0)
            v21 = (<signed char>13) + v5
            v22 = <signed long>v21
            v23 = (<unsigned long long>1) << v22
            v24 = v0 & v23
            v25 = v24 == (<unsigned long long>0)
            v26 = v25 != 1
            if v26:
                v27 = (<unsigned char>1)
            else:
                v27 = (<unsigned char>0)
            v28 = v20 + v27
            v29 = (<signed char>26) + v5
            v30 = <signed long>v29
            v31 = (<unsigned long long>1) << v30
            v32 = v0 & v31
            v33 = v32 == (<unsigned long long>0)
            v34 = v33 != 1
            if v34:
                v35 = (<unsigned char>1)
            else:
                v35 = (<unsigned char>0)
            v36 = v28 + v35
            v37 = (<signed char>39) + v5
            v38 = <signed long>v37
            v39 = (<unsigned long long>1) << v38
            v40 = v0 & v39
            v41 = v40 == (<unsigned long long>0)
            v42 = v41 != 1
            if v42:
                v43 = (<unsigned char>1)
            else:
                v43 = (<unsigned char>0)
            v44 = v36 + v43
            v45 = (<unsigned char>2) <= v44
            if v45:
                v46 = (<signed char>-1)
                v47 = (<signed char>-1)
                v48 = (<signed char>-1)
                v49 = (<signed char>-1)
                v50 = (<signed char>0)
                v51 = (<signed char>0)
                tmp5 = method10(v0, v5, v50, v46, v47, v48, v49, v51)
                v52, v53, v54, v55 = tmp5.v0, tmp5.v1, tmp5.v2, tmp5.v3
                del tmp5
                return Tuple3(v4, v3, v2, v52, v53, (<signed char>6))
            else:
                v56 = v5 - (<signed char>1)
                return method11(v0, v1, v2, v3, v4, v56)
        else:
            v69 = (<signed char>12)
            v70 = (<unsigned char>0)
            v71 = (<unsigned char>0)
            v72 = (<unsigned char>0)
            v73 = (<unsigned char>0)
            return method12(v0, v69, v73, v72, v71, v70)
cdef Tuple3 method9(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef Tuple5 tmp4
    cdef signed char v44
    cdef signed char v51
    cdef signed char v64
    cdef unsigned char v65
    cdef unsigned char v66
    cdef unsigned char v67
    cdef unsigned char v68
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>3)
        if v33:
            v34 = (<signed char>-1)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>0)
            v39 = (<signed char>0)
            tmp4 = method10(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp4.v0, tmp4.v1, tmp4.v2, tmp4.v3
            del tmp4
            v44 = (<signed char>12)
            return method11(v0, v1, v42, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method9(v0, v51)
    else:
        v64 = (<signed char>12)
        v65 = (<unsigned char>0)
        v66 = (<unsigned char>0)
        v67 = (<unsigned char>0)
        v68 = (<unsigned char>0)
        return method12(v0, v64, v68, v67, v66, v65)
cdef Tuple3 method6(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef unsigned char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef Tuple4 tmp3
    cdef signed char v46
    cdef signed char v59
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>4)
        if v33:
            v34 = (<signed char>12)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>-1)
            v39 = (<signed char>-1)
            v40 = (<unsigned char>0)
            tmp3 = method7(v0, v1, v34, v35, v36, v37, v38, v39, v40)
            v41, v42, v43, v44, v45 = tmp3.v0, tmp3.v1, tmp3.v2, tmp3.v3, tmp3.v4
            del tmp3
            return Tuple3(v1, v9, v17, v25, v41, (<signed char>7))
        else:
            v46 = v1 - (<signed char>1)
            return method6(v0, v46)
    else:
        v59 = (<signed char>12)
        return method9(v0, v59)
cdef Tuple3 method4(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed char v3
    cdef signed char v10
    v2 = (<signed char>-1) <= v1
    if v2:
        v3 = (<signed char>0)
        return method5(v0, v1, v3)
    else:
        v10 = (<signed char>12)
        return method6(v0, v10)
cdef Tuple3 method2(signed char v0, signed char v1, numpy.ndarray[signed char,ndim=1] v2):
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef signed long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef signed short v9
    cdef unsigned long long tmp2
    cdef Mut2 v10
    cdef signed short v12
    cdef signed short v13
    cdef signed short v14
    cdef signed short v15
    cdef unsigned long long v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef signed short v21
    cdef unsigned long long v22
    cdef signed char v23
    v3 = <signed long>v1
    v4 = (<unsigned long long>1) << v3
    v5 = (<unsigned long long>0) | v4
    v6 = <signed long>v0
    v7 = (<unsigned long long>1) << v6
    v8 = v5 | v7
    tmp2 = len(v2)
    if <signed short>tmp2 != tmp2: raise Exception("The conversion to signed short failed.")
    v9 = <signed short>tmp2
    v10 = Mut2((<signed short>0), v8)
    while method3(v9, v10):
        v12 = v10.v0
        v13 = -v12
        v14 = v13 + v9
        v15 = v14 - (<signed short>1)
        v16 = v10.v1
        v17 = v2[v15]
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v16 | v19
        v21 = v12 + (<signed short>1)
        v10.v0 = v21
        v10.v1 = v20
    v22 = v10.v1
    del v10
    v23 = (<signed char>8)
    return method4(v22, v23)
cdef Tuple3 method23(numpy.ndarray[signed char,ndim=1] v0):
    cdef signed short v1
    cdef unsigned long long tmp20
    cdef Mut2 v2
    cdef signed short v4
    cdef signed short v5
    cdef signed short v6
    cdef signed short v7
    cdef unsigned long long v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef signed short v13
    cdef unsigned long long v14
    cdef signed char v15
    tmp20 = len(v0)
    if <signed short>tmp20 != tmp20: raise Exception("The conversion to signed short failed.")
    v1 = <signed short>tmp20
    v2 = Mut2((<signed short>0), (<unsigned long long>0))
    while method3(v1, v2):
        v4 = v2.v0
        v5 = -v4
        v6 = v5 + v1
        v7 = v6 - (<signed short>1)
        v8 = v2.v1
        v9 = v0[v7]
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v8 | v11
        v13 = v4 + (<signed short>1)
        v2.v0 = v13
        v2.v1 = v12
    v14 = v2.v1
    del v2
    v15 = (<signed char>8)
    return method4(v14, v15)
cdef UH1 method24(UH0 v0, UH1 v1):
    cdef US0 v2
    cdef UH0 v3
    cdef UH1 v4
    cdef US2 v9
    cdef signed char v5
    cdef US1 v7
    if v0.tag == 0: # Cons
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = method24(v3, v1)
        del v3
        if v2.tag == 0: # C1of2
            v5 = (<US0_0>v2).v0
            v9 = US2_1(v5)
        elif v2.tag == 1: # C2of2
            v7 = (<US0_1>v2).v0
            v9 = US2_0(v7)
            del v7
        del v2
        return UH1_0(v9, v4)
    elif v0.tag == 1: # Nil
        return v1
cdef bint method25(signed short v0, Mut3 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef UH2 method26(UH1 v0, UH2 v1):
    cdef US2 v2
    cdef UH1 v3
    cdef UH2 v4
    cdef US3 v5
    if v0.tag == 0: # Cons
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = method26(v3, v1)
        del v3
        v5 = US3_3(v2)
        del v2
        return UH2_0(v5, v4)
    elif v0.tag == 1: # Nil
        return v1
cdef unsigned long long method27(UH1 v0, unsigned long long v1) except *:
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # Cons
        v3 = (<UH1_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method27(v3, v4)
    elif v0.tag == 1: # Nil
        return v1
cdef unsigned long long method28(UH2 v0, unsigned long long v1) except *:
    cdef UH2 v3
    cdef unsigned long long v4
    if v0.tag == 0: # Cons
        v3 = (<UH2_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method28(v3, v4)
    elif v0.tag == 1: # Nil
        return v1
cdef signed short method31(signed short v0, numpy.ndarray[float,ndim=1] v1, signed short v2, signed short v3, signed short v4) except *:
    cdef bint v5
    cdef signed short v6
    cdef signed short v7
    cdef signed short v8
    cdef signed long v9
    cdef signed short v10
    cdef signed short v11
    cdef signed short v12
    cdef signed short v13
    cdef float v14
    cdef signed short v15
    v5 = v3 < v0
    if v5:
        v6 = v3 + (<signed short>1)
        v7 = v0 - v3
        v8 = v7 - (<signed short>1)
        v9 = <signed long>v8
        v10 = (<signed short>1) << v9
        v11 = <signed short>v3
        v12 = v2 + v11
        v13 = v4 // v10
        v14 = <float>v13
        v1[v12] = v14
        v15 = v4 % v10
        return method31(v0, v1, v2, v6, v15)
    else:
        return v4
cdef void method30(signed short v0, signed short v1, numpy.ndarray[float,ndim=1] v2, signed short v3) except *:
    cdef signed long v4
    cdef signed long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef bint v9
    cdef bint v12
    cdef unsigned long long v10
    cdef signed short v13
    cdef signed short v14
    cdef signed short v15
    cdef str v16
    v4 = <signed long>v0
    v5 = v4 - (<signed long>1)
    v6 = (<unsigned long long>1) << v5
    v7 = v6 - (<unsigned long long>1)
    v8 = v6 + v7
    v9 = (<signed short>0) <= v1
    if v9:
        v10 = <unsigned long long>v1
        v12 = v10 < v8
    else:
        v12 = 0
    if v12:
        v13 = v1 + (<signed short>1)
        v14 = (<signed short>0)
        v15 = method31(v0, v2, v3, v14, v13)
    else:
        v16 = f'Pickle failure. Bin int value out of bounds. Got: {v1} Size: {v0}'
        raise Exception(v16)
cdef unsigned long long method29(signed short v0, signed short v1, signed short v2, signed short v3, signed short v4, numpy.ndarray[float,ndim=3] v5, unsigned long long v6, UH1 v7, unsigned long long v8) except *:
    cdef US2 v9
    cdef UH1 v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef US1 v12
    cdef signed short v13
    cdef signed short v14
    cdef signed char v15
    cdef signed char v16
    cdef signed char v17
    cdef bint v18
    cdef bint v21
    cdef signed short v19
    cdef signed short v22
    cdef signed short v23
    cdef str v24
    cdef signed short v25
    cdef bint v26
    cdef bint v29
    cdef signed short v27
    cdef signed short v30
    cdef signed short v31
    cdef str v32
    cdef signed char v33
    cdef signed char v34
    cdef bint v35
    cdef bint v38
    cdef signed short v36
    cdef signed short v39
    cdef signed short v40
    cdef str v41
    cdef signed short v42
    cdef bint v43
    cdef bint v46
    cdef signed short v44
    cdef signed short v47
    cdef signed short v48
    cdef str v49
    cdef unsigned long long v50
    if v7.tag == 0: # Cons
        v9 = (<UH1_0>v7).v0; v10 = (<UH1_0>v7).v1
        v11 = v5[v6,v8]
        if v9.tag == 0: # PAction
            v12 = (<US2_0>v9).v0
            if v12.tag == 0: # Call
                v11[(<signed short>0)] = (<float>1)
            elif v12.tag == 1: # Fold
                v11[(<signed short>1)] = (<float>1)
            elif v12.tag == 2: # RaiseTo
                v13 = (<US1_2>v12).v0
                v14 = (<signed short>2)
                method30(v0, v13, v11, v14)
            del v12
        elif v9.tag == 1: # PCardPresent
            v15 = (<US2_1>v9).v0
            v16 = v15 // (<signed char>13)
            v17 = v15 % (<signed char>13)
            v18 = (<signed char>0) <= v16
            if v18:
                v19 = <signed short>v16
                v21 = v19 < (<signed short>4)
            else:
                v21 = 0
            if v21:
                v22 = <signed short>v16
                v23 = v1 + v22
                v11[v23] = (<float>1)
            else:
                v24 = f'Pickle failure. Int value out of bounds. Got: {v16} Size: {(<signed short>4)}'
                raise Exception(v24)
            v25 = v1 + (<signed short>4)
            v26 = (<signed char>0) <= v17
            if v26:
                v27 = <signed short>v17
                v29 = v27 < (<signed short>13)
            else:
                v29 = 0
            if v29:
                v30 = <signed short>v17
                v31 = v25 + v30
                v11[v31] = (<float>1)
            else:
                v32 = f'Pickle failure. Int value out of bounds. Got: {v17} Size: {(<signed short>13)}'
                raise Exception(v32)
        elif v9.tag == 2: # PInfo
            v33 = (<US2_2>v9).v0; v34 = (<US2_2>v9).v1
            v35 = (<signed char>0) <= v33
            if v35:
                v36 = <signed short>v33
                v38 = v36 < (<signed short>9)
            else:
                v38 = 0
            if v38:
                v39 = <signed short>v33
                v40 = v2 + v39
                v11[v40] = (<float>1)
            else:
                v41 = f'Pickle failure. Int value out of bounds. Got: {v33} Size: {(<signed short>9)}'
                raise Exception(v41)
            v42 = v2 + (<signed short>9)
            v43 = (<signed char>0) <= v34
            if v43:
                v44 = <signed short>v34
                v46 = v44 < (<signed short>9)
            else:
                v46 = 0
            if v46:
                v47 = <signed short>v34
                v48 = v42 + v47
                v11[v48] = (<float>1)
            else:
                v49 = f'Pickle failure. Int value out of bounds. Got: {v34} Size: {(<signed short>9)}'
                raise Exception(v49)
        del v9; del v11
        v50 = v8 + (<unsigned long long>1)
        return method29(v0, v1, v2, v3, v4, v5, v6, v10, v50)
    elif v7.tag == 1: # Nil
        return v8
cdef void method32(unsigned long long v0, numpy.ndarray[signed char,ndim=2] v1, unsigned long long v2, unsigned long long v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v1[v2,v3] = 1
        method32(v0, v1, v2, v5)
    else:
        pass
cdef unsigned long long method33(signed short v0, signed short v1, signed short v2, signed short v3, signed short v4, numpy.ndarray[float,ndim=3] v5, unsigned long long v6, UH2 v7, unsigned long long v8) except *:
    cdef US3 v9
    cdef UH2 v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef bint v15
    cdef bint v18
    cdef signed short v16
    cdef signed short v19
    cdef str v20
    cdef bint v21
    cdef bint v24
    cdef signed short v22
    cdef signed short v25
    cdef signed short v26
    cdef str v27
    cdef signed char v28
    cdef signed char v29
    cdef signed char v30
    cdef bint v31
    cdef bint v34
    cdef signed short v32
    cdef signed short v35
    cdef signed short v36
    cdef str v37
    cdef bint v38
    cdef bint v41
    cdef signed short v39
    cdef signed short v42
    cdef signed short v43
    cdef str v44
    cdef signed long v45
    cdef signed char v46
    cdef signed char v47
    cdef bint v48
    cdef bint v51
    cdef signed short v49
    cdef signed short v52
    cdef signed short v53
    cdef str v54
    cdef bint v55
    cdef bint v58
    cdef signed short v56
    cdef signed short v59
    cdef signed short v60
    cdef str v61
    cdef signed long v62
    cdef bint v63
    cdef bint v66
    cdef signed short v64
    cdef signed short v67
    cdef signed short v68
    cdef str v69
    cdef US2 v70
    cdef US1 v71
    cdef signed short v72
    cdef signed short v73
    cdef signed char v74
    cdef signed short v75
    cdef signed char v76
    cdef signed char v77
    cdef bint v78
    cdef bint v81
    cdef signed short v79
    cdef signed short v82
    cdef signed short v83
    cdef str v84
    cdef signed short v85
    cdef bint v86
    cdef bint v89
    cdef signed short v87
    cdef signed short v90
    cdef signed short v91
    cdef str v92
    cdef signed char v93
    cdef signed char v94
    cdef signed short v95
    cdef bint v96
    cdef bint v99
    cdef signed short v97
    cdef signed short v100
    cdef signed short v101
    cdef str v102
    cdef signed short v103
    cdef bint v104
    cdef bint v107
    cdef signed short v105
    cdef signed short v108
    cdef signed short v109
    cdef str v110
    cdef unsigned long long v111
    if v7.tag == 0: # Cons
        v9 = (<UH2_0>v7).v0; v10 = (<UH2_0>v7).v1
        v11 = v5[v6,v8]
        if v9.tag == 0: # VCardFuture
            v12 = (<US3_0>v9).v0
            v13 = v12 // (<signed char>13)
            v14 = v12 % (<signed char>13)
            v15 = (<signed char>0) <= v13
            if v15:
                v16 = <signed short>v13
                v18 = v16 < (<signed short>4)
            else:
                v18 = 0
            if v18:
                v19 = <signed short>v13
                v11[v19] = (<float>1)
            else:
                v20 = f'Pickle failure. Int value out of bounds. Got: {v13} Size: {(<signed short>4)}'
                raise Exception(v20)
            v21 = (<signed char>0) <= v14
            if v21:
                v22 = <signed short>v14
                v24 = v22 < (<signed short>13)
            else:
                v24 = 0
            if v24:
                v25 = <signed short>v14
                v26 = (<signed short>4) + v25
                v11[v26] = (<float>1)
            else:
                v27 = f'Pickle failure. Int value out of bounds. Got: {v14} Size: {(<signed short>13)}'
                raise Exception(v27)
        elif v9.tag == 1: # VCardOpponent
            v28 = (<US3_1>v9).v0
            v29 = v28 // (<signed char>13)
            v30 = v28 % (<signed char>13)
            v31 = (<signed char>0) <= v29
            if v31:
                v32 = <signed short>v29
                v34 = v32 < (<signed short>4)
            else:
                v34 = 0
            if v34:
                v35 = <signed short>v29
                v36 = (<signed short>17) + v35
                v11[v36] = (<float>1)
            else:
                v37 = f'Pickle failure. Int value out of bounds. Got: {v29} Size: {(<signed short>4)}'
                raise Exception(v37)
            v38 = (<signed char>0) <= v30
            if v38:
                v39 = <signed short>v30
                v41 = v39 < (<signed short>13)
            else:
                v41 = 0
            if v41:
                v42 = <signed short>v30
                v43 = (<signed short>21) + v42
                v11[v43] = (<float>1)
            else:
                v44 = f'Pickle failure. Int value out of bounds. Got: {v30} Size: {(<signed short>13)}'
                raise Exception(v44)
        elif v9.tag == 2: # VInfo
            v45 = (<US3_2>v9).v0; v46 = (<US3_2>v9).v1; v47 = (<US3_2>v9).v2
            v48 = (<signed char>0) <= v47
            if v48:
                v49 = <signed short>v47
                v51 = v49 < (<signed short>9)
            else:
                v51 = 0
            if v51:
                v52 = <signed short>v47
                v53 = (<signed short>34) + v52
                v11[v53] = (<float>1)
            else:
                v54 = f'Pickle failure. Int value out of bounds. Got: {v47} Size: {(<signed short>9)}'
                raise Exception(v54)
            v55 = (<signed char>0) <= v46
            if v55:
                v56 = <signed short>v46
                v58 = v56 < (<signed short>9)
            else:
                v58 = 0
            if v58:
                v59 = <signed short>v46
                v60 = (<signed short>43) + v59
                v11[v60] = (<float>1)
            else:
                v61 = f'Pickle failure. Int value out of bounds. Got: {v46} Size: {(<signed short>9)}'
                raise Exception(v61)
            v62 = v45 + (<signed long>1)
            v63 = (<signed long>0) <= v62
            if v63:
                v64 = <signed short>v62
                v66 = v64 < (<signed short>3)
            else:
                v66 = 0
            if v66:
                v67 = <signed short>v62
                v68 = (<signed short>52) + v67
                v11[v68] = (<float>1)
            else:
                v69 = f'Pickle failure. Int value out of bounds. Got: {v62} Size: {(<signed short>3)}'
                raise Exception(v69)
        elif v9.tag == 3: # VPolicy
            v70 = (<US3_3>v9).v0
            if v70.tag == 0: # PAction
                v71 = (<US2_0>v70).v0
                if v71.tag == 0: # Call
                    v11[(<signed short>55)] = (<float>1)
                elif v71.tag == 1: # Fold
                    v11[(<signed short>56)] = (<float>1)
                elif v71.tag == 2: # RaiseTo
                    v72 = (<US1_2>v71).v0
                    v73 = (<signed short>57)
                    method30(v0, v72, v11, v73)
                del v71
            elif v70.tag == 1: # PCardPresent
                v74 = (<US2_1>v70).v0
                v75 = (<signed short>55) + v1
                v76 = v74 // (<signed char>13)
                v77 = v74 % (<signed char>13)
                v78 = (<signed char>0) <= v76
                if v78:
                    v79 = <signed short>v76
                    v81 = v79 < (<signed short>4)
                else:
                    v81 = 0
                if v81:
                    v82 = <signed short>v76
                    v83 = v75 + v82
                    v11[v83] = (<float>1)
                else:
                    v84 = f'Pickle failure. Int value out of bounds. Got: {v76} Size: {(<signed short>4)}'
                    raise Exception(v84)
                v85 = v75 + (<signed short>4)
                v86 = (<signed char>0) <= v77
                if v86:
                    v87 = <signed short>v77
                    v89 = v87 < (<signed short>13)
                else:
                    v89 = 0
                if v89:
                    v90 = <signed short>v77
                    v91 = v85 + v90
                    v11[v91] = (<float>1)
                else:
                    v92 = f'Pickle failure. Int value out of bounds. Got: {v77} Size: {(<signed short>13)}'
                    raise Exception(v92)
            elif v70.tag == 2: # PInfo
                v93 = (<US2_2>v70).v0; v94 = (<US2_2>v70).v1
                v95 = (<signed short>55) + v2
                v96 = (<signed char>0) <= v93
                if v96:
                    v97 = <signed short>v93
                    v99 = v97 < (<signed short>9)
                else:
                    v99 = 0
                if v99:
                    v100 = <signed short>v93
                    v101 = v95 + v100
                    v11[v101] = (<float>1)
                else:
                    v102 = f'Pickle failure. Int value out of bounds. Got: {v93} Size: {(<signed short>9)}'
                    raise Exception(v102)
                v103 = v95 + (<signed short>9)
                v104 = (<signed char>0) <= v94
                if v104:
                    v105 = <signed short>v94
                    v107 = v105 < (<signed short>9)
                else:
                    v107 = 0
                if v107:
                    v108 = <signed short>v94
                    v109 = v103 + v108
                    v11[v109] = (<float>1)
                else:
                    v110 = f'Pickle failure. Int value out of bounds. Got: {v94} Size: {(<signed short>9)}'
                    raise Exception(v110)
            del v70
        del v9; del v11
        v111 = v8 + (<unsigned long long>1)
        return method33(v0, v1, v2, v3, v4, v5, v6, v10, v111)
    elif v7.tag == 1: # Nil
        return v8
cdef void method34(unsigned long long v0, numpy.ndarray[signed char,ndim=2] v1, unsigned long long v2, unsigned long long v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v1[v2,v3] = 1
        method34(v0, v1, v2, v5)
    else:
        pass
cdef Mut4 method35(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef Mut0 v4
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef Mut4 v9
    v3 = numpy.empty(v1,dtype=object)
    v4 = Mut0((<unsigned long long>0))
    while method0(v1, v4):
        v6 = v4.v0
        v7 = [None]*(<unsigned long long>0)
        v3[v6] = v7
        del v7
        v8 = v6 + (<unsigned long long>1)
        v4.v0 = v8
    del v4
    v9 = Mut4(v0, v3, (<unsigned long long>0))
    del v3
    return v9
cdef bint method36(signed short v0, Mut5 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef void method41(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef signed short v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef list v10
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v3[v4]
        v8 = hash(v7)
        v9 = v8 % v1
        v10 = v2[v9]
        v10.append(v7)
        del v10
        method41(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method40(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        v8 = len(v7)
        v9 = (<unsigned long long>0)
        method41(v8, v2, v3, v7, v9)
        del v7
        method40(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method39(Mut4 v0) except *:
    cdef numpy.ndarray[object,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef Mut0 v8
    cdef unsigned long long v10
    cdef list v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    v1 = v0.v1
    v2 = len(v1)
    v3 = v2 * (<unsigned long long>3)
    v4 = v3 // (<unsigned long long>2)
    v5 = v4 + (<unsigned long long>3)
    v6 = v5 <= v2
    if v6:
        raise Exception("The table length cannot be increased.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = Mut0((<unsigned long long>0))
    while method0(v5, v8):
        v10 = v8.v0
        v11 = [None]*(<unsigned long long>0)
        v7[v10] = v11
        del v11
        v12 = v10 + (<unsigned long long>1)
        v8.v0 = v12
    del v8
    v13 = (<unsigned long long>0)
    method40(v2, v1, v5, v7, v13)
    del v1
    v0.v1 = v7
    del v7
    v14 = v0.v0
    v15 = v14 + (<unsigned long long>2)
    v0.v0 = v15
cdef bint method38(Mut4 v0, signed short v1, unsigned long long v2, list v3, unsigned long long v4) except *:
    cdef unsigned long long v5
    cdef bint v6
    cdef signed short v7
    cdef bint v8
    cdef unsigned long long v9
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef numpy.ndarray[object,ndim=1] v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef bint v19
    v5 = len(v3)
    v6 = v4 < v5
    if v6:
        v7 = v3[v4]
        v8 = v1 == v7
        if v8:
            return 0
        else:
            v9 = v4 + (<unsigned long long>1)
            return method38(v0, v1, v2, v3, v9)
    else:
        v3.append(v1)
        v12 = v0.v2
        v13 = v12 + (<unsigned long long>1)
        v0.v2 = v13
        v14 = v0.v2
        v15 = v0.v0
        v16 = v0.v1
        v17 = len(v16)
        del v16
        v18 = v15 * v17
        v19 = v14 >= v18
        if v19:
            method39(v0)
        else:
            pass
        return 1
cdef bint method37(Mut4 v0, signed short v1) except *:
    cdef unsigned long long v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    v3 = hash(v1)
    v4 = v0.v1
    v5 = len(v4)
    v6 = v3 % v5
    v7 = v4[v6]
    del v4
    v8 = (<unsigned long long>0)
    return method38(v0, v1, v3, v7, v8)
cdef bint method42(list v0) except *:
    cdef signed short v1
    v1 = len(v0)
    return v1 < (<signed short>16)
cdef object method52(signed short v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9):
    cdef signed char v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef Tuple3 tmp47
    cdef signed char v16
    cdef signed char v17
    cdef signed char v18
    cdef signed char v19
    cdef signed char v20
    cdef signed char v21
    cdef Tuple3 tmp48
    cdef signed char v22
    cdef signed char v23
    cdef signed char v24
    cdef signed char v25
    cdef signed char v26
    cdef signed char v27
    cdef signed char v28
    cdef signed char v29
    cdef signed char v30
    cdef signed char v31
    cdef bint v32
    cdef signed long v35
    cdef bint v33
    cdef bint v36
    cdef signed long v65
    cdef bint v37
    cdef signed long v40
    cdef bint v38
    cdef bint v41
    cdef bint v42
    cdef signed long v45
    cdef bint v43
    cdef bint v46
    cdef bint v47
    cdef signed long v50
    cdef bint v48
    cdef bint v51
    cdef bint v52
    cdef signed long v55
    cdef bint v53
    cdef bint v56
    cdef bint v57
    cdef bint v58
    cdef bint v66
    cdef float v67
    cdef bint v69
    cdef float v70
    cdef signed short v72
    cdef float v73
    tmp47 = method2(v7, v6, v1)
    v10, v11, v12, v13, v14, v15 = tmp47.v0, tmp47.v1, tmp47.v2, tmp47.v3, tmp47.v4, tmp47.v5
    del tmp47
    tmp48 = method2(v3, v2, v1)
    v16, v17, v18, v19, v20, v21 = tmp48.v0, tmp48.v1, tmp48.v2, tmp48.v3, tmp48.v4, tmp48.v5
    del tmp48
    v22 = v10 % (<signed char>13)
    v23 = v11 % (<signed char>13)
    v24 = v12 % (<signed char>13)
    v25 = v13 % (<signed char>13)
    v26 = v14 % (<signed char>13)
    v27 = v16 % (<signed char>13)
    v28 = v17 % (<signed char>13)
    v29 = v18 % (<signed char>13)
    v30 = v19 % (<signed char>13)
    v31 = v20 % (<signed char>13)
    v32 = v15 < v21
    if v32:
        v35 = (<signed long>-1)
    else:
        v33 = v15 > v21
        if v33:
            v35 = (<signed long>1)
        else:
            v35 = (<signed long>0)
    v36 = v35 == (<signed long>0)
    if v36:
        v37 = v22 < v27
        if v37:
            v40 = (<signed long>-1)
        else:
            v38 = v22 > v27
            if v38:
                v40 = (<signed long>1)
            else:
                v40 = (<signed long>0)
        v41 = v40 == (<signed long>0)
        if v41:
            v42 = v23 < v28
            if v42:
                v45 = (<signed long>-1)
            else:
                v43 = v23 > v28
                if v43:
                    v45 = (<signed long>1)
                else:
                    v45 = (<signed long>0)
            v46 = v45 == (<signed long>0)
            if v46:
                v47 = v24 < v29
                if v47:
                    v50 = (<signed long>-1)
                else:
                    v48 = v24 > v29
                    if v48:
                        v50 = (<signed long>1)
                    else:
                        v50 = (<signed long>0)
                v51 = v50 == (<signed long>0)
                if v51:
                    v52 = v25 < v30
                    if v52:
                        v55 = (<signed long>-1)
                    else:
                        v53 = v25 > v30
                        if v53:
                            v55 = (<signed long>1)
                        else:
                            v55 = (<signed long>0)
                    v56 = v55 == (<signed long>0)
                    if v56:
                        v57 = v26 < v31
                        if v57:
                            v65 = (<signed long>-1)
                        else:
                            v58 = v26 > v31
                            if v58:
                                v65 = (<signed long>1)
                            else:
                                v65 = (<signed long>0)
                    else:
                        v65 = v55
                else:
                    v65 = v50
            else:
                v65 = v45
        else:
            v65 = v40
    else:
        v65 = v35
    v66 = v65 == (<signed long>0)
    if v66:
        v67 = <float>(<signed short>0)
        return Closure12(v6, v7, v8, v9, v2, v3, v4, v5, v1, v0, v67)
    else:
        v69 = v65 == (<signed long>1)
        if v69:
            v70 = <float>v9
            return Closure12(v6, v7, v8, v9, v2, v3, v4, v5, v1, v0, v70)
        else:
            v72 = -v9
            v73 = <float>v72
            return Closure12(v6, v7, v8, v9, v2, v3, v4, v5, v1, v0, v73)
cdef object method51(signed short v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9):
    cdef bint v10
    cdef signed char v11
    cdef signed char v12
    cdef unsigned char v13
    cdef signed short v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned char v17
    cdef signed short v18
    v10 = v8 == (<unsigned char>0)
    if v10:
        v11, v12, v13, v14, v15, v16, v17, v18 = v6, v7, v8, v9, v2, v3, v4, v5
    else:
        v11, v12, v13, v14, v15, v16, v17, v18 = v2, v3, v4, v5, v6, v7, v8, v9
    return method52(v0, v1, v15, v16, v17, v18, v11, v12, v13, v14)
cdef object method55(signed short v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8):
    cdef bint v9
    cdef signed char v10
    cdef signed char v11
    cdef unsigned char v12
    cdef signed short v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned char v16
    cdef signed short v17
    v9 = v8 == (<unsigned char>0)
    if v9:
        v10, v11, v12, v13, v14, v15, v16, v17 = v6, v7, v8, v5, v2, v3, v4, v5
    else:
        v10, v11, v12, v13, v14, v15, v16, v17 = v2, v3, v4, v5, v6, v7, v8, v5
    return method52(v0, v1, v14, v15, v16, v17, v10, v11, v12, v13)
cdef UH3 method56(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, US1 v11, float v12, float v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19):
    cdef object v23
    cdef bint v20
    cdef bint v25
    cdef signed short v27
    cdef float v28
    cdef signed short v30
    cdef bint v31
    cdef object v32
    if v11.tag == 0: # Call
        if v0:
            v20 = 0
            v23 = method54(v8, v9, v20, v5, v6, v7, v4, v1, v2, v3, v10)
        else:
            v23 = method55(v8, v10, v1, v2, v3, v4, v5, v6, v7)
        return v23(v12, v13, v14, v15, v16, v17, v18, v19)
    elif v11.tag == 1: # Fold
        v25 = v7 == (<unsigned char>0)
        if v25:
            v27 = -v4
        else:
            v27 = v4
        v28 = <float>v27
        return UH3_1(v12, v13, v14, v15, v16, v17, v18, v19, v5, v6, v7, v4, v1, v2, v3, v4, v10, (<signed short>5), v8, 0, v28)
    elif v11.tag == 2: # RaiseTo
        v30 = (<US1_2>v11).v0
        v31 = 0
        v32 = method50(v8, v9, v31, v5, v6, v7, v30, v1, v2, v3, v4, v10)
        return v32(v12, v13, v14, v15, v16, v17, v18, v19)
cdef object method54(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10):
    cdef bint v11
    cdef bint v13
    cdef bint v14
    cdef bint v15
    cdef signed short v16
    cdef signed short v17
    cdef bint v18
    cdef bint v19
    cdef signed short v20
    v11 = v6 == v0
    if v11:
        return method55(v0, v10, v3, v4, v5, v6, v7, v8, v9)
    else:
        v13 = v6 >= v6
        v14 = v6 < v6
        v15 = v1 >= (<signed short>0)
        if v15:
            v16 = v1
        else:
            v16 = (<signed short>0)
        v17 = v6 + v16
        v18 = v6 < v0
        v19 = v0 < v17
        if v19:
            v20 = v0
        else:
            v20 = v17
        return Closure15(v7, v8, v9, v6, v3, v4, v5, v10, v0, v18, v20, v2, v1)
cdef UH3 method53(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, US1 v12, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
    cdef object v24
    cdef bint v21
    cdef bint v26
    cdef signed short v28
    cdef float v29
    cdef signed short v31
    cdef bint v32
    cdef object v33
    if v12.tag == 0: # Call
        if v0:
            v21 = 0
            v24 = method54(v9, v10, v21, v5, v6, v7, v4, v1, v2, v3, v11)
        else:
            v24 = method55(v9, v11, v1, v2, v3, v4, v5, v6, v7)
        return v24(v13, v14, v15, v16, v17, v18, v19, v20)
    elif v12.tag == 1: # Fold
        v26 = v7 == (<unsigned char>0)
        if v26:
            v28 = -v8
        else:
            v28 = v8
        v29 = <float>v28
        return UH3_1(v13, v14, v15, v16, v17, v18, v19, v20, v5, v6, v7, v8, v1, v2, v3, v4, v11, (<signed short>5), v9, 0, v29)
    elif v12.tag == 2: # RaiseTo
        v31 = (<US1_2>v12).v0
        v32 = 0
        v33 = method50(v9, v10, v32, v5, v6, v7, v31, v1, v2, v3, v4, v11)
        return v33(v13, v14, v15, v16, v17, v18, v19, v20)
cdef object method50(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11):
    cdef bint v12
    cdef bint v14
    cdef bint v15
    cdef bint v16
    cdef signed short v17
    cdef bint v18
    cdef signed short v19
    cdef signed short v20
    cdef bint v21
    cdef signed short v22
    cdef signed short v23
    cdef bint v24
    cdef bint v25
    cdef signed short v26
    v12 = v10 == v0
    if v12:
        return method51(v0, v11, v3, v4, v5, v6, v7, v8, v9, v10)
    else:
        v14 = v10 == v6
        v15 = v14 != 1
        v16 = v10 >= v6
        if v16:
            v17 = v10
        else:
            v17 = v6
        v18 = v10 < v6
        if v18:
            v19 = v10
        else:
            v19 = v6
        v20 = v17 - v19
        v21 = v1 >= v20
        if v21:
            v22 = v1
        else:
            v22 = v20
        v23 = v17 + v22
        v24 = v17 < v0
        v25 = v0 < v23
        if v25:
            v26 = v0
        else:
            v26 = v23
        return Closure13(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v17, v15, v24, v26, v2, v1)
cdef object method49(signed short v0, signed short v1, signed char v2, numpy.ndarray[signed char,ndim=1] v3, signed char v4, signed char v5, unsigned char v6, signed short v7, signed char v8, signed char v9, unsigned char v10, signed short v11):
    cdef bint v12
    cdef signed char v13
    cdef signed char v14
    cdef unsigned char v15
    cdef signed short v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed short v20
    v12 = v10 == (<unsigned char>0)
    if v12:
        v13, v14, v15, v16, v17, v18, v19, v20 = v8, v9, v10, v11, v4, v5, v6, v7
    else:
        v13, v14, v15, v16, v17, v18, v19, v20 = v4, v5, v6, v7, v8, v9, v10, v11
    return Closure11(v2, v0, v1, v3, v17, v18, v19, v20, v13, v14, v15, v16)
cdef object method59(signed short v0, signed short v1, signed char v2, numpy.ndarray[signed char,ndim=1] v3, signed char v4, signed char v5, unsigned char v6, signed short v7, signed char v8, signed char v9, unsigned char v10):
    cdef bint v11
    cdef signed char v12
    cdef signed char v13
    cdef unsigned char v14
    cdef signed short v15
    cdef signed char v16
    cdef signed char v17
    cdef unsigned char v18
    cdef signed short v19
    v11 = v10 == (<unsigned char>0)
    if v11:
        v12, v13, v14, v15, v16, v17, v18, v19 = v8, v9, v10, v7, v4, v5, v6, v7
    else:
        v12, v13, v14, v15, v16, v17, v18, v19 = v4, v5, v6, v7, v8, v9, v10, v7
    return Closure11(v2, v0, v1, v3, v16, v17, v18, v19, v12, v13, v14, v15)
cdef UH3 method60(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, US1 v12, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
    cdef object v24
    cdef bint v21
    cdef bint v26
    cdef signed short v28
    cdef float v29
    cdef signed short v31
    cdef bint v32
    cdef object v33
    if v12.tag == 0: # Call
        if v0:
            v21 = 0
            v24 = method58(v8, v9, v21, v5, v6, v7, v4, v1, v2, v3, v10, v11)
        else:
            v24 = method59(v8, v9, v11, v10, v1, v2, v3, v4, v5, v6, v7)
        return v24(v13, v14, v15, v16, v17, v18, v19, v20)
    elif v12.tag == 1: # Fold
        v26 = v7 == (<unsigned char>0)
        if v26:
            v28 = -v4
        else:
            v28 = v4
        v29 = <float>v28
        return UH3_1(v13, v14, v15, v16, v17, v18, v19, v20, v5, v6, v7, v4, v1, v2, v3, v4, v10, (<signed short>4), v8, 0, v29)
    elif v12.tag == 2: # RaiseTo
        v31 = (<US1_2>v12).v0
        v32 = 0
        v33 = method48(v8, v9, v32, v5, v6, v7, v31, v1, v2, v3, v4, v10, v11)
        return v33(v13, v14, v15, v16, v17, v18, v19, v20)
cdef object method58(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11):
    cdef bint v12
    cdef bint v14
    cdef bint v15
    cdef bint v16
    cdef signed short v17
    cdef signed short v18
    cdef bint v19
    cdef bint v20
    cdef signed short v21
    v12 = v6 == v0
    if v12:
        return method59(v0, v1, v11, v10, v3, v4, v5, v6, v7, v8, v9)
    else:
        v14 = v6 >= v6
        v15 = v6 < v6
        v16 = v1 >= (<signed short>0)
        if v16:
            v17 = v1
        else:
            v17 = (<signed short>0)
        v18 = v6 + v17
        v19 = v6 < v0
        v20 = v0 < v18
        if v20:
            v21 = v0
        else:
            v21 = v18
        return Closure19(v7, v8, v9, v6, v3, v4, v5, v10, v0, v19, v21, v2, v1, v11)
cdef UH3 method57(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, US1 v13, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
    cdef object v25
    cdef bint v22
    cdef bint v27
    cdef signed short v29
    cdef float v30
    cdef signed short v32
    cdef bint v33
    cdef object v34
    if v13.tag == 0: # Call
        if v0:
            v22 = 0
            v25 = method58(v9, v10, v22, v5, v6, v7, v4, v1, v2, v3, v11, v12)
        else:
            v25 = method59(v9, v10, v12, v11, v1, v2, v3, v4, v5, v6, v7)
        return v25(v14, v15, v16, v17, v18, v19, v20, v21)
    elif v13.tag == 1: # Fold
        v27 = v7 == (<unsigned char>0)
        if v27:
            v29 = -v8
        else:
            v29 = v8
        v30 = <float>v29
        return UH3_1(v14, v15, v16, v17, v18, v19, v20, v21, v5, v6, v7, v8, v1, v2, v3, v4, v11, (<signed short>4), v9, 0, v30)
    elif v13.tag == 2: # RaiseTo
        v32 = (<US1_2>v13).v0
        v33 = 0
        v34 = method48(v9, v10, v33, v5, v6, v7, v32, v1, v2, v3, v4, v11, v12)
        return v34(v14, v15, v16, v17, v18, v19, v20, v21)
cdef object method48(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12):
    cdef bint v13
    cdef bint v15
    cdef bint v16
    cdef bint v17
    cdef signed short v18
    cdef bint v19
    cdef signed short v20
    cdef signed short v21
    cdef bint v22
    cdef signed short v23
    cdef signed short v24
    cdef bint v25
    cdef bint v26
    cdef signed short v27
    v13 = v10 == v0
    if v13:
        return method49(v0, v1, v12, v11, v3, v4, v5, v6, v7, v8, v9, v10)
    else:
        v15 = v10 == v6
        v16 = v15 != 1
        v17 = v10 >= v6
        if v17:
            v18 = v10
        else:
            v18 = v6
        v19 = v10 < v6
        if v19:
            v20 = v10
        else:
            v20 = v6
        v21 = v18 - v20
        v22 = v1 >= v21
        if v22:
            v23 = v1
        else:
            v23 = v21
        v24 = v18 + v23
        v25 = v18 < v0
        v26 = v0 < v24
        if v26:
            v27 = v0
        else:
            v27 = v24
        return Closure17(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v18, v16, v25, v27, v2, v1, v12)
cdef object method47(signed short v0, signed short v1, signed char v2, signed char v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, signed short v12):
    cdef bint v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned char v16
    cdef signed short v17
    cdef signed char v18
    cdef signed char v19
    cdef unsigned char v20
    cdef signed short v21
    v13 = v11 == (<unsigned char>0)
    if v13:
        v14, v15, v16, v17, v18, v19, v20, v21 = v9, v10, v11, v12, v5, v6, v7, v8
    else:
        v14, v15, v16, v17, v18, v19, v20, v21 = v5, v6, v7, v8, v9, v10, v11, v12
    return Closure10(v2, v0, v1, v3, v4, v18, v19, v20, v21, v14, v15, v16, v17)
cdef object method63(signed short v0, signed short v1, signed char v2, signed char v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11):
    cdef bint v12
    cdef signed char v13
    cdef signed char v14
    cdef unsigned char v15
    cdef signed short v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed short v20
    v12 = v11 == (<unsigned char>0)
    if v12:
        v13, v14, v15, v16, v17, v18, v19, v20 = v9, v10, v11, v8, v5, v6, v7, v8
    else:
        v13, v14, v15, v16, v17, v18, v19, v20 = v5, v6, v7, v8, v9, v10, v11, v8
    return Closure10(v2, v0, v1, v3, v4, v17, v18, v19, v20, v13, v14, v15, v16)
cdef UH3 method64(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, US1 v13, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
    cdef object v25
    cdef bint v22
    cdef bint v27
    cdef signed short v29
    cdef float v30
    cdef signed short v32
    cdef bint v33
    cdef object v34
    if v13.tag == 0: # Call
        if v0:
            v22 = 0
            v25 = method62(v8, v9, v22, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12)
        else:
            v25 = method63(v8, v9, v11, v12, v10, v1, v2, v3, v4, v5, v6, v7)
        return v25(v14, v15, v16, v17, v18, v19, v20, v21)
    elif v13.tag == 1: # Fold
        v27 = v7 == (<unsigned char>0)
        if v27:
            v29 = -v4
        else:
            v29 = v4
        v30 = <float>v29
        return UH3_1(v14, v15, v16, v17, v18, v19, v20, v21, v5, v6, v7, v4, v1, v2, v3, v4, v10, (<signed short>3), v8, 0, v30)
    elif v13.tag == 2: # RaiseTo
        v32 = (<US1_2>v13).v0
        v33 = 0
        v34 = method46(v8, v9, v33, v5, v6, v7, v32, v1, v2, v3, v4, v10, v11, v12)
        return v34(v14, v15, v16, v17, v18, v19, v20, v21)
cdef object method62(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12):
    cdef bint v13
    cdef bint v15
    cdef bint v16
    cdef bint v17
    cdef signed short v18
    cdef signed short v19
    cdef bint v20
    cdef bint v21
    cdef signed short v22
    v13 = v6 == v0
    if v13:
        return method63(v0, v1, v11, v12, v10, v3, v4, v5, v6, v7, v8, v9)
    else:
        v15 = v6 >= v6
        v16 = v6 < v6
        v17 = v1 >= (<signed short>0)
        if v17:
            v18 = v1
        else:
            v18 = (<signed short>0)
        v19 = v6 + v18
        v20 = v6 < v0
        v21 = v0 < v19
        if v21:
            v22 = v0
        else:
            v22 = v19
        return Closure23(v7, v8, v9, v6, v3, v4, v5, v10, v0, v20, v22, v2, v1, v11, v12)
cdef UH3 method61(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, US1 v14, float v15, float v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22):
    cdef object v26
    cdef bint v23
    cdef bint v28
    cdef signed short v30
    cdef float v31
    cdef signed short v33
    cdef bint v34
    cdef object v35
    if v14.tag == 0: # Call
        if v0:
            v23 = 0
            v26 = method62(v9, v10, v23, v5, v6, v7, v4, v1, v2, v3, v11, v12, v13)
        else:
            v26 = method63(v9, v10, v12, v13, v11, v1, v2, v3, v4, v5, v6, v7)
        return v26(v15, v16, v17, v18, v19, v20, v21, v22)
    elif v14.tag == 1: # Fold
        v28 = v7 == (<unsigned char>0)
        if v28:
            v30 = -v8
        else:
            v30 = v8
        v31 = <float>v30
        return UH3_1(v15, v16, v17, v18, v19, v20, v21, v22, v5, v6, v7, v8, v1, v2, v3, v4, v11, (<signed short>3), v9, 0, v31)
    elif v14.tag == 2: # RaiseTo
        v33 = (<US1_2>v14).v0
        v34 = 0
        v35 = method46(v9, v10, v34, v5, v6, v7, v33, v1, v2, v3, v4, v11, v12, v13)
        return v35(v15, v16, v17, v18, v19, v20, v21, v22)
cdef object method46(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13):
    cdef bint v14
    cdef bint v16
    cdef bint v17
    cdef bint v18
    cdef signed short v19
    cdef bint v20
    cdef signed short v21
    cdef signed short v22
    cdef bint v23
    cdef signed short v24
    cdef signed short v25
    cdef bint v26
    cdef bint v27
    cdef signed short v28
    v14 = v10 == v0
    if v14:
        return method47(v0, v1, v12, v13, v11, v3, v4, v5, v6, v7, v8, v9, v10)
    else:
        v16 = v10 == v6
        v17 = v16 != 1
        v18 = v10 >= v6
        if v18:
            v19 = v10
        else:
            v19 = v6
        v20 = v10 < v6
        if v20:
            v21 = v10
        else:
            v21 = v6
        v22 = v19 - v21
        v23 = v1 >= v22
        if v23:
            v24 = v1
        else:
            v24 = v22
        v25 = v19 + v24
        v26 = v19 < v0
        v27 = v0 < v25
        if v27:
            v28 = v0
        else:
            v28 = v25
        return Closure21(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v19, v17, v26, v28, v2, v1, v12, v13)
cdef object method45(signed short v0, signed short v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, numpy.ndarray[signed char,ndim=1] v7, signed char v8, signed char v9, unsigned char v10, signed short v11, signed char v12, signed char v13, unsigned char v14, signed short v15):
    cdef bint v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed short v20
    cdef signed char v21
    cdef signed char v22
    cdef unsigned char v23
    cdef signed short v24
    v16 = v14 == (<unsigned char>0)
    if v16:
        v17, v18, v19, v20, v21, v22, v23, v24 = v12, v13, v14, v15, v8, v9, v10, v11
    else:
        v17, v18, v19, v20, v21, v22, v23, v24 = v8, v9, v10, v11, v12, v13, v14, v15
    return Closure9(v2, v0, v1, v3, v4, v5, v6, v7, v21, v22, v23, v24, v17, v18, v19, v20)
cdef object method67(signed short v0, signed short v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, numpy.ndarray[signed char,ndim=1] v7, signed char v8, signed char v9, unsigned char v10, signed short v11, signed char v12, signed char v13, unsigned char v14):
    cdef bint v15
    cdef signed char v16
    cdef signed char v17
    cdef unsigned char v18
    cdef signed short v19
    cdef signed char v20
    cdef signed char v21
    cdef unsigned char v22
    cdef signed short v23
    v15 = v14 == (<unsigned char>0)
    if v15:
        v16, v17, v18, v19, v20, v21, v22, v23 = v12, v13, v14, v11, v8, v9, v10, v11
    else:
        v16, v17, v18, v19, v20, v21, v22, v23 = v8, v9, v10, v11, v12, v13, v14, v11
    return Closure9(v2, v0, v1, v3, v4, v5, v6, v7, v20, v21, v22, v23, v16, v17, v18, v19)
cdef UH3 method68(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15, US1 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
    cdef object v28
    cdef bint v25
    cdef bint v30
    cdef signed short v32
    cdef float v33
    cdef signed short v35
    cdef bint v36
    cdef object v37
    if v16.tag == 0: # Call
        if v0:
            v25 = 0
            v28 = method66(v8, v9, v25, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14, v15)
        else:
            v28 = method67(v8, v9, v11, v12, v13, v14, v15, v10, v1, v2, v3, v4, v5, v6, v7)
        return v28(v17, v18, v19, v20, v21, v22, v23, v24)
    elif v16.tag == 1: # Fold
        v30 = v7 == (<unsigned char>0)
        if v30:
            v32 = -v4
        else:
            v32 = v4
        v33 = <float>v32
        return UH3_1(v17, v18, v19, v20, v21, v22, v23, v24, v5, v6, v7, v4, v1, v2, v3, v4, v10, (<signed short>0), v8, 0, v33)
    elif v16.tag == 2: # RaiseTo
        v35 = (<US1_2>v16).v0
        v36 = 0
        v37 = method44(v8, v9, v36, v5, v6, v7, v35, v1, v2, v3, v4, v10, v11, v12, v13, v14, v15)
        return v37(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method66(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15):
    cdef bint v16
    cdef bint v18
    cdef bint v19
    cdef bint v20
    cdef signed short v21
    cdef signed short v22
    cdef bint v23
    cdef bint v24
    cdef signed short v25
    v16 = v6 == v0
    if v16:
        return method67(v0, v1, v11, v12, v13, v14, v15, v10, v3, v4, v5, v6, v7, v8, v9)
    else:
        v18 = v6 >= v6
        v19 = v6 < v6
        v20 = v1 >= (<signed short>0)
        if v20:
            v21 = v1
        else:
            v21 = (<signed short>0)
        v22 = v6 + v21
        v23 = v6 < v0
        v24 = v0 < v22
        if v24:
            v25 = v0
        else:
            v25 = v22
        return Closure27(v7, v8, v9, v6, v3, v4, v5, v10, v0, v23, v25, v2, v1, v11, v12, v13, v14, v15)
cdef UH3 method65(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16, US1 v17, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
    cdef object v29
    cdef bint v26
    cdef bint v31
    cdef signed short v33
    cdef float v34
    cdef signed short v36
    cdef bint v37
    cdef object v38
    if v17.tag == 0: # Call
        if v0:
            v26 = 0
            v29 = method66(v9, v10, v26, v5, v6, v7, v4, v1, v2, v3, v11, v12, v13, v14, v15, v16)
        else:
            v29 = method67(v9, v10, v12, v13, v14, v15, v16, v11, v1, v2, v3, v4, v5, v6, v7)
        return v29(v18, v19, v20, v21, v22, v23, v24, v25)
    elif v17.tag == 1: # Fold
        v31 = v7 == (<unsigned char>0)
        if v31:
            v33 = -v8
        else:
            v33 = v8
        v34 = <float>v33
        return UH3_1(v18, v19, v20, v21, v22, v23, v24, v25, v5, v6, v7, v8, v1, v2, v3, v4, v11, (<signed short>0), v9, 0, v34)
    elif v17.tag == 2: # RaiseTo
        v36 = (<US1_2>v17).v0
        v37 = 0
        v38 = method44(v9, v10, v37, v5, v6, v7, v36, v1, v2, v3, v4, v11, v12, v13, v14, v15, v16)
        return v38(v18, v19, v20, v21, v22, v23, v24, v25)
cdef object method44(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16):
    cdef bint v17
    cdef bint v19
    cdef bint v20
    cdef bint v21
    cdef signed short v22
    cdef bint v23
    cdef signed short v24
    cdef signed short v25
    cdef bint v26
    cdef signed short v27
    cdef signed short v28
    cdef bint v29
    cdef bint v30
    cdef signed short v31
    v17 = v10 == v0
    if v17:
        return method45(v0, v1, v12, v13, v14, v15, v16, v11, v3, v4, v5, v6, v7, v8, v9, v10)
    else:
        v19 = v10 == v6
        v20 = v19 != 1
        v21 = v10 >= v6
        if v21:
            v22 = v10
        else:
            v22 = v6
        v23 = v10 < v6
        if v23:
            v24 = v10
        else:
            v24 = v6
        v25 = v22 - v24
        v26 = v1 >= v25
        if v26:
            v27 = v1
        else:
            v27 = v25
        v28 = v22 + v27
        v29 = v22 < v0
        v30 = v0 < v28
        if v30:
            v31 = v0
        else:
            v31 = v28
        return Closure25(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v22, v20, v29, v31, v2, v1, v12, v13, v14, v15, v16)
cdef UH3 method72(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, US1 v11, float v12, float v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19):
    cdef object v23
    cdef bint v20
    cdef bint v25
    cdef signed short v27
    cdef float v28
    cdef signed short v30
    cdef bint v31
    cdef object v32
    if v11.tag == 0: # Call
        if v0:
            v20 = 0
            v23 = method71(v8, v9, v20, v5, v6, v7, v4, v1, v2, v3, v10)
        else:
            v23 = method55(v8, v10, v1, v2, v3, v4, v5, v6, v7)
        return v23(v12, v13, v14, v15, v16, v17, v18, v19)
    elif v11.tag == 1: # Fold
        v25 = v7 == (<unsigned char>0)
        if v25:
            v27 = -v4
        else:
            v27 = v4
        v28 = <float>v27
        return UH3_1(v12, v13, v14, v15, v16, v17, v18, v19, v5, v6, v7, v4, v1, v2, v3, v4, v10, (<signed short>3), v8, 0, v28)
    elif v11.tag == 2: # RaiseTo
        v30 = (<US1_2>v11).v0
        v31 = 0
        v32 = method69(v8, v9, v31, v5, v6, v7, v30, v1, v2, v3, v4, v10)
        return v32(v12, v13, v14, v15, v16, v17, v18, v19)
cdef object method71(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10):
    cdef bint v11
    cdef bint v13
    cdef bint v14
    cdef bint v15
    cdef signed short v16
    cdef signed short v17
    cdef bint v18
    cdef bint v19
    cdef signed short v20
    v11 = v6 == v0
    if v11:
        return method55(v0, v10, v3, v4, v5, v6, v7, v8, v9)
    else:
        v13 = v6 >= v6
        v14 = v6 < v6
        v15 = v1 >= (<signed short>0)
        if v15:
            v16 = v1
        else:
            v16 = (<signed short>0)
        v17 = v6 + v16
        v18 = v6 < v0
        v19 = v0 < v17
        if v19:
            v20 = v0
        else:
            v20 = v17
        return Closure32(v7, v8, v9, v6, v3, v4, v5, v10, v0, v18, v20, v2, v1)
cdef UH3 method70(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, US1 v12, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
    cdef object v24
    cdef bint v21
    cdef bint v26
    cdef signed short v28
    cdef float v29
    cdef signed short v31
    cdef bint v32
    cdef object v33
    if v12.tag == 0: # Call
        if v0:
            v21 = 0
            v24 = method71(v9, v10, v21, v5, v6, v7, v4, v1, v2, v3, v11)
        else:
            v24 = method55(v9, v11, v1, v2, v3, v4, v5, v6, v7)
        return v24(v13, v14, v15, v16, v17, v18, v19, v20)
    elif v12.tag == 1: # Fold
        v26 = v7 == (<unsigned char>0)
        if v26:
            v28 = -v8
        else:
            v28 = v8
        v29 = <float>v28
        return UH3_1(v13, v14, v15, v16, v17, v18, v19, v20, v5, v6, v7, v8, v1, v2, v3, v4, v11, (<signed short>3), v9, 0, v29)
    elif v12.tag == 2: # RaiseTo
        v31 = (<US1_2>v12).v0
        v32 = 0
        v33 = method69(v9, v10, v32, v5, v6, v7, v31, v1, v2, v3, v4, v11)
        return v33(v13, v14, v15, v16, v17, v18, v19, v20)
cdef object method69(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11):
    cdef bint v12
    cdef bint v14
    cdef bint v15
    cdef bint v16
    cdef signed short v17
    cdef bint v18
    cdef signed short v19
    cdef signed short v20
    cdef bint v21
    cdef signed short v22
    cdef signed short v23
    cdef bint v24
    cdef bint v25
    cdef signed short v26
    v12 = v10 == v0
    if v12:
        return method51(v0, v11, v3, v4, v5, v6, v7, v8, v9, v10)
    else:
        v14 = v10 == v6
        v15 = v14 != 1
        v16 = v10 >= v6
        if v16:
            v17 = v10
        else:
            v17 = v6
        v18 = v10 < v6
        if v18:
            v19 = v10
        else:
            v19 = v6
        v20 = v17 - v19
        v21 = v1 >= v20
        if v21:
            v22 = v1
        else:
            v22 = v20
        v23 = v17 + v22
        v24 = v17 < v0
        v25 = v0 < v23
        if v25:
            v26 = v0
        else:
            v26 = v23
        return Closure30(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v17, v15, v24, v26, v2, v1)
cdef UH3 method43(unsigned char v0, signed short v1, signed short v2, signed short v3, float v4, float v5, UH0 v6, float v7, float v8, UH0 v9, float v10, float v11):
    cdef numpy.ndarray[signed char,ndim=1] v12
    cdef bint v13
    cdef signed short v14
    cdef signed char v15
    cdef signed short v16
    cdef unsigned long long tmp38
    cdef float v17
    cdef float v18
    cdef float v19
    cdef float v20
    cdef float v21
    cdef numpy.ndarray[signed char,ndim=1] v22
    cdef signed char v23
    cdef signed short v24
    cdef unsigned long long tmp39
    cdef float v25
    cdef float v26
    cdef float v27
    cdef float v28
    cdef float v29
    cdef numpy.ndarray[signed char,ndim=1] v30
    cdef bint v31
    cdef signed short v32
    cdef signed char v33
    cdef signed short v34
    cdef unsigned long long tmp40
    cdef float v35
    cdef float v36
    cdef float v37
    cdef float v38
    cdef float v39
    cdef numpy.ndarray[signed char,ndim=1] v40
    cdef signed char v41
    cdef signed short v42
    cdef unsigned long long tmp41
    cdef float v43
    cdef float v44
    cdef float v45
    cdef float v46
    cdef float v47
    cdef numpy.ndarray[signed char,ndim=1] v48
    cdef signed char v49
    cdef signed short v50
    cdef unsigned long long tmp42
    cdef float v51
    cdef float v52
    cdef float v53
    cdef float v54
    cdef float v55
    cdef numpy.ndarray[signed char,ndim=1] v56
    cdef signed char v57
    cdef signed short v58
    cdef unsigned long long tmp43
    cdef float v59
    cdef float v60
    cdef float v61
    cdef float v62
    cdef float v63
    cdef numpy.ndarray[signed char,ndim=1] v64
    cdef signed char v65
    cdef signed short v66
    cdef unsigned long long tmp44
    cdef float v67
    cdef float v68
    cdef float v69
    cdef float v70
    cdef float v71
    cdef numpy.ndarray[signed char,ndim=1] v72
    cdef signed char v73
    cdef signed short v74
    cdef unsigned long long tmp45
    cdef float v75
    cdef float v76
    cdef float v77
    cdef float v78
    cdef float v79
    cdef numpy.ndarray[signed char,ndim=1] v80
    cdef signed char v81
    cdef signed short v82
    cdef unsigned long long tmp46
    cdef float v83
    cdef float v84
    cdef float v85
    cdef float v86
    cdef float v87
    cdef numpy.ndarray[signed char,ndim=1] v88
    cdef bint v89
    cdef object v104
    cdef numpy.ndarray[signed char,ndim=1] v90
    cdef bint v91
    cdef unsigned char v92
    cdef unsigned char v93
    cdef bint v95
    cdef numpy.ndarray[signed char,ndim=1] v96
    cdef bint v98
    cdef numpy.ndarray[signed char,ndim=1] v99
    cdef US0 v105
    cdef US0 v106
    cdef UH0 v107
    cdef UH0 v108
    cdef US0 v109
    cdef US0 v110
    cdef UH0 v111
    cdef UH0 v112
    v12 = numpy.arange(0,52,dtype=numpy.int8)
    numpy.random.shuffle(v12)
    v13 = v1 < v3
    if v13:
        v14 = v1
    else:
        v14 = v3
    v15 = v12[(<signed short>0)]
    tmp38 = len(v12)
    if <signed short>tmp38 != tmp38: raise Exception("The conversion to signed short failed.")
    v16 = <signed short>tmp38
    v17 = <float>v16
    v18 = (<float>1) / v17
    v19 = libc.math.log(v18)
    v20 = v5 + v19
    v21 = v4 + v19
    v22 = v12[1:]
    del v12
    v23 = v22[(<signed short>0)]
    tmp39 = len(v22)
    if <signed short>tmp39 != tmp39: raise Exception("The conversion to signed short failed.")
    v24 = <signed short>tmp39
    v25 = <float>v24
    v26 = (<float>1) / v25
    v27 = libc.math.log(v26)
    v28 = v20 + v27
    v29 = v21 + v27
    v30 = v22[1:]
    del v22
    v31 = v2 < v3
    if v31:
        v32 = v2
    else:
        v32 = v3
    v33 = v30[(<signed short>0)]
    tmp40 = len(v30)
    if <signed short>tmp40 != tmp40: raise Exception("The conversion to signed short failed.")
    v34 = <signed short>tmp40
    v35 = <float>v34
    v36 = (<float>1) / v35
    v37 = libc.math.log(v36)
    v38 = v28 + v37
    v39 = v29 + v37
    v40 = v30[1:]
    del v30
    v41 = v40[(<signed short>0)]
    tmp41 = len(v40)
    if <signed short>tmp41 != tmp41: raise Exception("The conversion to signed short failed.")
    v42 = <signed short>tmp41
    v43 = <float>v42
    v44 = (<float>1) / v43
    v45 = libc.math.log(v44)
    v46 = v38 + v45
    v47 = v39 + v45
    v48 = v40[1:]
    del v40
    v49 = v48[(<signed short>0)]
    tmp42 = len(v48)
    if <signed short>tmp42 != tmp42: raise Exception("The conversion to signed short failed.")
    v50 = <signed short>tmp42
    v51 = <float>v50
    v52 = (<float>1) / v51
    v53 = libc.math.log(v52)
    v54 = v46 + v53
    v55 = v47 + v53
    v56 = v48[1:]
    del v48
    v57 = v56[(<signed short>0)]
    tmp43 = len(v56)
    if <signed short>tmp43 != tmp43: raise Exception("The conversion to signed short failed.")
    v58 = <signed short>tmp43
    v59 = <float>v58
    v60 = (<float>1) / v59
    v61 = libc.math.log(v60)
    v62 = v54 + v61
    v63 = v55 + v61
    v64 = v56[1:]
    del v56
    v65 = v64[(<signed short>0)]
    tmp44 = len(v64)
    if <signed short>tmp44 != tmp44: raise Exception("The conversion to signed short failed.")
    v66 = <signed short>tmp44
    v67 = <float>v66
    v68 = (<float>1) / v67
    v69 = libc.math.log(v68)
    v70 = v62 + v69
    v71 = v63 + v69
    v72 = v64[1:]
    del v64
    v73 = v72[(<signed short>0)]
    tmp45 = len(v72)
    if <signed short>tmp45 != tmp45: raise Exception("The conversion to signed short failed.")
    v74 = <signed short>tmp45
    v75 = <float>v74
    v76 = (<float>1) / v75
    v77 = libc.math.log(v76)
    v78 = v70 + v77
    v79 = v71 + v77
    v80 = v72[1:]
    del v72
    v81 = v80[(<signed short>0)]
    tmp46 = len(v80)
    if <signed short>tmp46 != tmp46: raise Exception("The conversion to signed short failed.")
    v82 = <signed short>tmp46
    v83 = <float>v82
    v84 = (<float>1) / v83
    v85 = libc.math.log(v84)
    v86 = v78 + v85
    v87 = v79 + v85
    v88 = v80[1:]
    del v80; del v88
    v89 = (<unsigned char>0) == v0
    if v89:
        v90 = numpy.empty(5,dtype=numpy.int8)
        v90[0] = v49; v90[1] = v57; v90[2] = v65; v90[3] = v73; v90[4] = v81
        v91 = 1
        v92 = (<unsigned char>0)
        v93 = (<unsigned char>1)
        v104 = method44(v3, v2, v91, v33, v41, v93, v32, v15, v23, v92, v14, v90, v49, v57, v65, v73, v81)
        del v90
    else:
        v95 = (<unsigned char>1) == v0
        if v95:
            v96 = numpy.empty(3,dtype=numpy.int8)
            v96[0] = v49; v96[1] = v57; v96[2] = v65
            v104 = Closure29(v49, v3, v2, v15, v23, v14, v33, v41, v32, v57, v65, v96)
            del v96
        else:
            v98 = (<unsigned char>2) == v0
            if v98:
                v99 = numpy.empty(5,dtype=numpy.int8)
                v99[0] = v49; v99[1] = v57; v99[2] = v65; v99[3] = v73; v99[4] = v81
                v104 = Closure34(v49, v3, v2, v15, v23, v14, v33, v41, v32, v57, v65, v73, v81, v99)
                del v99
            else:
                raise Exception("Unknown game mode.")
    v105 = US0_0(v23)
    v106 = US0_0(v15)
    v107 = UH0_0(v106, v6)
    del v106
    v108 = UH0_0(v105, v107)
    del v105; del v107
    v109 = US0_0(v41)
    v110 = US0_0(v33)
    v111 = UH0_0(v110, v9)
    del v110
    v112 = UH0_0(v109, v111)
    del v109; del v111
    return v104(v87, v86, v108, v7, v8, v112, v10, v11)
cdef object method73(v0, v1, v2, v3, v4, numpy.ndarray[object,ndim=1] v5):
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef list v10
    cdef list v11
    cdef list v12
    cdef list v13
    cdef list v14
    cdef unsigned long long v15
    cdef Mut0 v16
    cdef unsigned long long v18
    cdef UH3 v19
    cdef float v20
    cdef float v21
    cdef UH0 v22
    cdef float v23
    cdef float v24
    cdef UH0 v25
    cdef float v26
    cdef float v27
    cdef signed char v28
    cdef signed char v29
    cdef unsigned char v30
    cdef signed short v31
    cdef signed char v32
    cdef signed char v33
    cdef unsigned char v34
    cdef signed short v35
    cdef numpy.ndarray[signed char,ndim=1] v36
    cdef signed short v37
    cdef signed short v38
    cdef bint v39
    cdef unsigned char v40
    cdef signed short v41
    cdef bint v42
    cdef bint v43
    cdef signed short v44
    cdef signed short v45
    cdef signed short v46
    cdef object v47
    cdef bint v48
    cdef float v49
    cdef float v50
    cdef float v52
    cdef float v53
    cdef float v55
    cdef float v56
    cdef signed char v57
    cdef signed char v58
    cdef unsigned char v59
    cdef signed short v60
    cdef signed char v61
    cdef signed char v62
    cdef unsigned char v63
    cdef signed short v64
    cdef signed short v66
    cdef signed short v67
    cdef bint v68
    cdef float v69
    cdef unsigned long long v70
    cdef unsigned long long v71
    cdef bint v72
    cdef object v123
    cdef object v124
    cdef numpy.ndarray[object,ndim=1] v73
    cdef object v74
    cdef Tuple2 tmp49
    cdef numpy.ndarray[object,ndim=1] v75
    cdef object v76
    cdef Tuple2 tmp50
    cdef unsigned long long v77
    cdef unsigned long long v78
    cdef bint v79
    cdef bint v80
    cdef numpy.ndarray[object,ndim=1] v81
    cdef Mut0 v82
    cdef unsigned long long v84
    cdef object v85
    cdef float v86
    cdef float v87
    cdef US1 v88
    cdef Tuple1 tmp51
    cdef UH3 v89
    cdef unsigned long long v90
    cdef unsigned long long v91
    cdef unsigned long long v92
    cdef bint v93
    cdef bint v94
    cdef numpy.ndarray[object,ndim=1] v95
    cdef Mut0 v96
    cdef unsigned long long v98
    cdef object v99
    cdef float v100
    cdef float v101
    cdef US1 v102
    cdef Tuple1 tmp52
    cdef UH3 v103
    cdef unsigned long long v104
    cdef unsigned long long v105
    cdef unsigned long long v106
    cdef unsigned long long v107
    cdef numpy.ndarray[object,ndim=1] v108
    cdef Mut0 v109
    cdef unsigned long long v111
    cdef bint v112
    cdef UH3 v116
    cdef unsigned long long v114
    cdef unsigned long long v117
    cdef object v118
    cdef object v119
    cdef object v120
    cdef object v121
    cdef object v122
    cdef object v125
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = [None]*(<unsigned long long>0)
    v11 = [None]*(<unsigned long long>0)
    v12 = [None]*(<unsigned long long>0)
    v13 = [None]*(<unsigned long long>0)
    v14 = [None]*(<unsigned long long>0)
    v15 = len(v5)
    v16 = Mut0((<unsigned long long>0))
    while method0(v15, v16):
        v18 = v16.v0
        v19 = v5[v18]
        if v19.tag == 0: # Action
            v20 = (<UH3_0>v19).v0; v21 = (<UH3_0>v19).v1; v22 = (<UH3_0>v19).v2; v23 = (<UH3_0>v19).v3; v24 = (<UH3_0>v19).v4; v25 = (<UH3_0>v19).v5; v26 = (<UH3_0>v19).v6; v27 = (<UH3_0>v19).v7; v28 = (<UH3_0>v19).v8; v29 = (<UH3_0>v19).v9; v30 = (<UH3_0>v19).v10; v31 = (<UH3_0>v19).v11; v32 = (<UH3_0>v19).v12; v33 = (<UH3_0>v19).v13; v34 = (<UH3_0>v19).v14; v35 = (<UH3_0>v19).v15; v36 = (<UH3_0>v19).v16; v37 = (<UH3_0>v19).v17; v38 = (<UH3_0>v19).v18; v39 = (<UH3_0>v19).v19; v40 = (<UH3_0>v19).v20; v41 = (<UH3_0>v19).v21; v42 = (<UH3_0>v19).v22; v43 = (<UH3_0>v19).v23; v44 = (<UH3_0>v19).v24; v45 = (<UH3_0>v19).v25; v46 = (<UH3_0>v19).v26; v47 = (<UH3_0>v19).v27
            v48 = v40 == (<unsigned char>0)
            if v48:
                v8.append(v18)
                v10.append(Tuple0(v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46))
                v12.append(v47)
            else:
                v9.append(v18)
                v11.append(Tuple0(v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46))
                v13.append(v47)
            del v22; del v25; del v36; del v47
            v14.append(v40)
        elif v19.tag == 1: # Terminal
            v49 = (<UH3_1>v19).v0; v50 = (<UH3_1>v19).v1; v52 = (<UH3_1>v19).v3; v53 = (<UH3_1>v19).v4; v55 = (<UH3_1>v19).v6; v56 = (<UH3_1>v19).v7; v57 = (<UH3_1>v19).v8; v58 = (<UH3_1>v19).v9; v59 = (<UH3_1>v19).v10; v60 = (<UH3_1>v19).v11; v61 = (<UH3_1>v19).v12; v62 = (<UH3_1>v19).v13; v63 = (<UH3_1>v19).v14; v64 = (<UH3_1>v19).v15; v66 = (<UH3_1>v19).v17; v67 = (<UH3_1>v19).v18; v68 = (<UH3_1>v19).v19; v69 = (<UH3_1>v19).v20
            v6.append(v18)
            v7.append(v69)
        del v19
        v70 = v18 + (<unsigned long long>1)
        v16.v0 = v70
    del v16
    v71 = len(v14)
    del v14
    v72 = (<unsigned long long>0) < v71
    if v72:
        tmp49 = v4(v10)
        v73, v74 = tmp49.v0, tmp49.v1
        del tmp49
        tmp50 = v3(v11)
        v75, v76 = tmp50.v0, tmp50.v1
        del tmp50
        v77 = len(v12)
        v78 = len(v73)
        v79 = v77 == v78
        v80 = v79 == 0
        if v80:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v81 = numpy.empty(v77,dtype=object)
        v82 = Mut0((<unsigned long long>0))
        while method0(v77, v82):
            v84 = v82.v0
            v85 = v12[v84]
            tmp51 = v73[v84]
            v86, v87, v88 = tmp51.v0, tmp51.v1, tmp51.v2
            del tmp51
            v89 = v85(v86, v87, v88)
            del v85; del v88
            v81[v84] = v89
            del v89
            v90 = v84 + (<unsigned long long>1)
            v82.v0 = v90
        del v73
        del v82
        v91 = len(v13)
        v92 = len(v75)
        v93 = v91 == v92
        v94 = v93 == 0
        if v94:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v95 = numpy.empty(v91,dtype=object)
        v96 = Mut0((<unsigned long long>0))
        while method0(v91, v96):
            v98 = v96.v0
            v99 = v13[v98]
            tmp52 = v75[v98]
            v100, v101, v102 = tmp52.v0, tmp52.v1, tmp52.v2
            del tmp52
            v103 = v99(v100, v101, v102)
            del v99; del v102
            v95[v98] = v103
            del v103
            v104 = v98 + (<unsigned long long>1)
            v96.v0 = v104
        del v75
        del v96
        v105 = len(v81)
        v106 = len(v95)
        v107 = v105 + v106
        v108 = numpy.empty(v107,dtype=object)
        v109 = Mut0((<unsigned long long>0))
        while method0(v107, v109):
            v111 = v109.v0
            v112 = v111 < v105
            if v112:
                v116 = v81[v111]
            else:
                v114 = v111 - v105
                v116 = v95[v114]
            v108[v111] = v116
            del v116
            v117 = v111 + (<unsigned long long>1)
            v109.v0 = v117
        del v81; del v95
        del v109
        v118 = method73(v0, v1, v2, v3, v4, v108)
        del v108
        v119 = v118[:v78]
        v120 = v74(v119)
        del v74; del v119
        v121 = v118[v78:]
        del v118
        v122 = v76(v121)
        del v76; del v121
        v123, v124 = v120, v122
        del v120; del v122
    else:
        v123, v124 = v0, v0
    del v10; del v11; del v12; del v13
    v125 = v1(v7)
    del v7
    return v2(v8, v123, v9, v124, v6, v125)
cdef numpy.ndarray[float,ndim=1] method74(v0, v1, numpy.ndarray[object,ndim=1] v2):
    cdef list v3
    cdef list v4
    cdef list v5
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef list v10
    cdef unsigned long long v11
    cdef Mut0 v12
    cdef unsigned long long v14
    cdef UH3 v15
    cdef float v16
    cdef float v17
    cdef UH0 v18
    cdef float v19
    cdef float v20
    cdef UH0 v21
    cdef float v22
    cdef float v23
    cdef signed char v24
    cdef signed char v25
    cdef unsigned char v26
    cdef signed short v27
    cdef signed char v28
    cdef signed char v29
    cdef unsigned char v30
    cdef signed short v31
    cdef numpy.ndarray[signed char,ndim=1] v32
    cdef signed short v33
    cdef signed short v34
    cdef bint v35
    cdef unsigned char v36
    cdef signed short v37
    cdef bint v38
    cdef bint v39
    cdef signed short v40
    cdef signed short v41
    cdef signed short v42
    cdef object v43
    cdef bint v44
    cdef float v45
    cdef float v46
    cdef float v48
    cdef float v49
    cdef float v51
    cdef float v52
    cdef signed char v53
    cdef signed char v54
    cdef unsigned char v55
    cdef signed short v56
    cdef signed char v57
    cdef signed char v58
    cdef unsigned char v59
    cdef signed short v60
    cdef signed short v62
    cdef signed short v63
    cdef bint v64
    cdef float v65
    cdef unsigned long long v66
    cdef unsigned long long v67
    cdef bint v68
    cdef list v139
    cdef numpy.ndarray[object,ndim=1] v69
    cdef object v70
    cdef Tuple2 tmp53
    cdef numpy.ndarray[object,ndim=1] v71
    cdef object v72
    cdef Tuple2 tmp54
    cdef unsigned long long v73
    cdef unsigned long long v74
    cdef bint v75
    cdef bint v76
    cdef numpy.ndarray[object,ndim=1] v77
    cdef Mut0 v78
    cdef unsigned long long v80
    cdef object v81
    cdef float v82
    cdef float v83
    cdef US1 v84
    cdef Tuple1 tmp55
    cdef UH3 v85
    cdef unsigned long long v86
    cdef unsigned long long v87
    cdef unsigned long long v88
    cdef bint v89
    cdef bint v90
    cdef numpy.ndarray[object,ndim=1] v91
    cdef Mut0 v92
    cdef unsigned long long v94
    cdef object v95
    cdef float v96
    cdef float v97
    cdef US1 v98
    cdef Tuple1 tmp56
    cdef UH3 v99
    cdef unsigned long long v100
    cdef unsigned long long v101
    cdef unsigned long long v102
    cdef unsigned long long v103
    cdef numpy.ndarray[object,ndim=1] v104
    cdef Mut0 v105
    cdef unsigned long long v107
    cdef bint v108
    cdef UH3 v112
    cdef unsigned long long v110
    cdef unsigned long long v113
    cdef numpy.ndarray[float,ndim=1] v114
    cdef numpy.ndarray[float,ndim=1] v115
    cdef numpy.ndarray[float,ndim=1] v116
    cdef numpy.ndarray[float,ndim=1] v117
    cdef numpy.ndarray[float,ndim=1] v118
    cdef unsigned long long v119
    cdef list v120
    cdef Mut1 v121
    cdef unsigned long long v123
    cdef unsigned long long v124
    cdef unsigned long long v125
    cdef unsigned char v126
    cdef bint v127
    cdef float v132
    cdef unsigned long long v133
    cdef unsigned long long v134
    cdef float v128
    cdef unsigned long long v129
    cdef float v130
    cdef unsigned long long v131
    cdef unsigned long long v135
    cdef unsigned long long v136
    cdef unsigned long long v137
    cdef numpy.ndarray[float,ndim=1] v140
    cdef unsigned long long v141
    cdef unsigned long long v142
    cdef bint v143
    cdef bint v144
    cdef Mut0 v145
    cdef unsigned long long v147
    cdef unsigned long long v148
    cdef float v149
    cdef unsigned long long v150
    cdef unsigned long long v151
    cdef unsigned long long v152
    cdef bint v153
    cdef bint v154
    cdef Mut0 v155
    cdef unsigned long long v157
    cdef unsigned long long v158
    cdef float v159
    cdef unsigned long long v160
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = [None]*(<unsigned long long>0)
    v11 = len(v2)
    v12 = Mut0((<unsigned long long>0))
    while method0(v11, v12):
        v14 = v12.v0
        v15 = v2[v14]
        if v15.tag == 0: # Action
            v16 = (<UH3_0>v15).v0; v17 = (<UH3_0>v15).v1; v18 = (<UH3_0>v15).v2; v19 = (<UH3_0>v15).v3; v20 = (<UH3_0>v15).v4; v21 = (<UH3_0>v15).v5; v22 = (<UH3_0>v15).v6; v23 = (<UH3_0>v15).v7; v24 = (<UH3_0>v15).v8; v25 = (<UH3_0>v15).v9; v26 = (<UH3_0>v15).v10; v27 = (<UH3_0>v15).v11; v28 = (<UH3_0>v15).v12; v29 = (<UH3_0>v15).v13; v30 = (<UH3_0>v15).v14; v31 = (<UH3_0>v15).v15; v32 = (<UH3_0>v15).v16; v33 = (<UH3_0>v15).v17; v34 = (<UH3_0>v15).v18; v35 = (<UH3_0>v15).v19; v36 = (<UH3_0>v15).v20; v37 = (<UH3_0>v15).v21; v38 = (<UH3_0>v15).v22; v39 = (<UH3_0>v15).v23; v40 = (<UH3_0>v15).v24; v41 = (<UH3_0>v15).v25; v42 = (<UH3_0>v15).v26; v43 = (<UH3_0>v15).v27
            v5.append(v14)
            v44 = v36 == (<unsigned char>0)
            if v44:
                v6.append(Tuple0(v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42))
                v8.append(v43)
            else:
                v7.append(Tuple0(v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42))
                v9.append(v43)
            del v18; del v21; del v32; del v43
            v10.append(v36)
        elif v15.tag == 1: # Terminal
            v45 = (<UH3_1>v15).v0; v46 = (<UH3_1>v15).v1; v48 = (<UH3_1>v15).v3; v49 = (<UH3_1>v15).v4; v51 = (<UH3_1>v15).v6; v52 = (<UH3_1>v15).v7; v53 = (<UH3_1>v15).v8; v54 = (<UH3_1>v15).v9; v55 = (<UH3_1>v15).v10; v56 = (<UH3_1>v15).v11; v57 = (<UH3_1>v15).v12; v58 = (<UH3_1>v15).v13; v59 = (<UH3_1>v15).v14; v60 = (<UH3_1>v15).v15; v62 = (<UH3_1>v15).v17; v63 = (<UH3_1>v15).v18; v64 = (<UH3_1>v15).v19; v65 = (<UH3_1>v15).v20
            v3.append(v14)
            v4.append(v65)
        del v15
        v66 = v14 + (<unsigned long long>1)
        v12.v0 = v66
    del v12
    v67 = len(v10)
    v68 = (<unsigned long long>0) < v67
    if v68:
        tmp53 = v1(v6)
        v69, v70 = tmp53.v0, tmp53.v1
        del tmp53
        tmp54 = v0(v7)
        v71, v72 = tmp54.v0, tmp54.v1
        del tmp54
        v73 = len(v8)
        v74 = len(v69)
        v75 = v73 == v74
        v76 = v75 == 0
        if v76:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v77 = numpy.empty(v73,dtype=object)
        v78 = Mut0((<unsigned long long>0))
        while method0(v73, v78):
            v80 = v78.v0
            v81 = v8[v80]
            tmp55 = v69[v80]
            v82, v83, v84 = tmp55.v0, tmp55.v1, tmp55.v2
            del tmp55
            v85 = v81(v82, v83, v84)
            del v81; del v84
            v77[v80] = v85
            del v85
            v86 = v80 + (<unsigned long long>1)
            v78.v0 = v86
        del v69
        del v78
        v87 = len(v9)
        v88 = len(v71)
        v89 = v87 == v88
        v90 = v89 == 0
        if v90:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v91 = numpy.empty(v87,dtype=object)
        v92 = Mut0((<unsigned long long>0))
        while method0(v87, v92):
            v94 = v92.v0
            v95 = v9[v94]
            tmp56 = v71[v94]
            v96, v97, v98 = tmp56.v0, tmp56.v1, tmp56.v2
            del tmp56
            v99 = v95(v96, v97, v98)
            del v95; del v98
            v91[v94] = v99
            del v99
            v100 = v94 + (<unsigned long long>1)
            v92.v0 = v100
        del v71
        del v92
        v101 = len(v77)
        v102 = len(v91)
        v103 = v101 + v102
        v104 = numpy.empty(v103,dtype=object)
        v105 = Mut0((<unsigned long long>0))
        while method0(v103, v105):
            v107 = v105.v0
            v108 = v107 < v101
            if v108:
                v112 = v77[v107]
            else:
                v110 = v107 - v101
                v112 = v91[v110]
            v104[v107] = v112
            del v112
            v113 = v107 + (<unsigned long long>1)
            v105.v0 = v113
        del v77; del v91
        del v105
        v114 = method74(v0, v1, v104)
        del v104
        v115 = v114[:v74]
        v116 = v70(v115)
        del v70; del v115
        v117 = v114[v74:]
        del v114
        v118 = v72(v117)
        del v72; del v117
        v119 = len(v10)
        v120 = [None]*v119
        v121 = Mut1((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method1(v119, v121):
            v123 = v121.v0
            v124, v125 = v121.v1, v121.v2
            v126 = v10[v123]
            v127 = v126 == (<unsigned char>0)
            if v127:
                v128 = v116[v124]
                v129 = v124 + (<unsigned long long>1)
                v132, v133, v134 = v128, v129, v125
            else:
                v130 = v118[v125]
                v131 = v125 + (<unsigned long long>1)
                v132, v133, v134 = v130, v124, v131
            v120[v123] = v132
            v135 = v123 + (<unsigned long long>1)
            v121.v0 = v135
            v121.v1 = v133
            v121.v2 = v134
        del v116; del v118
        v136, v137 = v121.v1, v121.v2
        del v121
        v139 = v120
        del v120
    else:
        v139 = [None]*(<unsigned long long>0)
    del v6; del v7; del v8; del v9; del v10
    v140 = numpy.empty(v11,dtype=numpy.float32)
    v141 = len(v5)
    v142 = len(v139)
    v143 = v141 == v142
    v144 = v143 == 0
    if v144:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v145 = Mut0((<unsigned long long>0))
    while method0(v141, v145):
        v147 = v145.v0
        v148 = v5[v147]
        v149 = v139[v147]
        v140[v148] = v149
        v150 = v147 + (<unsigned long long>1)
        v145.v0 = v150
    del v5; del v139
    del v145
    v151 = len(v3)
    v152 = len(v4)
    v153 = v151 == v152
    v154 = v153 == 0
    if v154:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v155 = Mut0((<unsigned long long>0))
    while method0(v151, v155):
        v157 = v155.v0
        v158 = v3[v157]
        v159 = v4[v157]
        v140[v158] = v159
        v160 = v157 + (<unsigned long long>1)
        v155.v0 = v160
    del v3; del v4
    del v155
    return v140
cdef object method75(v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4):
    cdef list v5
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef unsigned long long v10
    cdef Mut0 v11
    cdef unsigned long long v13
    cdef UH3 v14
    cdef float v15
    cdef float v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef UH0 v20
    cdef float v21
    cdef float v22
    cdef signed char v23
    cdef signed char v24
    cdef unsigned char v25
    cdef signed short v26
    cdef signed char v27
    cdef signed char v28
    cdef unsigned char v29
    cdef signed short v30
    cdef numpy.ndarray[signed char,ndim=1] v31
    cdef signed short v32
    cdef signed short v33
    cdef bint v34
    cdef unsigned char v35
    cdef signed short v36
    cdef bint v37
    cdef bint v38
    cdef signed short v39
    cdef signed short v40
    cdef signed short v41
    cdef object v42
    cdef float v43
    cdef float v44
    cdef float v46
    cdef float v47
    cdef float v49
    cdef float v50
    cdef signed char v51
    cdef signed char v52
    cdef unsigned char v53
    cdef signed short v54
    cdef signed char v55
    cdef signed char v56
    cdef unsigned char v57
    cdef signed short v58
    cdef signed short v60
    cdef signed short v61
    cdef bint v62
    cdef float v63
    cdef unsigned long long v64
    cdef unsigned long long v65
    cdef bint v66
    cdef object v85
    cdef numpy.ndarray[object,ndim=1] v67
    cdef object v68
    cdef Tuple2 tmp57
    cdef unsigned long long v69
    cdef unsigned long long v70
    cdef bint v71
    cdef bint v72
    cdef numpy.ndarray[object,ndim=1] v73
    cdef Mut0 v74
    cdef unsigned long long v76
    cdef object v77
    cdef float v78
    cdef float v79
    cdef US1 v80
    cdef Tuple1 tmp58
    cdef UH3 v81
    cdef unsigned long long v82
    cdef object v83
    cdef object v86
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = len(v4)
    v11 = Mut0((<unsigned long long>0))
    while method0(v10, v11):
        v13 = v11.v0
        v14 = v4[v13]
        if v14.tag == 0: # Action
            v15 = (<UH3_0>v14).v0; v16 = (<UH3_0>v14).v1; v17 = (<UH3_0>v14).v2; v18 = (<UH3_0>v14).v3; v19 = (<UH3_0>v14).v4; v20 = (<UH3_0>v14).v5; v21 = (<UH3_0>v14).v6; v22 = (<UH3_0>v14).v7; v23 = (<UH3_0>v14).v8; v24 = (<UH3_0>v14).v9; v25 = (<UH3_0>v14).v10; v26 = (<UH3_0>v14).v11; v27 = (<UH3_0>v14).v12; v28 = (<UH3_0>v14).v13; v29 = (<UH3_0>v14).v14; v30 = (<UH3_0>v14).v15; v31 = (<UH3_0>v14).v16; v32 = (<UH3_0>v14).v17; v33 = (<UH3_0>v14).v18; v34 = (<UH3_0>v14).v19; v35 = (<UH3_0>v14).v20; v36 = (<UH3_0>v14).v21; v37 = (<UH3_0>v14).v22; v38 = (<UH3_0>v14).v23; v39 = (<UH3_0>v14).v24; v40 = (<UH3_0>v14).v25; v41 = (<UH3_0>v14).v26; v42 = (<UH3_0>v14).v27
            v7.append(v13)
            v8.append(Tuple0(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41))
            del v17; del v20; del v31
            v9.append(v42)
            del v42
        elif v14.tag == 1: # Terminal
            v43 = (<UH3_1>v14).v0; v44 = (<UH3_1>v14).v1; v46 = (<UH3_1>v14).v3; v47 = (<UH3_1>v14).v4; v49 = (<UH3_1>v14).v6; v50 = (<UH3_1>v14).v7; v51 = (<UH3_1>v14).v8; v52 = (<UH3_1>v14).v9; v53 = (<UH3_1>v14).v10; v54 = (<UH3_1>v14).v11; v55 = (<UH3_1>v14).v12; v56 = (<UH3_1>v14).v13; v57 = (<UH3_1>v14).v14; v58 = (<UH3_1>v14).v15; v60 = (<UH3_1>v14).v17; v61 = (<UH3_1>v14).v18; v62 = (<UH3_1>v14).v19; v63 = (<UH3_1>v14).v20
            v5.append(v13)
            v6.append(v63)
        del v14
        v64 = v13 + (<unsigned long long>1)
        v11.v0 = v64
    del v11
    v65 = len(v8)
    v66 = (<unsigned long long>0) < v65
    if v66:
        tmp57 = v3(v8)
        v67, v68 = tmp57.v0, tmp57.v1
        del tmp57
        v69 = len(v9)
        v70 = len(v67)
        v71 = v69 == v70
        v72 = v71 == 0
        if v72:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v73 = numpy.empty(v69,dtype=object)
        v74 = Mut0((<unsigned long long>0))
        while method0(v69, v74):
            v76 = v74.v0
            v77 = v9[v76]
            tmp58 = v67[v76]
            v78, v79, v80 = tmp58.v0, tmp58.v1, tmp58.v2
            del tmp58
            v81 = v77(v78, v79, v80)
            del v77; del v80
            v73[v76] = v81
            del v81
            v82 = v76 + (<unsigned long long>1)
            v74.v0 = v82
        del v67
        del v74
        v83 = method75(v0, v1, v2, v3, v73)
        del v73
        v85 = v68(v83)
        del v68; del v83
    else:
        v85 = v0
    del v8; del v9
    v86 = v1(v6)
    del v6
    return v2(v7, v85, v5, v86)
cdef numpy.ndarray[float,ndim=1] method76(v0, numpy.ndarray[object,ndim=1] v1):
    cdef list v2
    cdef list v3
    cdef list v4
    cdef list v5
    cdef list v6
    cdef unsigned long long v7
    cdef Mut0 v8
    cdef unsigned long long v10
    cdef UH3 v11
    cdef float v12
    cdef float v13
    cdef UH0 v14
    cdef float v15
    cdef float v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef signed char v20
    cdef signed char v21
    cdef unsigned char v22
    cdef signed short v23
    cdef signed char v24
    cdef signed char v25
    cdef unsigned char v26
    cdef signed short v27
    cdef numpy.ndarray[signed char,ndim=1] v28
    cdef signed short v29
    cdef signed short v30
    cdef bint v31
    cdef unsigned char v32
    cdef signed short v33
    cdef bint v34
    cdef bint v35
    cdef signed short v36
    cdef signed short v37
    cdef signed short v38
    cdef object v39
    cdef float v40
    cdef float v41
    cdef float v43
    cdef float v44
    cdef float v46
    cdef float v47
    cdef signed char v48
    cdef signed char v49
    cdef unsigned char v50
    cdef signed short v51
    cdef signed char v52
    cdef signed char v53
    cdef unsigned char v54
    cdef signed short v55
    cdef signed short v57
    cdef signed short v58
    cdef bint v59
    cdef float v60
    cdef unsigned long long v61
    cdef unsigned long long v62
    cdef bint v63
    cdef numpy.ndarray[float,ndim=1] v83
    cdef numpy.ndarray[object,ndim=1] v64
    cdef object v65
    cdef Tuple2 tmp59
    cdef unsigned long long v66
    cdef unsigned long long v67
    cdef bint v68
    cdef bint v69
    cdef numpy.ndarray[object,ndim=1] v70
    cdef Mut0 v71
    cdef unsigned long long v73
    cdef object v74
    cdef float v75
    cdef float v76
    cdef US1 v77
    cdef Tuple1 tmp60
    cdef UH3 v78
    cdef unsigned long long v79
    cdef numpy.ndarray[float,ndim=1] v80
    cdef numpy.ndarray[float,ndim=1] v82
    cdef numpy.ndarray[float,ndim=1] v84
    cdef unsigned long long v85
    cdef unsigned long long v86
    cdef bint v87
    cdef bint v88
    cdef Mut0 v89
    cdef unsigned long long v91
    cdef unsigned long long v92
    cdef float v93
    cdef unsigned long long v94
    cdef unsigned long long v95
    cdef unsigned long long v96
    cdef bint v97
    cdef bint v98
    cdef Mut0 v99
    cdef unsigned long long v101
    cdef unsigned long long v102
    cdef float v103
    cdef unsigned long long v104
    v2 = [None]*(<unsigned long long>0)
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = len(v1)
    v8 = Mut0((<unsigned long long>0))
    while method0(v7, v8):
        v10 = v8.v0
        v11 = v1[v10]
        if v11.tag == 0: # Action
            v12 = (<UH3_0>v11).v0; v13 = (<UH3_0>v11).v1; v14 = (<UH3_0>v11).v2; v15 = (<UH3_0>v11).v3; v16 = (<UH3_0>v11).v4; v17 = (<UH3_0>v11).v5; v18 = (<UH3_0>v11).v6; v19 = (<UH3_0>v11).v7; v20 = (<UH3_0>v11).v8; v21 = (<UH3_0>v11).v9; v22 = (<UH3_0>v11).v10; v23 = (<UH3_0>v11).v11; v24 = (<UH3_0>v11).v12; v25 = (<UH3_0>v11).v13; v26 = (<UH3_0>v11).v14; v27 = (<UH3_0>v11).v15; v28 = (<UH3_0>v11).v16; v29 = (<UH3_0>v11).v17; v30 = (<UH3_0>v11).v18; v31 = (<UH3_0>v11).v19; v32 = (<UH3_0>v11).v20; v33 = (<UH3_0>v11).v21; v34 = (<UH3_0>v11).v22; v35 = (<UH3_0>v11).v23; v36 = (<UH3_0>v11).v24; v37 = (<UH3_0>v11).v25; v38 = (<UH3_0>v11).v26; v39 = (<UH3_0>v11).v27
            v4.append(v10)
            v5.append(Tuple0(v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38))
            del v14; del v17; del v28
            v6.append(v39)
            del v39
        elif v11.tag == 1: # Terminal
            v40 = (<UH3_1>v11).v0; v41 = (<UH3_1>v11).v1; v43 = (<UH3_1>v11).v3; v44 = (<UH3_1>v11).v4; v46 = (<UH3_1>v11).v6; v47 = (<UH3_1>v11).v7; v48 = (<UH3_1>v11).v8; v49 = (<UH3_1>v11).v9; v50 = (<UH3_1>v11).v10; v51 = (<UH3_1>v11).v11; v52 = (<UH3_1>v11).v12; v53 = (<UH3_1>v11).v13; v54 = (<UH3_1>v11).v14; v55 = (<UH3_1>v11).v15; v57 = (<UH3_1>v11).v17; v58 = (<UH3_1>v11).v18; v59 = (<UH3_1>v11).v19; v60 = (<UH3_1>v11).v20
            v2.append(v10)
            v3.append(v60)
        del v11
        v61 = v10 + (<unsigned long long>1)
        v8.v0 = v61
    del v8
    v62 = len(v5)
    v63 = (<unsigned long long>0) < v62
    if v63:
        tmp59 = v0(v5)
        v64, v65 = tmp59.v0, tmp59.v1
        del tmp59
        v66 = len(v6)
        v67 = len(v64)
        v68 = v66 == v67
        v69 = v68 == 0
        if v69:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v70 = numpy.empty(v66,dtype=object)
        v71 = Mut0((<unsigned long long>0))
        while method0(v66, v71):
            v73 = v71.v0
            v74 = v6[v73]
            tmp60 = v64[v73]
            v75, v76, v77 = tmp60.v0, tmp60.v1, tmp60.v2
            del tmp60
            v78 = v74(v75, v76, v77)
            del v74; del v77
            v70[v73] = v78
            del v78
            v79 = v73 + (<unsigned long long>1)
            v71.v0 = v79
        del v64
        del v71
        v80 = method76(v0, v70)
        del v70
        v83 = v65(v80)
        del v65; del v80
    else:
        v82 = numpy.empty((<unsigned long long>0),dtype=numpy.float32)
        v83 = v82
        del v82
    del v5; del v6
    v84 = numpy.empty(v7,dtype=numpy.float32)
    v85 = len(v4)
    v86 = len(v83)
    v87 = v85 == v86
    v88 = v87 == 0
    if v88:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v89 = Mut0((<unsigned long long>0))
    while method0(v85, v89):
        v91 = v89.v0
        v92 = v4[v91]
        v93 = v83[v91]
        v84[v92] = v93
        v94 = v91 + (<unsigned long long>1)
        v89.v0 = v94
    del v4; del v83
    del v89
    v95 = len(v2)
    v96 = len(v3)
    v97 = v95 == v96
    v98 = v97 == 0
    if v98:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v99 = Mut0((<unsigned long long>0))
    while method0(v95, v99):
        v101 = v99.v0
        v102 = v2[v101]
        v103 = v3[v101]
        v84[v102] = v103
        v104 = v101 + (<unsigned long long>1)
        v99.v0 = v104
    del v2; del v3
    del v99
    return v84
cdef UH3 method78(unsigned char v0, v1, UH3 v2):
    cdef float v3
    cdef float v4
    cdef UH0 v5
    cdef float v6
    cdef float v7
    cdef UH0 v8
    cdef float v9
    cdef float v10
    cdef signed char v11
    cdef signed char v12
    cdef unsigned char v13
    cdef signed short v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned char v17
    cdef signed short v18
    cdef numpy.ndarray[signed char,ndim=1] v19
    cdef signed short v20
    cdef signed short v21
    cdef bint v22
    cdef unsigned char v23
    cdef signed short v24
    cdef bint v25
    cdef bint v26
    cdef signed short v27
    cdef signed short v28
    cdef signed short v29
    cdef object v30
    cdef bint v31
    cdef list v32
    cdef numpy.ndarray[object,ndim=1] v33
    cdef object v34
    cdef Tuple2 tmp61
    cdef float v35
    cdef float v36
    cdef US1 v37
    cdef Tuple1 tmp62
    cdef UH3 v38
    cdef float v41
    cdef float v42
    cdef float v44
    cdef float v45
    cdef float v47
    cdef float v48
    cdef signed char v49
    cdef signed char v50
    cdef unsigned char v51
    cdef signed short v52
    cdef signed char v53
    cdef signed char v54
    cdef unsigned char v55
    cdef signed short v56
    cdef signed short v58
    cdef signed short v59
    cdef bint v60
    cdef float v61
    if v2.tag == 0: # Action
        v3 = (<UH3_0>v2).v0; v4 = (<UH3_0>v2).v1; v5 = (<UH3_0>v2).v2; v6 = (<UH3_0>v2).v3; v7 = (<UH3_0>v2).v4; v8 = (<UH3_0>v2).v5; v9 = (<UH3_0>v2).v6; v10 = (<UH3_0>v2).v7; v11 = (<UH3_0>v2).v8; v12 = (<UH3_0>v2).v9; v13 = (<UH3_0>v2).v10; v14 = (<UH3_0>v2).v11; v15 = (<UH3_0>v2).v12; v16 = (<UH3_0>v2).v13; v17 = (<UH3_0>v2).v14; v18 = (<UH3_0>v2).v15; v19 = (<UH3_0>v2).v16; v20 = (<UH3_0>v2).v17; v21 = (<UH3_0>v2).v18; v22 = (<UH3_0>v2).v19; v23 = (<UH3_0>v2).v20; v24 = (<UH3_0>v2).v21; v25 = (<UH3_0>v2).v22; v26 = (<UH3_0>v2).v23; v27 = (<UH3_0>v2).v24; v28 = (<UH3_0>v2).v25; v29 = (<UH3_0>v2).v26; v30 = (<UH3_0>v2).v27
        v31 = v23 == v0
        if v31:
            del v5; del v8; del v19; del v30
            return v2
        else:
            v32 = [None]*(<unsigned long long>1)
            v32[(<unsigned long long>0)] = Tuple0(v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29)
            del v5; del v8; del v19
            tmp61 = v1(v32)
            v33, v34 = tmp61.v0, tmp61.v1
            del tmp61
            del v32; del v34
            tmp62 = v33[(<unsigned long long>0)]
            v35, v36, v37 = tmp62.v0, tmp62.v1, tmp62.v2
            del tmp62
            del v33
            v38 = v30(v35, v36, v37)
            del v30; del v37
            return method78(v0, v1, v38)
    elif v2.tag == 1: # Terminal
        v41 = (<UH3_1>v2).v0; v42 = (<UH3_1>v2).v1; v44 = (<UH3_1>v2).v3; v45 = (<UH3_1>v2).v4; v47 = (<UH3_1>v2).v6; v48 = (<UH3_1>v2).v7; v49 = (<UH3_1>v2).v8; v50 = (<UH3_1>v2).v9; v51 = (<UH3_1>v2).v10; v52 = (<UH3_1>v2).v11; v53 = (<UH3_1>v2).v12; v54 = (<UH3_1>v2).v13; v55 = (<UH3_1>v2).v14; v56 = (<UH3_1>v2).v15; v58 = (<UH3_1>v2).v17; v59 = (<UH3_1>v2).v18; v60 = (<UH3_1>v2).v19; v61 = (<UH3_1>v2).v20
        return v2
cdef UH0 method80(UH0 v0, UH0 v1):
    cdef US0 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # Cons
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method80(v3, v4)
    elif v0.tag == 1: # Nil
        return v1
cdef str method82(signed char v0):
    cdef signed char v1
    cdef signed char v2
    cdef bint v3
    cdef str v13
    cdef bint v4
    cdef bint v5
    cdef bint v6
    cdef bint v7
    cdef bint v14
    cdef str v19
    cdef bint v15
    cdef bint v16
    v1 = v0 // (<signed char>13)
    v2 = v0 % (<signed char>13)
    v3 = (<signed char>12) == v2
    if v3:
        v13 = 'A'
    else:
        v4 = (<signed char>11) == v2
        if v4:
            v13 = 'K'
        else:
            v5 = (<signed char>10) == v2
            if v5:
                v13 = 'Q'
            else:
                v6 = (<signed char>9) == v2
                if v6:
                    v13 = 'J'
                else:
                    v7 = (<signed char>8) == v2
                    if v7:
                        v13 = 'T'
                    else:
                        v13 = str(2 + v2)
    v14 = (<signed char>0) == v1
    if v14:
        v19 = "[color=ff0000]"
    else:
        v15 = (<signed char>1) == v1
        if v15:
            v19 = "[color=00ff00]"
        else:
            v16 = (<signed char>2) == v1
            if v16:
                v19 = "[color=0000ff]"
            else:
                v19 = "[color=ffff00]"
    return f'{v19}{v13}[/color]'
cdef void method83(list v0, list v1) except *:
    cdef unsigned long long v2
    cdef bint v3
    cdef str v4
    v2 = len(v1)
    v3 = (<unsigned long long>0) < v2
    if v3:
        v4 = "".join(v1)
        v0.append(v4)
        del v4
        v1.clear()
    else:
        pass
cdef void method81(list v0, list v1, bint v2, UH0 v3) except *:
    cdef US0 v4
    cdef UH0 v5
    cdef signed char v6
    cdef str v7
    cdef bint v8
    cdef US1 v9
    cdef str v10
    cdef str v15
    cdef signed short v13
    cdef bint v16
    if v3.tag == 0: # Cons
        v4 = (<UH0_0>v3).v0; v5 = (<UH0_0>v3).v1
        if v4.tag == 0: # C1of2
            v6 = (<US0_0>v4).v0
            v7 = method82(v6)
            v1.append(v7)
            del v7
            v8 = 1
            method81(v0, v1, v8, v5)
        elif v4.tag == 1: # C2of2
            v9 = (<US0_1>v4).v0
            method83(v0, v1)
            if v2:
                v10 = "Player One"
            else:
                v10 = "Player Two"
            if v9.tag == 0: # Call
                v15 = f'{v10} calls.'
            elif v9.tag == 1: # Fold
                v15 = f'{v10} folds.'
            elif v9.tag == 2: # RaiseTo
                v13 = (<US1_2>v9).v0
                v15 = f'{v10} raises to {v13}.'
            del v9; del v10
            v0.append(v15)
            del v15
            v16 = v2 == 0
            method81(v0, v1, v16, v5)
    elif v3.tag == 1: # Nil
        method83(v0, v1)
cdef list method79(UH0 v0):
    cdef list v1
    cdef list v2
    cdef bint v3
    cdef UH0 v4
    cdef UH0 v5
    v1 = [None]*(<unsigned long long>0)
    v2 = [None]*(<unsigned long long>0)
    v3 = 1
    v4 = UH0_1()
    v5 = method80(v0, v4)
    del v4
    method81(v1, v2, v3, v5)
    del v2; del v5
    return v1
cdef str method84(signed char v0, signed char v1):
    cdef str v2
    cdef str v3
    v2 = method82(v1)
    v3 = method82(v0)
    return f'{v2}{v3}'
cdef str method87(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5):
    cdef bint v6
    cdef bint v7
    cdef bint v8
    cdef bint v9
    cdef bint v10
    cdef bint v11
    cdef bint v12
    cdef bint v13
    cdef bint v14
    v6 = (<signed char>0) == v5
    if v6:
        return "high card"
    else:
        v7 = (<signed char>1) == v5
        if v7:
            return "pair"
        else:
            v8 = (<signed char>2) == v5
            if v8:
                return "two pair"
            else:
                v9 = (<signed char>3) == v5
                if v9:
                    return "triple"
                else:
                    v10 = (<signed char>4) == v5
                    if v10:
                        return "straight"
                    else:
                        v11 = (<signed char>5) == v5
                        if v11:
                            return "flush"
                        else:
                            v12 = (<signed char>6) == v5
                            if v12:
                                return "full house"
                            else:
                                v13 = (<signed char>7) == v5
                                if v13:
                                    return "four of a kind"
                                else:
                                    v14 = (<signed char>8) == v5
                                    if v14:
                                        return "straight flush"
                                    else:
                                        raise Exception("Invalid card score.")
cdef str method88(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4):
    cdef str v5
    cdef str v6
    cdef str v7
    cdef str v8
    cdef str v9
    v5 = method82(v4)
    v6 = method82(v3)
    v7 = method82(v2)
    v8 = method82(v1)
    v9 = method82(v0)
    return f'{v5}{v6}{v7}{v8}{v9}'
cdef void method86(numpy.ndarray[signed char,ndim=1] v0, list v1, unsigned char v2, signed char v3, signed char v4) except *:
    cdef bint v5
    cdef str v6
    cdef signed char v7
    cdef signed char v8
    cdef signed char v9
    cdef signed char v10
    cdef signed char v11
    cdef signed char v12
    cdef Tuple3 tmp64
    cdef str v13
    cdef str v14
    cdef str v15
    v5 = v2 == (<unsigned char>0)
    if v5:
        v6 = "Player One"
    else:
        v6 = "Player Two"
    tmp64 = method2(v4, v3, v0)
    v7, v8, v9, v10, v11, v12 = tmp64.v0, tmp64.v1, tmp64.v2, tmp64.v3, tmp64.v4, tmp64.v5
    del tmp64
    v13 = method87(v7, v8, v9, v10, v11, v12)
    v14 = method88(v11, v10, v9, v8, v7)
    v15 = f'{v6} shows {v13} {v14}'
    del v6; del v13; del v14
    v1.append(v15)
cdef void method89(float v0, list v1, unsigned char v2) except *:
    cdef bint v3
    cdef str v4
    cdef float v6
    cdef float v7
    cdef bint v8
    cdef float v9
    cdef bint v10
    cdef str v16
    cdef bint v12
    v3 = v2 == (<unsigned char>0)
    if v3:
        v4 = "Player One"
    else:
        v4 = "Player Two"
    if v3:
        v6 = v0
    else:
        v6 = -v0
    v7 = -v6
    v8 = v6 >= v7
    if v8:
        v9 = v6
    else:
        v9 = v7
    v10 = v6 < (<float>0)
    if v10:
        v16 = f'{v4} losses {v9} chips.'
    else:
        v12 = v6 == (<float>0)
        if v12:
            v16 = f'{v4} ties.'
        else:
            v16 = f'{v4} gains {v9} chips.'
    del v4
    v1.append(v16)
cdef str method85(bint v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9, float v10, list v11):
    cdef bint v12
    cdef signed char v13
    cdef signed char v14
    cdef unsigned char v15
    cdef signed short v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed short v20
    cdef unsigned char v21
    cdef unsigned char v22
    cdef unsigned char v23
    cdef unsigned char v24
    v12 = v8 == (<unsigned char>0)
    if v12:
        v13, v14, v15, v16, v17, v18, v19, v20 = v6, v7, v8, v9, v2, v3, v4, v5
    else:
        v13, v14, v15, v16, v17, v18, v19, v20 = v2, v3, v4, v5, v6, v7, v8, v9
    if v0:
        v21 = (<unsigned char>0)
        method86(v1, v11, v21, v13, v14)
        v22 = (<unsigned char>1)
        method86(v1, v11, v22, v17, v18)
    else:
        pass
    v23 = (<unsigned char>0)
    method89(v10, v11, v23)
    v24 = (<unsigned char>1)
    method89(v10, v11, v24)
    return "\n".join(v11)
cdef void method77(v0, v1, unsigned char v2, signed short v3, UH3 v4) except *:
    cdef UH3 v5
    cdef float v6
    cdef float v7
    cdef UH0 v8
    cdef float v9
    cdef float v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned char v16
    cdef signed short v17
    cdef signed char v18
    cdef signed char v19
    cdef unsigned char v20
    cdef signed short v21
    cdef numpy.ndarray[signed char,ndim=1] v22
    cdef signed short v23
    cdef signed short v24
    cdef bint v25
    cdef unsigned char v26
    cdef signed short v27
    cdef bint v28
    cdef bint v29
    cdef signed short v30
    cdef signed short v31
    cdef signed short v32
    cdef object v33
    cdef bint v34
    cdef UH0 v35
    cdef list v36
    cdef str v37
    cdef object v40
    cdef object v43
    cdef object v44
    cdef object v45
    cdef bint v46
    cdef signed char v47
    cdef signed char v48
    cdef unsigned char v49
    cdef signed short v50
    cdef signed char v51
    cdef signed char v52
    cdef unsigned char v53
    cdef signed short v54
    cdef signed short v55
    cdef str v56
    cdef signed short v57
    cdef str v58
    cdef signed short v59
    cdef unsigned long long tmp63
    cdef list v60
    cdef Mut5 v61
    cdef signed short v63
    cdef signed char v64
    cdef str v65
    cdef signed short v66
    cdef str v67
    cdef object v68
    cdef object v69
    cdef float v70
    cdef float v71
    cdef UH0 v72
    cdef float v73
    cdef float v74
    cdef UH0 v75
    cdef float v76
    cdef float v77
    cdef signed char v78
    cdef signed char v79
    cdef unsigned char v80
    cdef signed short v81
    cdef signed char v82
    cdef signed char v83
    cdef unsigned char v84
    cdef signed short v85
    cdef numpy.ndarray[signed char,ndim=1] v86
    cdef signed short v87
    cdef signed short v88
    cdef bint v89
    cdef float v90
    cdef bint v91
    cdef UH0 v92
    cdef list v93
    cdef str v94
    cdef object v95
    cdef object v96
    cdef object v97
    cdef object v98
    cdef float v100
    cdef signed short v101
    cdef bint v102
    cdef signed char v103
    cdef signed char v104
    cdef unsigned char v105
    cdef signed short v106
    cdef signed char v107
    cdef signed char v108
    cdef unsigned char v109
    cdef signed short v110
    cdef signed short v111
    cdef str v112
    cdef signed short v113
    cdef str v114
    cdef signed short v115
    cdef unsigned long long tmp65
    cdef list v116
    cdef Mut5 v117
    cdef signed short v119
    cdef signed char v120
    cdef str v121
    cdef signed short v122
    cdef str v123
    cdef object v124
    cdef object v125
    v5 = method78(v2, v0, v4)
    if v5.tag == 0: # Action
        v6 = (<UH3_0>v5).v0; v7 = (<UH3_0>v5).v1; v8 = (<UH3_0>v5).v2; v9 = (<UH3_0>v5).v3; v10 = (<UH3_0>v5).v4; v11 = (<UH3_0>v5).v5; v12 = (<UH3_0>v5).v6; v13 = (<UH3_0>v5).v7; v14 = (<UH3_0>v5).v8; v15 = (<UH3_0>v5).v9; v16 = (<UH3_0>v5).v10; v17 = (<UH3_0>v5).v11; v18 = (<UH3_0>v5).v12; v19 = (<UH3_0>v5).v13; v20 = (<UH3_0>v5).v14; v21 = (<UH3_0>v5).v15; v22 = (<UH3_0>v5).v16; v23 = (<UH3_0>v5).v17; v24 = (<UH3_0>v5).v18; v25 = (<UH3_0>v5).v19; v26 = (<UH3_0>v5).v20; v27 = (<UH3_0>v5).v21; v28 = (<UH3_0>v5).v22; v29 = (<UH3_0>v5).v23; v30 = (<UH3_0>v5).v24; v31 = (<UH3_0>v5).v25; v32 = (<UH3_0>v5).v26; v33 = (<UH3_0>v5).v27
        v34 = v2 == (<unsigned char>0)
        if v34:
            v35 = v8
        else:
            v35 = v11
        del v8; del v11
        v36 = method79(v35)
        del v35
        v37 = "\n".join(v36)
        del v36
        if v28:
            v40 = Closure42(v0, v1, v2, v3, v33)
        else:
            v40 = False
        if v29:
            v43 = Closure43(v0, v1, v2, v3, v33)
        else:
            v43 = False
        v44 = Closure44(v0, v1, v2, v3, v33)
        del v33
        v45 = {'call': v44, 'fold': v40, 'raise_max': v30, 'raise_min': v31, 'raise_to': v43}
        del v40; del v43; del v44
        v46 = v2 == v16
        if v46:
            v47, v48, v49, v50, v51, v52, v53, v54 = v14, v15, v16, v17, v18, v19, v20, v21
        else:
            v47, v48, v49, v50, v51, v52, v53, v54 = v18, v19, v20, v21, v14, v15, v16, v17
        v55 = v3 - v50
        v56 = method84(v48, v47)
        v57 = v3 - v54
        v58 = method84(v52, v51)
        tmp63 = len(v22)
        if <signed short>tmp63 != tmp63: raise Exception("The conversion to signed short failed.")
        v59 = <signed short>tmp63
        v60 = [None]*v59
        v61 = Mut5((<signed short>0))
        while method36(v59, v61):
            v63 = v61.v0
            v64 = v22[v63]
            v65 = method82(v64)
            v60[v63] = v65
            del v65
            v66 = v63 + (<signed short>1)
            v61.v0 = v66
        del v22
        del v61
        v67 = "".join(v60)
        del v60
        v68 = {'community_card': v67, 'my_card': v56, 'my_pot': v50, 'my_stack': v55, 'op_card': v58, 'op_pot': v54, 'op_stack': v57}
        del v56; del v58; del v67
        v69 = {'actions': v45, 'table_data': v68, 'trace': v37}
        del v37; del v45; del v68
        v1(v69)
    elif v5.tag == 1: # Terminal
        v70 = (<UH3_1>v5).v0; v71 = (<UH3_1>v5).v1; v72 = (<UH3_1>v5).v2; v73 = (<UH3_1>v5).v3; v74 = (<UH3_1>v5).v4; v75 = (<UH3_1>v5).v5; v76 = (<UH3_1>v5).v6; v77 = (<UH3_1>v5).v7; v78 = (<UH3_1>v5).v8; v79 = (<UH3_1>v5).v9; v80 = (<UH3_1>v5).v10; v81 = (<UH3_1>v5).v11; v82 = (<UH3_1>v5).v12; v83 = (<UH3_1>v5).v13; v84 = (<UH3_1>v5).v14; v85 = (<UH3_1>v5).v15; v86 = (<UH3_1>v5).v16; v87 = (<UH3_1>v5).v17; v88 = (<UH3_1>v5).v18; v89 = (<UH3_1>v5).v19; v90 = (<UH3_1>v5).v20
        v91 = v2 == (<unsigned char>0)
        if v91:
            v92 = v72
        else:
            v92 = v75
        del v72; del v75
        v93 = method79(v92)
        del v92
        v94 = method85(v89, v86, v82, v83, v84, v85, v78, v79, v80, v81, v90, v93)
        del v93
        v95 = False
        v96 = False
        v97 = False
        v98 = {'call': v95, 'fold': v96, 'raise_max': (<signed short>0), 'raise_min': (<signed short>0), 'raise_to': v97}
        del v95; del v96; del v97
        if v91:
            v100 = v90
        else:
            v100 = -v90
        v101 = round(v100)
        v102 = v2 == v80
        if v102:
            v103, v104, v105, v106, v107, v108, v109, v110 = v78, v79, v80, v81, v82, v83, v84, v85
        else:
            v103, v104, v105, v106, v107, v108, v109, v110 = v82, v83, v84, v85, v78, v79, v80, v81
        v111 = v88 + v101
        v112 = method84(v104, v103)
        v113 = v88 - v101
        v114 = method84(v108, v107)
        tmp65 = len(v86)
        if <signed short>tmp65 != tmp65: raise Exception("The conversion to signed short failed.")
        v115 = <signed short>tmp65
        v116 = [None]*v115
        v117 = Mut5((<signed short>0))
        while method36(v115, v117):
            v119 = v117.v0
            v120 = v86[v119]
            v121 = method82(v120)
            v116[v119] = v121
            del v121
            v122 = v119 + (<signed short>1)
            v117.v0 = v122
        del v86
        del v117
        v123 = "".join(v116)
        del v116
        v124 = {'community_card': v123, 'my_card': v112, 'my_pot': (<signed short>0), 'my_stack': v111, 'op_card': v114, 'op_pot': (<signed short>0), 'op_stack': v113}
        del v112; del v114; del v123
        v125 = {'actions': v98, 'table_data': v124, 'trace': v94}
        del v94; del v98; del v124
        v1(v125)
cpdef object main():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    v0 = Closure0()
    v1 = Closure2()
    v2 = Closure5()
    v3 = Closure6()
    v4 = Closure36()
    v5 = {'callbot_player': v0, 'neural': v1, 'uniform_player': v2, 'vs_one': v3, 'vs_self': v4}
    del v0; del v1; del v2; del v3; del v4
    v6 = Closure40()
    return {'train': v5, 'ui': v6}
