import collections
import numpy
cimport numpy
import torch
cimport libc.math
cdef class Closure2():
    def __init__(self): pass
    def __call__(self, v0):
        return v0
cdef class Tuple0:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Mut0:
    cdef public unsigned long long v0
    cdef public unsigned long long v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, unsigned long long v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
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
cdef class Tuple1:
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
cdef class Tuple2:
    cdef readonly signed char v0
    cdef readonly signed char v1
    cdef readonly signed char v2
    cdef readonly signed char v3
    cdef readonly signed char v4
    cdef readonly signed char v5
    def __init__(self, signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5
cdef class Mut1:
    cdef public signed short v0
    cdef public unsigned long long v1
    def __init__(self, signed short v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
cdef class Tuple3:
    cdef readonly signed char v0
    cdef readonly signed char v1
    cdef readonly signed char v2
    cdef readonly signed char v3
    cdef readonly signed char v4
    def __init__(self, signed char v0, signed char v1, signed char v2, signed char v3, signed char v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple4:
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
    cdef readonly signed short v2
    def __init__(self, signed char v0, signed char v1, signed short v2): self.tag = 2; self.v0 = v0; self.v1 = v1; self.v2 = v2
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
cdef class Mut2:
    cdef public signed short v0
    cdef public UH2 v1
    def __init__(self, signed short v0, UH2 v1): self.v0 = v0; self.v1 = v1
cdef class Mut3:
    cdef public unsigned long long v0
    def __init__(self, unsigned long long v0): self.v0 = v0
cdef class Mut4:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut5:
    cdef public signed short v0
    def __init__(self, signed short v0): self.v0 = v0
cdef class Tuple5:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly US1 v2
    def __init__(self, float v0, float v1, US1 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure1():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, list v1):
        cdef object v0 = self.v0
        cdef unsigned long long v2
        cdef bint v3
        cdef numpy.ndarray[object,ndim=1] v4
        cdef object v5
        cdef unsigned long long v6
        cdef unsigned long long v7
        cdef Mut0 v8
        cdef unsigned long long v10
        cdef unsigned long long v11
        cdef unsigned long long v12
        cdef float v13
        cdef float v14
        cdef UH0 v15
        cdef float v16
        cdef float v17
        cdef UH0 v18
        cdef float v19
        cdef float v20
        cdef signed char v21
        cdef signed char v22
        cdef unsigned char v23
        cdef signed short v24
        cdef signed char v25
        cdef signed char v26
        cdef unsigned char v27
        cdef signed short v28
        cdef numpy.ndarray[signed char,ndim=1] v29
        cdef signed short v30
        cdef signed short v31
        cdef bint v32
        cdef unsigned char v33
        cdef signed short v34
        cdef bint v35
        cdef bint v36
        cdef signed short v37
        cdef signed short v38
        cdef signed short v39
        cdef Tuple1 tmp0
        cdef numpy.ndarray[signed char,ndim=1] v40
        cdef numpy.ndarray[signed char,ndim=1] v41
        cdef bint v42
        cdef UH0 v43
        cdef signed char v44
        cdef signed char v45
        cdef signed char v46
        cdef signed char v47
        cdef signed char v48
        cdef signed char v49
        cdef Tuple2 tmp18
        cdef signed char v50
        cdef signed char v51
        cdef signed char v52
        cdef signed char v53
        cdef signed char v54
        cdef signed char v55
        cdef Tuple2 tmp20
        cdef US2 v56
        cdef UH1 v57
        cdef UH1 v58
        cdef UH1 v59
        cdef signed char v60
        cdef signed char v61
        cdef signed char v62
        cdef signed char v63
        cdef signed char v64
        cdef signed char v65
        cdef Tuple2 tmp21
        cdef signed char v66
        cdef signed char v67
        cdef signed char v68
        cdef signed char v69
        cdef signed char v70
        cdef signed char v71
        cdef Tuple2 tmp22
        cdef signed char v72
        cdef signed char v73
        cdef signed char v74
        cdef signed char v75
        cdef signed char v76
        cdef signed char v77
        cdef Tuple2 tmp23
        cdef signed char v78
        cdef signed char v79
        cdef signed char v80
        cdef signed char v81
        cdef signed char v82
        cdef signed char v83
        cdef Tuple2 tmp24
        cdef signed char v84
        cdef signed char v85
        cdef signed char v86
        cdef signed char v87
        cdef signed char v88
        cdef signed char v89
        cdef signed char v90
        cdef signed char v91
        cdef signed char v92
        cdef signed char v93
        cdef bint v94
        cdef signed long v97
        cdef bint v95
        cdef bint v98
        cdef signed long v127
        cdef bint v99
        cdef signed long v102
        cdef bint v100
        cdef bint v103
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
        cdef bint v120
        cdef signed short v128
        cdef unsigned long long tmp25
        cdef US3 v129
        cdef US3 v130
        cdef US3 v131
        cdef UH2 v132
        cdef UH2 v133
        cdef UH2 v134
        cdef UH2 v135
        cdef Mut2 v136
        cdef signed short v138
        cdef signed short v139
        cdef signed short v140
        cdef signed short v141
        cdef UH2 v142
        cdef signed char v143
        cdef signed short v144
        cdef US3 v145
        cdef UH2 v146
        cdef UH2 v147
        cdef UH2 v148
        cdef unsigned long long v149
        cdef unsigned long long v150
        cdef bint v151
        cdef unsigned long long v152
        cdef unsigned long long v153
        cdef unsigned long long v154
        cdef bint v155
        cdef unsigned long long v156
        cdef unsigned long long v157
        cdef unsigned long long v158
        cdef unsigned long long v159
        cdef numpy.ndarray[float,ndim=3] v160
        cdef numpy.ndarray[signed char,ndim=2] v161
        cdef numpy.ndarray[float,ndim=3] v162
        cdef numpy.ndarray[signed char,ndim=2] v163
        cdef numpy.ndarray[float,ndim=3] v164
        cdef numpy.ndarray[signed char,ndim=2] v165
        cdef numpy.ndarray[object,ndim=1] v166
        cdef numpy.ndarray[float,ndim=1] v167
        cdef unsigned long long v168
        cdef Mut3 v169
        cdef unsigned long long v171
        cdef float v172
        cdef float v173
        cdef UH0 v174
        cdef float v175
        cdef float v176
        cdef UH0 v177
        cdef float v178
        cdef float v179
        cdef signed char v180
        cdef signed char v181
        cdef unsigned char v182
        cdef signed short v183
        cdef signed char v184
        cdef signed char v185
        cdef unsigned char v186
        cdef signed short v187
        cdef numpy.ndarray[signed char,ndim=1] v188
        cdef signed short v189
        cdef signed short v190
        cdef bint v191
        cdef unsigned char v192
        cdef signed short v193
        cdef bint v194
        cdef bint v195
        cdef signed short v196
        cdef signed short v197
        cdef signed short v198
        cdef Tuple1 tmp26
        cdef numpy.ndarray[signed char,ndim=1] v199
        cdef numpy.ndarray[signed char,ndim=1] v200
        cdef bint v201
        cdef UH0 v202
        cdef signed char v203
        cdef signed char v204
        cdef signed char v205
        cdef signed char v206
        cdef signed char v207
        cdef signed char v208
        cdef Tuple2 tmp27
        cdef signed char v209
        cdef signed char v210
        cdef signed char v211
        cdef signed char v212
        cdef signed char v213
        cdef signed char v214
        cdef Tuple2 tmp28
        cdef US2 v215
        cdef UH1 v216
        cdef UH1 v217
        cdef UH1 v218
        cdef signed char v219
        cdef signed char v220
        cdef signed char v221
        cdef signed char v222
        cdef signed char v223
        cdef signed char v224
        cdef Tuple2 tmp29
        cdef signed char v225
        cdef signed char v226
        cdef signed char v227
        cdef signed char v228
        cdef signed char v229
        cdef signed char v230
        cdef Tuple2 tmp30
        cdef signed char v231
        cdef signed char v232
        cdef signed char v233
        cdef signed char v234
        cdef signed char v235
        cdef signed char v236
        cdef Tuple2 tmp31
        cdef signed char v237
        cdef signed char v238
        cdef signed char v239
        cdef signed char v240
        cdef signed char v241
        cdef signed char v242
        cdef Tuple2 tmp32
        cdef signed char v243
        cdef signed char v244
        cdef signed char v245
        cdef signed char v246
        cdef signed char v247
        cdef signed char v248
        cdef signed char v249
        cdef signed char v250
        cdef signed char v251
        cdef signed char v252
        cdef bint v253
        cdef signed long v256
        cdef bint v254
        cdef bint v257
        cdef signed long v286
        cdef bint v258
        cdef signed long v261
        cdef bint v259
        cdef bint v262
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
        cdef bint v279
        cdef signed short v287
        cdef unsigned long long tmp33
        cdef US3 v288
        cdef US3 v289
        cdef US3 v290
        cdef UH2 v291
        cdef UH2 v292
        cdef UH2 v293
        cdef UH2 v294
        cdef Mut2 v295
        cdef signed short v297
        cdef signed short v298
        cdef signed short v299
        cdef signed short v300
        cdef UH2 v301
        cdef signed char v302
        cdef signed short v303
        cdef US3 v304
        cdef UH2 v305
        cdef UH2 v306
        cdef UH2 v307
        cdef unsigned long long v308
        cdef unsigned long long v309
        cdef unsigned long long v310
        cdef unsigned long long v311
        cdef unsigned long long v312
        cdef unsigned long long v313
        cdef Mut4 v314
        cdef list v315
        cdef US1 v316
        cdef US1 v317
        cdef signed short v318
        cdef signed short v319
        cdef signed short v320
        cdef signed short v321
        cdef bint v322
        cdef Mut5 v323
        cdef signed short v325
        cdef US1 v326
        cdef signed short v327
        cdef signed short v328
        cdef bint v329
        cdef bint v335
        cdef bint v330
        cdef bint v331
        cdef US1 v336
        cdef signed short v337
        cdef bint v338
        cdef bint v344
        cdef bint v339
        cdef bint v340
        cdef US1 v345
        cdef signed short v346
        cdef signed short v347
        cdef signed short v348
        cdef signed short v349
        cdef bint v350
        cdef bint v356
        cdef bint v351
        cdef bint v352
        cdef US1 v357
        cdef signed short v358
        cdef signed short v359
        cdef signed short v360
        cdef bint v361
        cdef bint v367
        cdef bint v362
        cdef bint v363
        cdef US1 v368
        cdef signed short v369
        cdef signed short v370
        cdef signed short v371
        cdef signed short v372
        cdef bint v373
        cdef bint v379
        cdef bint v374
        cdef bint v375
        cdef US1 v380
        cdef signed short v381
        cdef signed short v382
        cdef bint v383
        cdef bint v389
        cdef bint v384
        cdef bint v385
        cdef US1 v390
        cdef signed short v391
        cdef bint v392
        cdef float v393
        cdef float v394
        cdef float v395
        cdef float v397
        cdef float v398
        cdef float v399
        cdef signed short v400
        cdef signed short v401
        cdef bint v402
        cdef bint v408
        cdef bint v403
        cdef bint v404
        cdef US1 v409
        cdef float v410
        cdef float v411
        cdef float v412
        cdef float v413
        cdef float v414
        cdef float v416
        cdef float v417
        cdef float v418
        cdef float v419
        cdef signed short v420
        cdef signed short v421
        cdef bint v422
        cdef bint v428
        cdef bint v423
        cdef bint v424
        cdef US1 v429
        cdef numpy.ndarray[object,ndim=1] v430
        cdef signed short v431
        cdef unsigned long long tmp34
        cdef Mut5 v432
        cdef signed short v434
        cdef US1 v435
        cdef numpy.ndarray[float,ndim=1] v436
        cdef signed short v437
        cdef signed short v438
        cdef signed short v439
        cdef float v440
        cdef unsigned long long v441
        cdef object v442
        cdef object v443
        cdef object v444
        cdef object v445
        cdef object v446
        cdef object v447
        cdef object v448
        cdef object v449
        cdef object v450
        cdef object v451
        cdef object v452
        cdef numpy.ndarray[float,ndim=2] v453
        cdef numpy.ndarray[signed long long,ndim=1] v454
        cdef object v455
        cdef numpy.ndarray[object,ndim=1] v456
        cdef Mut3 v457
        cdef unsigned long long v459
        cdef signed long long v460
        cdef bint v461
        cdef float v463
        cdef float v464
        cdef numpy.ndarray[object,ndim=1] v465
        cdef signed short v466
        cdef US1 v467
        cdef unsigned long long v468
        v2 = len(v1)
        v3 = v2 == (<unsigned long long>0)
        if v3:
            v4 = numpy.empty((<unsigned long long>0),dtype=object)
            v5 = Closure2()
            return Tuple0(v4, v5)
        else:
            pass # import torch
            v6 = len(v1)
            v7 = len(v1)
            v8 = Mut0((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
            while method0(v7, v8):
                v10 = v8.v0
                v11, v12 = v8.v1, v8.v2
                tmp0 = v1[v10]
                v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16, tmp0.v17, tmp0.v18, tmp0.v19, tmp0.v20, tmp0.v21, tmp0.v22, tmp0.v23, tmp0.v24, tmp0.v25, tmp0.v26
                del tmp0
                v40 = v29[:v30]
                v41 = v29[v30:]
                v42 = v33 == (<unsigned char>0)
                if v42:
                    v43 = v15
                else:
                    v43 = v18
                del v15; del v18
                tmp18 = method1(v22, v21, v40)
                v44, v45, v46, v47, v48, v49 = tmp18.v0, tmp18.v1, tmp18.v2, tmp18.v3, tmp18.v4, tmp18.v5
                del tmp18
                tmp20 = method22(v40)
                v50, v51, v52, v53, v54, v55 = tmp20.v0, tmp20.v1, tmp20.v2, tmp20.v3, tmp20.v4, tmp20.v5
                del tmp20
                del v40
                v56 = US2_2(v49, v55, v31)
                v57 = UH1_1()
                v58 = UH1_0(v56, v57)
                del v56; del v57
                v59 = method23(v43, v58)
                del v43; del v58
                tmp21 = method1(v22, v21, v29)
                v60, v61, v62, v63, v64, v65 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3, tmp21.v4, tmp21.v5
                del tmp21
                tmp22 = method1(v26, v25, v29)
                v66, v67, v68, v69, v70, v71 = tmp22.v0, tmp22.v1, tmp22.v2, tmp22.v3, tmp22.v4, tmp22.v5
                del tmp22
                tmp23 = method1(v22, v21, v29)
                v72, v73, v74, v75, v76, v77 = tmp23.v0, tmp23.v1, tmp23.v2, tmp23.v3, tmp23.v4, tmp23.v5
                del tmp23
                tmp24 = method1(v26, v25, v29)
                v78, v79, v80, v81, v82, v83 = tmp24.v0, tmp24.v1, tmp24.v2, tmp24.v3, tmp24.v4, tmp24.v5
                del tmp24
                del v29
                v84 = v72 % (<signed char>13)
                v85 = v73 % (<signed char>13)
                v86 = v74 % (<signed char>13)
                v87 = v75 % (<signed char>13)
                v88 = v76 % (<signed char>13)
                v89 = v78 % (<signed char>13)
                v90 = v79 % (<signed char>13)
                v91 = v80 % (<signed char>13)
                v92 = v81 % (<signed char>13)
                v93 = v82 % (<signed char>13)
                v94 = v77 < v83
                if v94:
                    v97 = (<signed long>-1)
                else:
                    v95 = v77 > v83
                    if v95:
                        v97 = (<signed long>1)
                    else:
                        v97 = (<signed long>0)
                v98 = v97 == (<signed long>0)
                if v98:
                    v99 = v84 < v89
                    if v99:
                        v102 = (<signed long>-1)
                    else:
                        v100 = v84 > v89
                        if v100:
                            v102 = (<signed long>1)
                        else:
                            v102 = (<signed long>0)
                    v103 = v102 == (<signed long>0)
                    if v103:
                        v104 = v85 < v90
                        if v104:
                            v107 = (<signed long>-1)
                        else:
                            v105 = v85 > v90
                            if v105:
                                v107 = (<signed long>1)
                            else:
                                v107 = (<signed long>0)
                        v108 = v107 == (<signed long>0)
                        if v108:
                            v109 = v86 < v91
                            if v109:
                                v112 = (<signed long>-1)
                            else:
                                v110 = v86 > v91
                                if v110:
                                    v112 = (<signed long>1)
                                else:
                                    v112 = (<signed long>0)
                            v113 = v112 == (<signed long>0)
                            if v113:
                                v114 = v87 < v92
                                if v114:
                                    v117 = (<signed long>-1)
                                else:
                                    v115 = v87 > v92
                                    if v115:
                                        v117 = (<signed long>1)
                                    else:
                                        v117 = (<signed long>0)
                                v118 = v117 == (<signed long>0)
                                if v118:
                                    v119 = v88 < v93
                                    if v119:
                                        v127 = (<signed long>-1)
                                    else:
                                        v120 = v88 > v93
                                        if v120:
                                            v127 = (<signed long>1)
                                        else:
                                            v127 = (<signed long>0)
                                else:
                                    v127 = v117
                            else:
                                v127 = v112
                        else:
                            v127 = v107
                    else:
                        v127 = v102
                else:
                    v127 = v97
                tmp25 = len(v41)
                if <signed short>tmp25 != tmp25: raise Exception("The conversion to signed short failed.")
                v128 = <signed short>tmp25
                v129 = US3_1(v25)
                v130 = US3_1(v26)
                v131 = US3_2(v127, v71, v65)
                v132 = UH2_1()
                v133 = UH2_0(v131, v132)
                del v131; del v132
                v134 = UH2_0(v130, v133)
                del v130; del v133
                v135 = UH2_0(v129, v134)
                del v129; del v134
                v136 = Mut2((<signed short>0), v135)
                del v135
                while method24(v128, v136):
                    v138 = v136.v0
                    v139 = -v138
                    v140 = v139 + v128
                    v141 = v140 - (<signed short>1)
                    v142 = v136.v1
                    v143 = v41[v141]
                    v144 = v138 + (<signed short>1)
                    v145 = US3_0(v143)
                    v146 = UH2_0(v145, v142)
                    del v142; del v145
                    v136.v0 = v144
                    v136.v1 = v146
                    del v146
                del v41
                v147 = v136.v1
                del v136
                v148 = method25(v59, v147)
                del v147
                v149 = (<unsigned long long>0)
                v150 = method26(v59, v149)
                del v59
                v151 = v11 >= v150
                if v151:
                    v152 = v11
                else:
                    v152 = v150
                v153 = (<unsigned long long>0)
                v154 = method27(v148, v153)
                del v148
                v155 = v12 >= v154
                if v155:
                    v156 = v12
                else:
                    v156 = v154
                v157 = v10 + (<unsigned long long>1)
                v8.v0 = v157
                v8.v1 = v152
                v8.v2 = v156
            v158, v159 = v8.v1, v8.v2
            del v8
            v160 = numpy.zeros((v6,v158,(<signed short>69)),dtype=numpy.float32)
            v161 = numpy.zeros((v6,v158),dtype=numpy.int8)
            v162 = numpy.zeros((v6,v159,(<signed short>124)),dtype=numpy.float32)
            v163 = numpy.zeros((v6,v159),dtype=numpy.int8)
            v164 = numpy.zeros((v6,(<signed short>16),(<signed short>18)),dtype=numpy.float32)
            v165 = numpy.ones((v6,(<signed short>16)),dtype=numpy.int8)
            v166 = numpy.empty(v6,dtype=object)
            v167 = numpy.empty(v6,dtype=numpy.float32)
            v168 = len(v1)
            v169 = Mut3((<unsigned long long>0))
            while method28(v168, v169):
                v171 = v169.v0
                tmp26 = v1[v171]
                v172, v173, v174, v175, v176, v177, v178, v179, v180, v181, v182, v183, v184, v185, v186, v187, v188, v189, v190, v191, v192, v193, v194, v195, v196, v197, v198 = tmp26.v0, tmp26.v1, tmp26.v2, tmp26.v3, tmp26.v4, tmp26.v5, tmp26.v6, tmp26.v7, tmp26.v8, tmp26.v9, tmp26.v10, tmp26.v11, tmp26.v12, tmp26.v13, tmp26.v14, tmp26.v15, tmp26.v16, tmp26.v17, tmp26.v18, tmp26.v19, tmp26.v20, tmp26.v21, tmp26.v22, tmp26.v23, tmp26.v24, tmp26.v25, tmp26.v26
                del tmp26
                v199 = v188[:v189]
                v200 = v188[v189:]
                v201 = v192 == (<unsigned char>0)
                if v201:
                    v202 = v174
                else:
                    v202 = v177
                del v174; del v177
                tmp27 = method1(v181, v180, v199)
                v203, v204, v205, v206, v207, v208 = tmp27.v0, tmp27.v1, tmp27.v2, tmp27.v3, tmp27.v4, tmp27.v5
                del tmp27
                tmp28 = method22(v199)
                v209, v210, v211, v212, v213, v214 = tmp28.v0, tmp28.v1, tmp28.v2, tmp28.v3, tmp28.v4, tmp28.v5
                del tmp28
                del v199
                v215 = US2_2(v208, v214, v190)
                v216 = UH1_1()
                v217 = UH1_0(v215, v216)
                del v215; del v216
                v218 = method23(v202, v217)
                del v202; del v217
                tmp29 = method1(v181, v180, v188)
                v219, v220, v221, v222, v223, v224 = tmp29.v0, tmp29.v1, tmp29.v2, tmp29.v3, tmp29.v4, tmp29.v5
                del tmp29
                tmp30 = method1(v185, v184, v188)
                v225, v226, v227, v228, v229, v230 = tmp30.v0, tmp30.v1, tmp30.v2, tmp30.v3, tmp30.v4, tmp30.v5
                del tmp30
                tmp31 = method1(v181, v180, v188)
                v231, v232, v233, v234, v235, v236 = tmp31.v0, tmp31.v1, tmp31.v2, tmp31.v3, tmp31.v4, tmp31.v5
                del tmp31
                tmp32 = method1(v185, v184, v188)
                v237, v238, v239, v240, v241, v242 = tmp32.v0, tmp32.v1, tmp32.v2, tmp32.v3, tmp32.v4, tmp32.v5
                del tmp32
                del v188
                v243 = v231 % (<signed char>13)
                v244 = v232 % (<signed char>13)
                v245 = v233 % (<signed char>13)
                v246 = v234 % (<signed char>13)
                v247 = v235 % (<signed char>13)
                v248 = v237 % (<signed char>13)
                v249 = v238 % (<signed char>13)
                v250 = v239 % (<signed char>13)
                v251 = v240 % (<signed char>13)
                v252 = v241 % (<signed char>13)
                v253 = v236 < v242
                if v253:
                    v256 = (<signed long>-1)
                else:
                    v254 = v236 > v242
                    if v254:
                        v256 = (<signed long>1)
                    else:
                        v256 = (<signed long>0)
                v257 = v256 == (<signed long>0)
                if v257:
                    v258 = v243 < v248
                    if v258:
                        v261 = (<signed long>-1)
                    else:
                        v259 = v243 > v248
                        if v259:
                            v261 = (<signed long>1)
                        else:
                            v261 = (<signed long>0)
                    v262 = v261 == (<signed long>0)
                    if v262:
                        v263 = v244 < v249
                        if v263:
                            v266 = (<signed long>-1)
                        else:
                            v264 = v244 > v249
                            if v264:
                                v266 = (<signed long>1)
                            else:
                                v266 = (<signed long>0)
                        v267 = v266 == (<signed long>0)
                        if v267:
                            v268 = v245 < v250
                            if v268:
                                v271 = (<signed long>-1)
                            else:
                                v269 = v245 > v250
                                if v269:
                                    v271 = (<signed long>1)
                                else:
                                    v271 = (<signed long>0)
                            v272 = v271 == (<signed long>0)
                            if v272:
                                v273 = v246 < v251
                                if v273:
                                    v276 = (<signed long>-1)
                                else:
                                    v274 = v246 > v251
                                    if v274:
                                        v276 = (<signed long>1)
                                    else:
                                        v276 = (<signed long>0)
                                v277 = v276 == (<signed long>0)
                                if v277:
                                    v278 = v247 < v252
                                    if v278:
                                        v286 = (<signed long>-1)
                                    else:
                                        v279 = v247 > v252
                                        if v279:
                                            v286 = (<signed long>1)
                                        else:
                                            v286 = (<signed long>0)
                                else:
                                    v286 = v276
                            else:
                                v286 = v271
                        else:
                            v286 = v266
                    else:
                        v286 = v261
                else:
                    v286 = v256
                tmp33 = len(v200)
                if <signed short>tmp33 != tmp33: raise Exception("The conversion to signed short failed.")
                v287 = <signed short>tmp33
                v288 = US3_1(v184)
                v289 = US3_1(v185)
                v290 = US3_2(v286, v230, v224)
                v291 = UH2_1()
                v292 = UH2_0(v290, v291)
                del v290; del v291
                v293 = UH2_0(v289, v292)
                del v289; del v292
                v294 = UH2_0(v288, v293)
                del v288; del v293
                v295 = Mut2((<signed short>0), v294)
                del v294
                while method24(v287, v295):
                    v297 = v295.v0
                    v298 = -v297
                    v299 = v298 + v287
                    v300 = v299 - (<signed short>1)
                    v301 = v295.v1
                    v302 = v200[v300]
                    v303 = v297 + (<signed short>1)
                    v304 = US3_0(v302)
                    v305 = UH2_0(v304, v301)
                    del v301; del v304
                    v295.v0 = v303
                    v295.v1 = v305
                    del v305
                del v200
                v306 = v295.v1
                del v295
                v307 = method25(v218, v306)
                del v306
                v308 = (<unsigned long long>0)
                v309 = method29(v160, v171, v218, v308)
                del v218
                method32(v158, v161, v171, v309)
                v310 = (<unsigned long long>0)
                v311 = method33(v162, v171, v307, v310)
                del v307
                method34(v159, v163, v171, v311)
                v312 = (<unsigned long long>3)
                v313 = (<unsigned long long>7)
                v314 = method35(v312, v313)
                v315 = [None]*(<signed short>0)
                if v194:
                    v316 = US1_1()
                    v315.append(v316)
                    del v316
                else:
                    pass
                v317 = US1_0()
                v315.append(v317)
                del v317
                if v195:
                    v318 = len(v315)
                    v319 = (<signed short>16) - v318
                    v320 = (<signed short>1) + v196
                    v321 = v320 - v197
                    v322 = v321 <= v319
                    if v322:
                        v323 = Mut5(v197)
                        while method36(v320, v323):
                            v325 = v323.v0
                            v326 = US1_2(v325)
                            v315.append(v326)
                            del v326
                            v327 = v325 + (<signed short>1)
                            v323.v0 = v327
                        del v323
                    else:
                        v328 = len(v315)
                        v329 = v328 < (<signed short>16)
                        if v329:
                            v330 = v197 <= v197
                            if v330:
                                v331 = v197 <= v196
                                if v331:
                                    v335 = method37(v314, v197)
                                else:
                                    v335 = 0
                            else:
                                v335 = 0
                        else:
                            v335 = 0
                        if v335:
                            v336 = US1_2(v197)
                            v315.append(v336)
                            del v336
                        else:
                            pass
                        v337 = len(v315)
                        v338 = v337 < (<signed short>16)
                        if v338:
                            v339 = v197 <= v196
                            if v339:
                                v340 = v196 <= v196
                                if v340:
                                    v344 = method37(v314, v196)
                                else:
                                    v344 = 0
                            else:
                                v344 = 0
                        else:
                            v344 = 0
                        if v344:
                            v345 = US1_2(v196)
                            v315.append(v345)
                            del v345
                        else:
                            pass
                        v346 = (<signed short>2) * v193
                        v347 = v346 // (<signed short>4)
                        v348 = v193 + v347
                        v349 = len(v315)
                        v350 = v349 < (<signed short>16)
                        if v350:
                            v351 = v197 <= v348
                            if v351:
                                v352 = v348 <= v196
                                if v352:
                                    v356 = method37(v314, v348)
                                else:
                                    v356 = 0
                            else:
                                v356 = 0
                        else:
                            v356 = 0
                        if v356:
                            v357 = US1_2(v348)
                            v315.append(v357)
                            del v357
                        else:
                            pass
                        v358 = v346 // (<signed short>2)
                        v359 = v193 + v358
                        v360 = len(v315)
                        v361 = v360 < (<signed short>16)
                        if v361:
                            v362 = v197 <= v359
                            if v362:
                                v363 = v359 <= v196
                                if v363:
                                    v367 = method37(v314, v359)
                                else:
                                    v367 = 0
                            else:
                                v367 = 0
                        else:
                            v367 = 0
                        if v367:
                            v368 = US1_2(v359)
                            v315.append(v368)
                            del v368
                        else:
                            pass
                        v369 = v346 * (<signed short>3)
                        v370 = v369 // (<signed short>4)
                        v371 = v193 + v370
                        v372 = len(v315)
                        v373 = v372 < (<signed short>16)
                        if v373:
                            v374 = v197 <= v371
                            if v374:
                                v375 = v371 <= v196
                                if v375:
                                    v379 = method37(v314, v371)
                                else:
                                    v379 = 0
                            else:
                                v379 = 0
                        else:
                            v379 = 0
                        if v379:
                            v380 = US1_2(v371)
                            v315.append(v380)
                            del v380
                        else:
                            pass
                        v381 = v193 + v346
                        v382 = len(v315)
                        v383 = v382 < (<signed short>16)
                        if v383:
                            v384 = v197 <= v381
                            if v384:
                                v385 = v381 <= v196
                                if v385:
                                    v389 = method37(v314, v381)
                                else:
                                    v389 = 0
                            else:
                                v389 = 0
                        else:
                            v389 = 0
                        if v389:
                            v390 = US1_2(v381)
                            v315.append(v390)
                            del v390
                        else:
                            pass
                        v391 = v321 * (<signed short>3)
                        v392 = v391 <= v319
                        if v392:
                            v393 = <float>v197
                            v394 = <float>v196
                            v395 = v394 - v393
                            while method42(v315):
                                v397 = numpy.random.rand()
                                v398 = v397 * v395
                                v399 = v398 + v393
                                v400 = round(v399)
                                v401 = len(v315)
                                v402 = v401 < (<signed short>16)
                                if v402:
                                    v403 = v197 <= v400
                                    if v403:
                                        v404 = v400 <= v196
                                        if v404:
                                            v408 = method37(v314, v400)
                                        else:
                                            v408 = 0
                                    else:
                                        v408 = 0
                                else:
                                    v408 = 0
                                if v408:
                                    v409 = US1_2(v400)
                                    v315.append(v409)
                                    del v409
                                else:
                                    pass
                        else:
                            v410 = <float>v197
                            v411 = libc.math.log(v410)
                            v412 = <float>v196
                            v413 = libc.math.log(v412)
                            v414 = v413 - v411
                            while method42(v315):
                                v416 = numpy.random.rand()
                                v417 = v416 * v414
                                v418 = v417 + v411
                                v419 = libc.math.exp(v418)
                                v420 = round(v419)
                                v421 = len(v315)
                                v422 = v421 < (<signed short>16)
                                if v422:
                                    v423 = v197 <= v420
                                    if v423:
                                        v424 = v420 <= v196
                                        if v424:
                                            v428 = method37(v314, v420)
                                        else:
                                            v428 = 0
                                    else:
                                        v428 = 0
                                else:
                                    v428 = 0
                                if v428:
                                    v429 = US1_2(v420)
                                    v315.append(v429)
                                    del v429
                                else:
                                    pass
                else:
                    pass
                del v314
                v430 = numpy.array(v315,copy=False)
                del v315
                v166[v171] = v430
                tmp34 = len(v430)
                if <signed short>tmp34 != tmp34: raise Exception("The conversion to signed short failed.")
                v431 = <signed short>tmp34
                v432 = Mut5((<signed short>0))
                while method36(v431, v432):
                    v434 = v432.v0
                    v435 = v430[v434]
                    v436 = v164[v171,v434]
                    if v435.tag == 0: # Call
                        v436[(<signed short>0)] = (<float>1)
                    elif v435.tag == 1: # Fold
                        v436[(<signed short>1)] = (<float>1)
                    elif v435.tag == 2: # RaiseTo
                        v437 = (<US1_2>v435).v0
                        v438 = (<signed short>2)
                        method30(v437, v436, v438)
                    del v435; del v436
                    v165[v171,v434] = 0
                    v439 = v434 + (<signed short>1)
                    v432.v0 = v439
                del v430
                del v432
                if v201:
                    v440 = (<float>1)
                else:
                    v440 = (<float>-1)
                v167[v171] = v440
                v441 = v171 + (<unsigned long long>1)
                v169.v0 = v441
            del v169
            v442 = torch.from_numpy(v160)
            del v160
            v443 = v161.view('bool')
            del v161
            v444 = torch.from_numpy(v443)
            del v443
            v445 = torch.from_numpy(v162)
            del v162
            v446 = v163.view('bool')
            del v163
            v447 = torch.from_numpy(v446)
            del v446
            v448 = torch.from_numpy(v167)
            del v167
            v449 = torch.from_numpy(v164)
            del v164
            v450 = v165.view('bool')
            del v165
            v451 = torch.from_numpy(v450)
            del v450
            v452 = v0(v442, v444, v445, v447, v448, v449, v451)
            del v442; del v444; del v445; del v447; del v448; del v449; del v451
            v453 = v452[0]
            v454 = v452[1]
            v455 = v452[2]
            del v452
            v456 = numpy.empty(v6,dtype=object)
            v457 = Mut3((<unsigned long long>0))
            while method28(v6, v457):
                v459 = v457.v0
                v460 = v454[v459]
                v461 = v453 is None
                if v461:
                    v463 = (<float>1)
                else:
                    v463 = v453[v459,v460]
                v464 = libc.math.log(v463)
                v465 = v166[v459]
                v466 = <signed short>v460
                v467 = v465[v466]
                del v465
                v456[v459] = Tuple5(v464, v464, v467)
                del v467
                v468 = v459 + (<unsigned long long>1)
                v457.v0 = v468
            del v166; del v453; del v454
            del v457
            return Tuple0(v456, v455)
cdef class Closure0():
    def __init__(self): pass
    def __call__(self, v0):
        return Closure1(v0)
cdef class Closure3():
    def __init__(self): pass
    def __call__(self, list v0):
        cdef unsigned long long v1
        cdef numpy.ndarray[object,ndim=1] v2
        cdef Mut3 v3
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
        cdef Tuple1 tmp35
        cdef US1 v33
        cdef unsigned long long v34
        cdef object v35
        v1 = len(v0)
        v2 = numpy.empty(v1,dtype=object)
        v3 = Mut3((<unsigned long long>0))
        while method28(v1, v3):
            v5 = v3.v0
            tmp35 = v0[v5]
            v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32 = tmp35.v0, tmp35.v1, tmp35.v2, tmp35.v3, tmp35.v4, tmp35.v5, tmp35.v6, tmp35.v7, tmp35.v8, tmp35.v9, tmp35.v10, tmp35.v11, tmp35.v12, tmp35.v13, tmp35.v14, tmp35.v15, tmp35.v16, tmp35.v17, tmp35.v18, tmp35.v19, tmp35.v20, tmp35.v21, tmp35.v22, tmp35.v23, tmp35.v24, tmp35.v25, tmp35.v26
            del tmp35
            del v8; del v11; del v22
            v33 = US1_0()
            v2[v5] = Tuple5((<float>0), (<float>0), v33)
            del v33
            v34 = v5 + (<unsigned long long>1)
            v3.v0 = v34
        del v3
        v35 = Closure2()
        return Tuple0(v2, v35)
cdef class Closure4():
    def __init__(self): pass
    def __call__(self, list v0):
        cdef unsigned long long v1
        cdef numpy.ndarray[object,ndim=1] v2
        cdef Mut3 v3
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
        cdef Tuple1 tmp36
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
        v3 = Mut3((<unsigned long long>0))
        while method28(v1, v3):
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
            v2[v5] = Tuple5(v45, v45, v46)
            del v46
            v47 = v5 + (<unsigned long long>1)
            v3.v0 = v47
        del v3
        v48 = Closure2()
        return Tuple0(v2, v48)
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
cdef class Closure11():
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
    cdef float v11
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, signed short v10, float v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, float v12, float v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19):
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
        cdef float v11 = self.v11
        return UH3_1(v12, v13, v14, v15, v16, v17, v18, v19, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, 1, v11)
cdef class Closure15():
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
            return method81(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v21, v17, v18, v26, v24, v23, v28, v12, v13)
        else:
            v30 = v20 + v13
            v31 = v19 + v12
            v32 = US0_1(v21)
            v33 = UH0_0(v32, v14)
            del v32
            v34 = US0_1(v21)
            v35 = UH0_0(v34, v11)
            del v34
            return method81(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v21, v17, v18, v33, v15, v16, v35, v31, v30)
cdef class Closure14():
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
        v21 = Closure15(v2, v11, v4, v5, v6, v3, v0, v1, v8, v12, v7, v18, v19, v20, v15, v16, v17, v13, v14)
        return UH3_0(v13, v14, v15, v16, v17, v18, v19, v20, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>5), v8, 0, v2, v3, 0, v9, v8, v10, v8, v21)
cdef class Closure13():
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
            return method78(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v27, v25, v24, v29, v13, v14)
        else:
            v31 = v21 + v14
            v32 = v20 + v13
            v33 = US0_1(v22)
            v34 = UH0_0(v33, v15)
            del v33
            v35 = US0_1(v22)
            v36 = UH0_0(v35, v12)
            del v35
            return method78(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v34, v16, v17, v36, v32, v31)
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
        v24 = Closure13(v2, v14, v4, v5, v6, v7, v0, v1, v3, v9, v15, v8, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH3_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>5), v9, 0, v2, v10, v11, v12, v9, v13, v9, v24)
cdef class Closure10():
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
cdef class Closure19():
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
            return method85(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v27, v25, v24, v29, v13, v14)
        else:
            v31 = v21 + v14
            v32 = v20 + v13
            v33 = US0_1(v22)
            v34 = UH0_0(v33, v15)
            del v33
            v35 = US0_1(v22)
            v36 = UH0_0(v35, v12)
            del v35
            return method85(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v34, v16, v17, v36, v32, v31)
cdef class Closure18():
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
        v22 = Closure19(v2, v11, v4, v5, v6, v3, v0, v1, v8, v12, v7, v13, v19, v20, v21, v16, v17, v18, v14, v15)
        return UH3_0(v14, v15, v16, v17, v18, v19, v20, v21, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>4), v8, 0, v2, v3, 0, v9, v8, v10, v8, v22)
cdef class Closure17():
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
            return method82(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v28, v26, v25, v30, v14, v15)
        else:
            v32 = v22 + v15
            v33 = v21 + v14
            v34 = US0_1(v23)
            v35 = UH0_0(v34, v16)
            del v34
            v36 = US0_1(v23)
            v37 = UH0_0(v36, v13)
            del v36
            return method82(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v35, v17, v18, v37, v33, v32)
cdef class Closure16():
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
        v25 = Closure17(v2, v14, v4, v5, v6, v7, v0, v1, v3, v9, v15, v8, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH3_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>4), v9, 0, v2, v10, v11, v12, v9, v13, v9, v25)
cdef class Closure9():
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
cdef class Closure23():
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
            return method89(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v28, v26, v25, v30, v14, v15)
        else:
            v32 = v22 + v15
            v33 = v21 + v14
            v34 = US0_1(v23)
            v35 = UH0_0(v34, v16)
            del v34
            v36 = US0_1(v23)
            v37 = UH0_0(v36, v13)
            del v36
            return method89(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v35, v17, v18, v37, v33, v32)
cdef class Closure22():
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
        v23 = Closure23(v2, v11, v4, v5, v6, v3, v0, v1, v8, v12, v7, v13, v14, v20, v21, v22, v17, v18, v19, v15, v16)
        return UH3_0(v15, v16, v17, v18, v19, v20, v21, v22, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>3), v8, 0, v2, v3, 0, v9, v8, v10, v8, v23)
cdef class Closure21():
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
            return method86(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v24, v20, v21, v29, v27, v26, v31, v15, v16)
        else:
            v33 = v23 + v16
            v34 = v22 + v15
            v35 = US0_1(v24)
            v36 = UH0_0(v35, v17)
            del v35
            v37 = US0_1(v24)
            v38 = UH0_0(v37, v14)
            del v37
            return method86(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v24, v20, v21, v36, v18, v19, v38, v34, v33)
cdef class Closure20():
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
        v26 = Closure21(v2, v14, v4, v5, v6, v7, v0, v1, v3, v9, v15, v8, v16, v17, v23, v24, v25, v20, v21, v22, v18, v19)
        return UH3_0(v18, v19, v20, v21, v22, v23, v24, v25, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>3), v9, 0, v2, v10, v11, v12, v9, v13, v9, v26)
cdef class Closure8():
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
cdef class Closure27():
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
            return method93(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US0_1(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US0_1(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method93(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
cdef class Closure26():
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
        v26 = Closure27(v2, v11, v4, v5, v6, v3, v0, v1, v8, v12, v7, v13, v14, v15, v16, v17, v23, v24, v25, v20, v21, v22, v18, v19)
        return UH3_0(v18, v19, v20, v21, v22, v23, v24, v25, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>0), v8, 0, v2, v3, 0, v9, v8, v10, v8, v26)
cdef class Closure25():
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
            return method90(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v32, v30, v29, v34, v18, v19)
        else:
            v36 = v26 + v19
            v37 = v25 + v18
            v38 = US0_1(v27)
            v39 = UH0_0(v38, v20)
            del v38
            v40 = US0_1(v27)
            v41 = UH0_0(v40, v17)
            del v40
            return method90(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v39, v21, v22, v41, v37, v36)
cdef class Closure24():
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
        v29 = Closure25(v2, v14, v4, v5, v6, v7, v0, v1, v3, v9, v15, v8, v16, v17, v18, v19, v20, v26, v27, v28, v23, v24, v25, v21, v22)
        return UH3_0(v21, v22, v23, v24, v25, v26, v27, v28, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>0), v9, 0, v2, v10, v11, v12, v9, v13, v9, v29)
cdef class Closure32():
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
            return method97(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v21, v17, v18, v26, v24, v23, v28, v12, v13)
        else:
            v30 = v20 + v13
            v31 = v19 + v12
            v32 = US0_1(v21)
            v33 = UH0_0(v32, v14)
            del v32
            v34 = US0_1(v21)
            v35 = UH0_0(v34, v11)
            del v34
            return method97(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v21, v17, v18, v33, v15, v16, v35, v31, v30)
cdef class Closure31():
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
        v21 = Closure32(v2, v11, v4, v5, v6, v3, v0, v1, v8, v12, v7, v18, v19, v20, v15, v16, v17, v13, v14)
        return UH3_0(v13, v14, v15, v16, v17, v18, v19, v20, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>3), v8, 0, v2, v3, 0, v9, v8, v10, v8, v21)
cdef class Closure30():
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
            return method95(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v27, v25, v24, v29, v13, v14)
        else:
            v31 = v21 + v14
            v32 = v20 + v13
            v33 = US0_1(v22)
            v34 = UH0_0(v33, v15)
            del v33
            v35 = US0_1(v22)
            v36 = UH0_0(v35, v12)
            del v35
            return method95(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v34, v16, v17, v36, v32, v31)
cdef class Closure29():
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
        v24 = Closure30(v2, v14, v4, v5, v6, v7, v0, v1, v3, v9, v15, v8, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH3_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>3), v9, 0, v2, v10, v11, v12, v9, v13, v9, v24)
cdef class Closure28():
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
        v23 = method94(v1, v2, v20, v6, v7, v22, v8, v3, v4, v21, v5, v11)
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
cdef class Closure33():
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
cdef class Closure7():
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
        cdef Mut3 v11
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
        v11 = Mut3((<unsigned long long>0))
        while method28(v7, v11):
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
        return method98(v4, v5, v6, v9, v8, v10)
cdef class Closure6():
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
        return Closure7(v0, v1, v2, v3, v6, v5, v4)
cdef class Closure34():
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
        cdef Mut3 v8
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
        v8 = Mut3((<unsigned long long>0))
        while method28(v4, v8):
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
        return method99(v6, v5, v7)
cdef class Closure5():
    def __init__(self): pass
    def __call__(self, unsigned char v0, signed short v1, signed short v2, signed short v3):
        cdef object v4
        cdef object v5
        v4 = Closure6(v0, v1, v2, v3)
        v5 = Closure34(v0, v1, v2, v3)
        return collections.namedtuple("VsOne",['cat', 'exp'])(v4, v5)
cdef class Closure37():
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
        cdef Mut3 v10
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
        v10 = Mut3((<unsigned long long>0))
        while method28(v7, v10):
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
        return method100(v4, v5, v6, v8, v9)
cdef class Closure36():
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
        return Closure37(v0, v1, v2, v3, v6, v5, v4)
cdef class Closure38():
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
        cdef Mut3 v7
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
        v7 = Mut3((<unsigned long long>0))
        while method28(v4, v7):
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
        return method101(v5, v6)
cdef class Closure35():
    def __init__(self): pass
    def __call__(self, unsigned char v0, signed short v1, signed short v2, signed short v3):
        cdef object v4
        cdef object v5
        v4 = Closure36(v0, v1, v2, v3)
        v5 = Closure38(v0, v1, v2, v3)
        return collections.namedtuple("VsSelf",['cat', 'exp'])(v4, v5)
cdef class Closure41():
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
        method102(v0, v1, v2, v3, v6)
cdef class Closure42():
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
        method102(v0, v1, v2, v3, v7)
cdef class Closure43():
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
        method102(v0, v1, v2, v3, v6)
cdef class Closure40():
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
        method102(v0, v6, v5, v4, v15)
cdef class Closure39():
    def __init__(self): pass
    def __call__(self, v0):
        return Closure40(v0)
cdef bint method0(unsigned long long v0, Mut0 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef bint method2(signed short v0, Mut1 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef Tuple2 method4(unsigned long long v0, signed char v1, signed char v2):
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
            return Tuple2(v60, v65, v70, v75, v79, (<signed char>8))
        else:
            v80 = v2 + (<signed char>1)
            return method4(v0, v1, v80)
    else:
        v93 = v1 - (<signed char>1)
        return method3(v0, v93)
cdef Tuple3 method7(unsigned long long v0, signed char v1, signed char v2, signed char v3, unsigned char v4, signed char v5, signed char v6, signed char v7, signed char v8, signed char v9):
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
                return method7(v0, v1, v2, v44, v42, v37, v38, v39, v40, v41)
            else:
                return Tuple3(v37, v38, v39, v40, v41)
        else:
            v55 = v3 + (<signed char>1)
            return method7(v0, v1, v2, v55, v4, v5, v6, v7, v8, v9)
    else:
        v66 = v2 - (<signed char>1)
        return method6(v0, v1, v66, v5, v6, v7, v8, v9, v4)
cdef Tuple3 method6(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
    cdef bint v9
    cdef signed char v10
    cdef bint v16
    cdef signed char v17
    v9 = v2 == v1
    if v9:
        v10 = v2 - (<signed char>1)
        return method6(v0, v1, v10, v3, v4, v5, v6, v7, v8)
    else:
        v16 = (<signed char>0) <= v2
        if v16:
            v17 = (<signed char>0)
            return method7(v0, v1, v2, v17, v8, v3, v4, v5, v6, v7)
        else:
            return Tuple3(v3, v4, v5, v6, v7)
cdef Tuple4 method9(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7):
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
        return method9(v0, v1, v36, v32, v33, v34, v35, v37)
    else:
        return Tuple4(v3, v4, v5, v6)
cdef Tuple2 method12(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
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
        return Tuple2(v41, v42, v43, v44, v45, (<signed char>5))
    else:
        v48 = v2 - (<signed char>1)
        return method12(v0, v1, v48, v41, v42, v43, v44, v45, v46)
cdef Tuple3 method18(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, unsigned char v5, signed char v6, signed char v7, signed char v8, signed char v9, signed char v10):
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
                return method18(v0, v1, v2, v3, v45, v43, v38, v39, v40, v41, v42)
            else:
                return Tuple3(v38, v39, v40, v41, v42)
        else:
            v56 = v4 + (<signed char>1)
            return method18(v0, v1, v2, v3, v56, v5, v6, v7, v8, v9, v10)
    else:
        v67 = v3 - (<signed char>1)
        return method17(v0, v1, v2, v67, v6, v7, v8, v9, v10, v5)
cdef Tuple3 method17(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8, unsigned char v9):
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
        return method17(v0, v1, v2, v13, v4, v5, v6, v7, v8, v9)
    else:
        v19 = (<signed char>0) <= v3
        if v19:
            v20 = (<signed char>0)
            return method18(v0, v1, v2, v3, v20, v9, v4, v5, v6, v7, v8)
        else:
            return Tuple3(v4, v5, v6, v7, v8)
cdef Tuple3 method21(unsigned long long v0, signed char v1, signed char v2, unsigned char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8):
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
                return method21(v0, v1, v43, v41, v36, v37, v38, v39, v40)
            else:
                return Tuple3(v36, v37, v38, v39, v40)
        else:
            v54 = v2 + (<signed char>1)
            return method21(v0, v1, v54, v3, v4, v5, v6, v7, v8)
    else:
        v65 = v1 - (<signed char>1)
        return method20(v0, v65, v4, v5, v6, v7, v8, v3)
cdef Tuple3 method20(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, unsigned char v7):
    cdef bint v8
    cdef signed char v9
    v8 = (<signed char>0) <= v1
    if v8:
        v9 = (<signed char>0)
        return method21(v0, v1, v9, v7, v2, v3, v4, v5, v6)
    else:
        return Tuple3(v2, v3, v4, v5, v6)
cdef Tuple2 method19(unsigned long long v0, signed char v1):
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
    cdef Tuple4 tmp15
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
    cdef Tuple3 tmp16
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
    cdef Tuple3 tmp17
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
            tmp15 = method9(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp15.v0, tmp15.v1, tmp15.v2, tmp15.v3
            del tmp15
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp16 = method6(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp16.v0, tmp16.v1, tmp16.v2, tmp16.v3, tmp16.v4
            del tmp16
            return Tuple2(v40, v41, v51, v52, v53, (<signed char>1))
        else:
            v56 = v1 - (<signed char>1)
            return method19(v0, v56)
    else:
        v69 = (<signed char>12)
        v70 = (<signed char>-1)
        v71 = (<signed char>-1)
        v72 = (<signed char>-1)
        v73 = (<signed char>-1)
        v74 = (<signed char>-1)
        v75 = (<unsigned char>0)
        tmp17 = method20(v0, v69, v70, v71, v72, v73, v74, v75)
        v76, v77, v78, v79, v80 = tmp17.v0, tmp17.v1, tmp17.v2, tmp17.v3, tmp17.v4
        del tmp17
        return Tuple2(v76, v77, v78, v79, v80, (<signed char>0))
cdef Tuple2 method16(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4):
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
    cdef Tuple4 tmp13
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
    cdef Tuple3 tmp14
    cdef signed char v67
    cdef signed char v80
    v5 = v1 == v4
    if v5:
        v6 = v4 - (<signed char>1)
        return method16(v0, v1, v2, v3, v6)
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
                tmp13 = method9(v0, v4, v49, v45, v46, v47, v48, v50)
                v51, v52, v53, v54 = tmp13.v0, tmp13.v1, tmp13.v2, tmp13.v3
                del tmp13
                v55 = (<signed char>12)
                v56 = (<signed char>-1)
                v57 = (<signed char>-1)
                v58 = (<signed char>-1)
                v59 = (<signed char>-1)
                v60 = (<signed char>-1)
                v61 = (<unsigned char>0)
                tmp14 = method17(v0, v1, v4, v55, v56, v57, v58, v59, v60, v61)
                v62, v63, v64, v65, v66 = tmp14.v0, tmp14.v1, tmp14.v2, tmp14.v3, tmp14.v4
                del tmp14
                return Tuple2(v3, v2, v51, v52, v62, (<signed char>2))
            else:
                v67 = v4 - (<signed char>1)
                return method16(v0, v1, v2, v3, v67)
        else:
            v80 = (<signed char>12)
            return method19(v0, v80)
cdef Tuple2 method15(unsigned long long v0, signed char v1):
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
    cdef Tuple4 tmp12
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
            tmp12 = method9(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp12.v0, tmp12.v1, tmp12.v2, tmp12.v3
            del tmp12
            v44 = (<signed char>12)
            return method16(v0, v1, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method15(v0, v51)
    else:
        v64 = (<signed char>12)
        return method19(v0, v64)
cdef Tuple2 method14(unsigned long long v0, signed char v1):
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
    cdef Tuple4 tmp10
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
    cdef Tuple3 tmp11
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
            tmp10 = method9(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp10.v0, tmp10.v1, tmp10.v2, tmp10.v3
            del tmp10
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp11 = method6(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp11.v0, tmp11.v1, tmp11.v2, tmp11.v3, tmp11.v4
            del tmp11
            return Tuple2(v40, v41, v42, v51, v52, (<signed char>3))
        else:
            v56 = v1 - (<signed char>1)
            return method14(v0, v56)
    else:
        v69 = (<signed char>12)
        return method15(v0, v69)
cdef Tuple2 method13(unsigned long long v0, signed char v1):
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
    cdef Tuple4 tmp5
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
    cdef Tuple4 tmp6
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
    cdef Tuple4 tmp7
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
    cdef Tuple4 tmp8
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
    cdef Tuple4 tmp9
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
            tmp5 = method9(v0, v157, v162, v158, v159, v160, v161, v163)
            v164, v165, v166, v167 = tmp5.v0, tmp5.v1, tmp5.v2, tmp5.v3
            del tmp5
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
            tmp6 = method9(v0, v171, v176, v172, v173, v174, v175, v177)
            v178, v179, v180, v181 = tmp6.v0, tmp6.v1, tmp6.v2, tmp6.v3
            del tmp6
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
            tmp7 = method9(v0, v185, v190, v186, v187, v188, v189, v191)
            v192, v193, v194, v195 = tmp7.v0, tmp7.v1, tmp7.v2, tmp7.v3
            del tmp7
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
            tmp8 = method9(v0, v199, v204, v200, v201, v202, v203, v205)
            v206, v207, v208, v209 = tmp8.v0, tmp8.v1, tmp8.v2, tmp8.v3
            del tmp8
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
            tmp9 = method9(v0, v212, v217, v213, v214, v215, v216, v218)
            v219, v220, v221, v222 = tmp9.v0, tmp9.v1, tmp9.v2, tmp9.v3
            del tmp9
            return Tuple2(v164, v178, v192, v206, v219, (<signed char>4))
        else:
            v223 = v1 - (<signed char>1)
            return method13(v0, v223)
    else:
        v236 = (<signed char>12)
        return method14(v0, v236)
cdef Tuple2 method11(unsigned long long v0, signed char v1, unsigned char v2, unsigned char v3, unsigned char v4, unsigned char v5):
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
            return method12(v0, v39, v40, v41, v42, v43, v44, v45, v46)
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
                return method12(v0, v54, v55, v56, v57, v58, v59, v60, v61)
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
                    return method12(v0, v69, v70, v71, v72, v73, v74, v75, v76)
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
                        return method12(v0, v84, v85, v86, v87, v88, v89, v90, v91)
                    else:
                        v98 = v1 - (<signed char>1)
                        return method11(v0, v98, v37, v29, v21, v13)
    else:
        v129 = (<signed char>8)
        return method13(v0, v129)
cdef Tuple2 method10(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5):
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
    cdef Tuple4 tmp4
    cdef signed char v56
    cdef signed char v69
    cdef unsigned char v70
    cdef unsigned char v71
    cdef unsigned char v72
    cdef unsigned char v73
    v6 = v1 == v5
    if v6:
        v7 = v5 - (<signed char>1)
        return method10(v0, v1, v2, v3, v4, v7)
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
                tmp4 = method9(v0, v5, v50, v46, v47, v48, v49, v51)
                v52, v53, v54, v55 = tmp4.v0, tmp4.v1, tmp4.v2, tmp4.v3
                del tmp4
                return Tuple2(v4, v3, v2, v52, v53, (<signed char>6))
            else:
                v56 = v5 - (<signed char>1)
                return method10(v0, v1, v2, v3, v4, v56)
        else:
            v69 = (<signed char>12)
            v70 = (<unsigned char>0)
            v71 = (<unsigned char>0)
            v72 = (<unsigned char>0)
            v73 = (<unsigned char>0)
            return method11(v0, v69, v73, v72, v71, v70)
cdef Tuple2 method8(unsigned long long v0, signed char v1):
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
    cdef Tuple4 tmp3
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
            tmp3 = method9(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp3.v0, tmp3.v1, tmp3.v2, tmp3.v3
            del tmp3
            v44 = (<signed char>12)
            return method10(v0, v1, v42, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method8(v0, v51)
    else:
        v64 = (<signed char>12)
        v65 = (<unsigned char>0)
        v66 = (<unsigned char>0)
        v67 = (<unsigned char>0)
        v68 = (<unsigned char>0)
        return method11(v0, v64, v68, v67, v66, v65)
cdef Tuple2 method5(unsigned long long v0, signed char v1):
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
    cdef Tuple3 tmp2
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
            tmp2 = method6(v0, v1, v34, v35, v36, v37, v38, v39, v40)
            v41, v42, v43, v44, v45 = tmp2.v0, tmp2.v1, tmp2.v2, tmp2.v3, tmp2.v4
            del tmp2
            return Tuple2(v1, v9, v17, v25, v41, (<signed char>7))
        else:
            v46 = v1 - (<signed char>1)
            return method5(v0, v46)
    else:
        v59 = (<signed char>12)
        return method8(v0, v59)
cdef Tuple2 method3(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed char v3
    cdef signed char v10
    v2 = (<signed char>-1) <= v1
    if v2:
        v3 = (<signed char>0)
        return method4(v0, v1, v3)
    else:
        v10 = (<signed char>12)
        return method5(v0, v10)
cdef Tuple2 method1(signed char v0, signed char v1, numpy.ndarray[signed char,ndim=1] v2):
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef signed long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef signed short v9
    cdef unsigned long long tmp1
    cdef Mut1 v10
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
    tmp1 = len(v2)
    if <signed short>tmp1 != tmp1: raise Exception("The conversion to signed short failed.")
    v9 = <signed short>tmp1
    v10 = Mut1((<signed short>0), v8)
    while method2(v9, v10):
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
    return method3(v22, v23)
cdef Tuple2 method22(numpy.ndarray[signed char,ndim=1] v0):
    cdef signed short v1
    cdef unsigned long long tmp19
    cdef Mut1 v2
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
    tmp19 = len(v0)
    if <signed short>tmp19 != tmp19: raise Exception("The conversion to signed short failed.")
    v1 = <signed short>tmp19
    v2 = Mut1((<signed short>0), (<unsigned long long>0))
    while method2(v1, v2):
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
    return method3(v14, v15)
cdef UH1 method23(UH0 v0, UH1 v1):
    cdef US0 v2
    cdef UH0 v3
    cdef UH1 v4
    cdef US2 v9
    cdef signed char v5
    cdef US1 v7
    if v0.tag == 0: # Cons
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = method23(v3, v1)
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
cdef bint method24(signed short v0, Mut2 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef UH2 method25(UH1 v0, UH2 v1):
    cdef US2 v2
    cdef UH1 v3
    cdef UH2 v4
    cdef US3 v5
    if v0.tag == 0: # Cons
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = method25(v3, v1)
        del v3
        v5 = US3_3(v2)
        del v2
        return UH2_0(v5, v4)
    elif v0.tag == 1: # Nil
        return v1
cdef unsigned long long method26(UH1 v0, unsigned long long v1) except *:
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # Cons
        v3 = (<UH1_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method26(v3, v4)
    elif v0.tag == 1: # Nil
        return v1
cdef unsigned long long method27(UH2 v0, unsigned long long v1) except *:
    cdef UH2 v3
    cdef unsigned long long v4
    if v0.tag == 0: # Cons
        v3 = (<UH2_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method27(v3, v4)
    elif v0.tag == 1: # Nil
        return v1
cdef bint method28(unsigned long long v0, Mut3 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef signed short method31(numpy.ndarray[float,ndim=1] v0, signed short v1, signed short v2, signed short v3) except *:
    cdef bint v4
    cdef signed short v5
    cdef signed short v6
    cdef signed short v7
    cdef signed long v8
    cdef signed short v9
    cdef signed short v10
    cdef signed short v11
    cdef signed short v12
    cdef float v13
    cdef signed short v14
    v4 = v2 < (<signed short>16)
    if v4:
        v5 = v2 + (<signed short>1)
        v6 = (<signed short>16) - v2
        v7 = v6 - (<signed short>1)
        v8 = <signed long>v7
        v9 = (<signed short>1) << v8
        v10 = <signed short>v2
        v11 = v1 + v10
        v12 = v3 // v9
        v13 = <float>v12
        v0[v11] = v13
        v14 = v3 % v9
        return method31(v0, v1, v5, v14)
    else:
        return v3
cdef void method30(signed short v0, numpy.ndarray[float,ndim=1] v1, signed short v2) except *:
    cdef signed long v3
    cdef signed long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef bint v8
    cdef bint v11
    cdef unsigned long long v9
    cdef signed short v12
    cdef signed short v13
    cdef signed short v14
    cdef str v15
    v3 = <signed long>(<signed short>16)
    v4 = v3 - (<signed long>1)
    v5 = (<unsigned long long>1) << v4
    v6 = v5 - (<unsigned long long>1)
    v7 = v5 + v6
    v8 = (<signed short>0) <= v0
    if v8:
        v9 = <unsigned long long>v0
        v11 = v9 < v7
    else:
        v11 = 0
    if v11:
        v12 = v0 + (<signed short>1)
        v13 = (<signed short>0)
        v14 = method31(v1, v2, v13, v12)
    else:
        v15 = f'Pickle failure. Bin int value out of bounds. Got: {v0} Size: {(<signed short>16)}'
        raise Exception(v15)
cdef unsigned long long method29(numpy.ndarray[float,ndim=3] v0, unsigned long long v1, UH1 v2, unsigned long long v3) except *:
    cdef US2 v4
    cdef UH1 v5
    cdef numpy.ndarray[float,ndim=1] v6
    cdef US1 v7
    cdef signed short v8
    cdef signed short v9
    cdef signed char v10
    cdef signed char v11
    cdef signed char v12
    cdef bint v13
    cdef bint v16
    cdef signed short v14
    cdef signed short v17
    cdef signed short v18
    cdef str v19
    cdef bint v20
    cdef bint v23
    cdef signed short v21
    cdef signed short v24
    cdef signed short v25
    cdef str v26
    cdef signed char v27
    cdef signed char v28
    cdef signed short v29
    cdef bint v30
    cdef bint v33
    cdef signed short v31
    cdef signed short v34
    cdef signed short v35
    cdef str v36
    cdef bint v37
    cdef bint v40
    cdef signed short v38
    cdef signed short v41
    cdef signed short v42
    cdef str v43
    cdef signed short v44
    cdef unsigned long long v45
    if v2.tag == 0: # Cons
        v4 = (<UH1_0>v2).v0; v5 = (<UH1_0>v2).v1
        v6 = v0[v1,v3]
        if v4.tag == 0: # PAction
            v7 = (<US2_0>v4).v0
            if v7.tag == 0: # Call
                v6[(<signed short>0)] = (<float>1)
            elif v7.tag == 1: # Fold
                v6[(<signed short>1)] = (<float>1)
            elif v7.tag == 2: # RaiseTo
                v8 = (<US1_2>v7).v0
                v9 = (<signed short>2)
                method30(v8, v6, v9)
            del v7
        elif v4.tag == 1: # PCardPresent
            v10 = (<US2_1>v4).v0
            v11 = v10 // (<signed char>13)
            v12 = v10 % (<signed char>13)
            v13 = (<signed char>0) <= v11
            if v13:
                v14 = <signed short>v11
                v16 = v14 < (<signed short>4)
            else:
                v16 = 0
            if v16:
                v17 = <signed short>v11
                v18 = (<signed short>18) + v17
                v6[v18] = (<float>1)
            else:
                v19 = f'Pickle failure. Int value out of bounds. Got: {v11} Size: {(<signed short>4)}'
                raise Exception(v19)
            v20 = (<signed char>0) <= v12
            if v20:
                v21 = <signed short>v12
                v23 = v21 < (<signed short>13)
            else:
                v23 = 0
            if v23:
                v24 = <signed short>v12
                v25 = (<signed short>22) + v24
                v6[v25] = (<float>1)
            else:
                v26 = f'Pickle failure. Int value out of bounds. Got: {v12} Size: {(<signed short>13)}'
                raise Exception(v26)
        elif v4.tag == 2: # PInfo
            v27 = (<US2_2>v4).v0; v28 = (<US2_2>v4).v1; v29 = (<US2_2>v4).v2
            v30 = (<signed char>0) <= v27
            if v30:
                v31 = <signed short>v27
                v33 = v31 < (<signed short>9)
            else:
                v33 = 0
            if v33:
                v34 = <signed short>v27
                v35 = (<signed short>35) + v34
                v6[v35] = (<float>1)
            else:
                v36 = f'Pickle failure. Int value out of bounds. Got: {v27} Size: {(<signed short>9)}'
                raise Exception(v36)
            v37 = (<signed char>0) <= v28
            if v37:
                v38 = <signed short>v28
                v40 = v38 < (<signed short>9)
            else:
                v40 = 0
            if v40:
                v41 = <signed short>v28
                v42 = (<signed short>44) + v41
                v6[v42] = (<float>1)
            else:
                v43 = f'Pickle failure. Int value out of bounds. Got: {v28} Size: {(<signed short>9)}'
                raise Exception(v43)
            v44 = (<signed short>53)
            method30(v29, v6, v44)
        del v4; del v6
        v45 = v3 + (<unsigned long long>1)
        return method29(v0, v1, v5, v45)
    elif v2.tag == 1: # Nil
        return v3
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
cdef unsigned long long method33(numpy.ndarray[float,ndim=3] v0, unsigned long long v1, UH2 v2, unsigned long long v3) except *:
    cdef US3 v4
    cdef UH2 v5
    cdef numpy.ndarray[float,ndim=1] v6
    cdef signed char v7
    cdef signed char v8
    cdef signed char v9
    cdef bint v10
    cdef bint v13
    cdef signed short v11
    cdef signed short v14
    cdef str v15
    cdef bint v16
    cdef bint v19
    cdef signed short v17
    cdef signed short v20
    cdef signed short v21
    cdef str v22
    cdef signed char v23
    cdef signed char v24
    cdef signed char v25
    cdef bint v26
    cdef bint v29
    cdef signed short v27
    cdef signed short v30
    cdef signed short v31
    cdef str v32
    cdef bint v33
    cdef bint v36
    cdef signed short v34
    cdef signed short v37
    cdef signed short v38
    cdef str v39
    cdef signed long v40
    cdef signed char v41
    cdef signed char v42
    cdef bint v43
    cdef bint v46
    cdef signed short v44
    cdef signed short v47
    cdef signed short v48
    cdef str v49
    cdef bint v50
    cdef bint v53
    cdef signed short v51
    cdef signed short v54
    cdef signed short v55
    cdef str v56
    cdef signed long v57
    cdef bint v58
    cdef bint v61
    cdef signed short v59
    cdef signed short v62
    cdef signed short v63
    cdef str v64
    cdef US2 v65
    cdef US1 v66
    cdef signed short v67
    cdef signed short v68
    cdef signed char v69
    cdef signed char v70
    cdef signed char v71
    cdef bint v72
    cdef bint v75
    cdef signed short v73
    cdef signed short v76
    cdef signed short v77
    cdef str v78
    cdef bint v79
    cdef bint v82
    cdef signed short v80
    cdef signed short v83
    cdef signed short v84
    cdef str v85
    cdef signed char v86
    cdef signed char v87
    cdef signed short v88
    cdef bint v89
    cdef bint v92
    cdef signed short v90
    cdef signed short v93
    cdef signed short v94
    cdef str v95
    cdef bint v96
    cdef bint v99
    cdef signed short v97
    cdef signed short v100
    cdef signed short v101
    cdef str v102
    cdef signed short v103
    cdef unsigned long long v104
    if v2.tag == 0: # Cons
        v4 = (<UH2_0>v2).v0; v5 = (<UH2_0>v2).v1
        v6 = v0[v1,v3]
        if v4.tag == 0: # VCardFuture
            v7 = (<US3_0>v4).v0
            v8 = v7 // (<signed char>13)
            v9 = v7 % (<signed char>13)
            v10 = (<signed char>0) <= v8
            if v10:
                v11 = <signed short>v8
                v13 = v11 < (<signed short>4)
            else:
                v13 = 0
            if v13:
                v14 = <signed short>v8
                v6[v14] = (<float>1)
            else:
                v15 = f'Pickle failure. Int value out of bounds. Got: {v8} Size: {(<signed short>4)}'
                raise Exception(v15)
            v16 = (<signed char>0) <= v9
            if v16:
                v17 = <signed short>v9
                v19 = v17 < (<signed short>13)
            else:
                v19 = 0
            if v19:
                v20 = <signed short>v9
                v21 = (<signed short>4) + v20
                v6[v21] = (<float>1)
            else:
                v22 = f'Pickle failure. Int value out of bounds. Got: {v9} Size: {(<signed short>13)}'
                raise Exception(v22)
        elif v4.tag == 1: # VCardOpponent
            v23 = (<US3_1>v4).v0
            v24 = v23 // (<signed char>13)
            v25 = v23 % (<signed char>13)
            v26 = (<signed char>0) <= v24
            if v26:
                v27 = <signed short>v24
                v29 = v27 < (<signed short>4)
            else:
                v29 = 0
            if v29:
                v30 = <signed short>v24
                v31 = (<signed short>17) + v30
                v6[v31] = (<float>1)
            else:
                v32 = f'Pickle failure. Int value out of bounds. Got: {v24} Size: {(<signed short>4)}'
                raise Exception(v32)
            v33 = (<signed char>0) <= v25
            if v33:
                v34 = <signed short>v25
                v36 = v34 < (<signed short>13)
            else:
                v36 = 0
            if v36:
                v37 = <signed short>v25
                v38 = (<signed short>21) + v37
                v6[v38] = (<float>1)
            else:
                v39 = f'Pickle failure. Int value out of bounds. Got: {v25} Size: {(<signed short>13)}'
                raise Exception(v39)
        elif v4.tag == 2: # VInfo
            v40 = (<US3_2>v4).v0; v41 = (<US3_2>v4).v1; v42 = (<US3_2>v4).v2
            v43 = (<signed char>0) <= v42
            if v43:
                v44 = <signed short>v42
                v46 = v44 < (<signed short>9)
            else:
                v46 = 0
            if v46:
                v47 = <signed short>v42
                v48 = (<signed short>34) + v47
                v6[v48] = (<float>1)
            else:
                v49 = f'Pickle failure. Int value out of bounds. Got: {v42} Size: {(<signed short>9)}'
                raise Exception(v49)
            v50 = (<signed char>0) <= v41
            if v50:
                v51 = <signed short>v41
                v53 = v51 < (<signed short>9)
            else:
                v53 = 0
            if v53:
                v54 = <signed short>v41
                v55 = (<signed short>43) + v54
                v6[v55] = (<float>1)
            else:
                v56 = f'Pickle failure. Int value out of bounds. Got: {v41} Size: {(<signed short>9)}'
                raise Exception(v56)
            v57 = v40 + (<signed long>1)
            v58 = (<signed long>0) <= v57
            if v58:
                v59 = <signed short>v57
                v61 = v59 < (<signed short>3)
            else:
                v61 = 0
            if v61:
                v62 = <signed short>v57
                v63 = (<signed short>52) + v62
                v6[v63] = (<float>1)
            else:
                v64 = f'Pickle failure. Int value out of bounds. Got: {v57} Size: {(<signed short>3)}'
                raise Exception(v64)
        elif v4.tag == 3: # VPolicy
            v65 = (<US3_3>v4).v0
            if v65.tag == 0: # PAction
                v66 = (<US2_0>v65).v0
                if v66.tag == 0: # Call
                    v6[(<signed short>55)] = (<float>1)
                elif v66.tag == 1: # Fold
                    v6[(<signed short>56)] = (<float>1)
                elif v66.tag == 2: # RaiseTo
                    v67 = (<US1_2>v66).v0
                    v68 = (<signed short>57)
                    method30(v67, v6, v68)
                del v66
            elif v65.tag == 1: # PCardPresent
                v69 = (<US2_1>v65).v0
                v70 = v69 // (<signed char>13)
                v71 = v69 % (<signed char>13)
                v72 = (<signed char>0) <= v70
                if v72:
                    v73 = <signed short>v70
                    v75 = v73 < (<signed short>4)
                else:
                    v75 = 0
                if v75:
                    v76 = <signed short>v70
                    v77 = (<signed short>73) + v76
                    v6[v77] = (<float>1)
                else:
                    v78 = f'Pickle failure. Int value out of bounds. Got: {v70} Size: {(<signed short>4)}'
                    raise Exception(v78)
                v79 = (<signed char>0) <= v71
                if v79:
                    v80 = <signed short>v71
                    v82 = v80 < (<signed short>13)
                else:
                    v82 = 0
                if v82:
                    v83 = <signed short>v71
                    v84 = (<signed short>77) + v83
                    v6[v84] = (<float>1)
                else:
                    v85 = f'Pickle failure. Int value out of bounds. Got: {v71} Size: {(<signed short>13)}'
                    raise Exception(v85)
            elif v65.tag == 2: # PInfo
                v86 = (<US2_2>v65).v0; v87 = (<US2_2>v65).v1; v88 = (<US2_2>v65).v2
                v89 = (<signed char>0) <= v86
                if v89:
                    v90 = <signed short>v86
                    v92 = v90 < (<signed short>9)
                else:
                    v92 = 0
                if v92:
                    v93 = <signed short>v86
                    v94 = (<signed short>90) + v93
                    v6[v94] = (<float>1)
                else:
                    v95 = f'Pickle failure. Int value out of bounds. Got: {v86} Size: {(<signed short>9)}'
                    raise Exception(v95)
                v96 = (<signed char>0) <= v87
                if v96:
                    v97 = <signed short>v87
                    v99 = v97 < (<signed short>9)
                else:
                    v99 = 0
                if v99:
                    v100 = <signed short>v87
                    v101 = (<signed short>99) + v100
                    v6[v101] = (<float>1)
                else:
                    v102 = f'Pickle failure. Int value out of bounds. Got: {v87} Size: {(<signed short>9)}'
                    raise Exception(v102)
                v103 = (<signed short>108)
                method30(v88, v6, v103)
            del v65
        del v4; del v6
        v104 = v3 + (<unsigned long long>1)
        return method33(v0, v1, v5, v104)
    elif v2.tag == 1: # Nil
        return v3
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
    cdef Mut3 v4
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef Mut4 v9
    v3 = numpy.empty(v1,dtype=object)
    v4 = Mut3((<unsigned long long>0))
    while method28(v1, v4):
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
    cdef Mut3 v8
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
    v8 = Mut3((<unsigned long long>0))
    while method28(v5, v8):
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
cdef unsigned short method56(unsigned long long v0, signed char v1, signed char v2, unsigned short v3) except *:
    cdef bint v4
    cdef signed char v5
    cdef signed char v6
    cdef signed char v7
    cdef signed long v8
    cdef unsigned long long v9
    cdef unsigned char v10
    cdef unsigned char v11
    cdef unsigned char v12
    cdef unsigned short v13
    cdef unsigned char v14
    cdef signed long v15
    cdef unsigned short v16
    cdef unsigned short v17
    v4 = v2 < (<signed char>4)
    if v4:
        v5 = v2 + (<signed char>1)
        v6 = v2 * (<signed char>13)
        v7 = v6 + v1
        v8 = <signed long>v7
        v9 = v0 >> v8
        v10 = <unsigned char>v9
        v11 = v10 & (<unsigned char>1)
        v12 = <unsigned char>v2
        v13 = <unsigned short>v11
        v14 = (<unsigned char>4) * v12
        v15 = <signed long>v14
        v16 = v13 << v15
        v17 = v3 + v16
        return method56(v0, v1, v5, v17)
    else:
        return v3
cdef unsigned short method55(unsigned long long v0, signed char v1, unsigned short v2) except *:
    cdef bint v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned short v6
    v3 = v1 < (<signed char>13)
    if v3:
        v4 = v1 + (<signed char>1)
        v5 = (<signed char>0)
        v6 = method56(v0, v1, v5, v2)
        return method55(v0, v4, v6)
    else:
        return v2
cdef unsigned long long method58(unsigned long long v0, signed char v1, signed char v2, unsigned long long v3) except *:
    cdef bint v4
    cdef signed char v5
    cdef signed char v6
    cdef signed char v7
    cdef signed long v8
    cdef unsigned long long v9
    cdef unsigned char v10
    cdef unsigned char v11
    cdef unsigned char v12
    cdef unsigned long long v13
    cdef unsigned char v14
    cdef signed long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    v4 = v2 < (<signed char>4)
    if v4:
        v5 = v2 + (<signed char>1)
        v6 = v2 * (<signed char>13)
        v7 = v6 + v1
        v8 = <signed long>v7
        v9 = v0 >> v8
        v10 = <unsigned char>v9
        v11 = v10 & (<unsigned char>1)
        v12 = <unsigned char>v1
        v13 = <unsigned long long>v11
        v14 = (<unsigned char>3) * v12
        v15 = <signed long>v14
        v16 = v13 << v15
        v17 = v3 + v16
        return method58(v0, v1, v5, v17)
    else:
        return v3
cdef unsigned long long method57(unsigned long long v0, signed char v1, unsigned long long v2) except *:
    cdef bint v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned long long v6
    v3 = v1 < (<signed char>13)
    if v3:
        v4 = v1 + (<signed char>1)
        v5 = (<signed char>0)
        v6 = method58(v0, v1, v5, v2)
        return method57(v0, v4, v6)
    else:
        return v2
cdef unsigned long method60(unsigned long long v0, signed char v1, signed char v2) except *:
    cdef bint v3
    cdef signed char v4
    cdef signed char v5
    cdef signed char v6
    cdef signed long v7
    cdef unsigned long long v8
    cdef unsigned char v9
    cdef unsigned char v10
    cdef signed char v11
    cdef signed char v12
    cdef signed long v13
    cdef unsigned long long v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef unsigned char v17
    cdef signed char v18
    cdef signed char v19
    cdef signed long v20
    cdef unsigned long long v21
    cdef unsigned char v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed char v26
    cdef signed long v27
    cdef unsigned long long v28
    cdef unsigned char v29
    cdef unsigned char v30
    cdef unsigned char v31
    cdef bint v32
    cdef signed char v34
    cdef signed char v35
    cdef signed long v36
    cdef unsigned long long v37
    cdef unsigned char v38
    cdef unsigned char v39
    cdef unsigned char v40
    cdef bint v41
    cdef unsigned long v42
    cdef unsigned long v43
    cdef unsigned long v44
    cdef unsigned long v45
    cdef unsigned long v46
    cdef unsigned long v47
    cdef unsigned long v48
    cdef unsigned long v49
    cdef unsigned long v50
    cdef unsigned long v51
    cdef signed char v53
    cdef unsigned long v54
    cdef unsigned long v55
    cdef signed char v57
    v3 = (<signed char>-1) <= v2
    if v3:
        v4 = v2 + (<signed char>4)
        v5 = v1 * (<signed char>13)
        v6 = v5 + v4
        v7 = <signed long>v6
        v8 = v0 >> v7
        v9 = <unsigned char>v8
        v10 = v9 & (<unsigned char>1)
        v11 = v2 + (<signed char>3)
        v12 = v5 + v11
        v13 = <signed long>v12
        v14 = v0 >> v13
        v15 = <unsigned char>v14
        v16 = v15 & (<unsigned char>1)
        v17 = v10 & v16
        v18 = v2 + (<signed char>2)
        v19 = v5 + v18
        v20 = <signed long>v19
        v21 = v0 >> v20
        v22 = <unsigned char>v21
        v23 = v22 & (<unsigned char>1)
        v24 = v17 & v23
        v25 = v2 + (<signed char>1)
        v26 = v5 + v25
        v27 = <signed long>v26
        v28 = v0 >> v27
        v29 = <unsigned char>v28
        v30 = v29 & (<unsigned char>1)
        v31 = v24 & v30
        v32 = v2 < (<signed char>0)
        if v32:
            v34 = v2 + (<signed char>13)
        else:
            v34 = v2
        v35 = v5 + v34
        v36 = <signed long>v35
        v37 = v0 >> v36
        v38 = <unsigned char>v37
        v39 = v38 & (<unsigned char>1)
        v40 = v31 & v39
        v41 = <bint>v40
        if v41:
            v42 = <unsigned long>v4
            v43 = v42 << (<signed long>6)
            v44 = <unsigned long>v11
            v45 = v43 + v44
            v46 = v45 << (<signed long>6)
            v47 = <unsigned long>v18
            v48 = v46 + v47
            v49 = v48 << (<signed long>6)
            v50 = <unsigned long>v25
            v51 = v49 + v50
            if v32:
                v53 = v2 + (<signed char>13)
            else:
                v53 = v2
            v54 = v51 << (<signed long>6)
            v55 = <unsigned long>v53
            return v54 + v55
        else:
            v57 = v2 - (<signed char>1)
            return method60(v0, v1, v57)
    else:
        return (<unsigned long>0)
cdef unsigned long method59(unsigned long long v0, unsigned short v1, signed char v2) except *:
    cdef signed char v3
    cdef signed long v4
    cdef unsigned short v5
    cdef signed char v6
    cdef signed char v7
    cdef bint v8
    cdef signed char v9
    v3 = (<signed char>4) * v2
    v4 = <signed long>v3
    v5 = v1 >> v4
    v6 = <signed char>v5
    v7 = v6 & (<signed char>15)
    v8 = (<signed char>5) <= v7
    if v8:
        v9 = (<signed char>8)
        return method60(v0, v2, v9)
    else:
        return (<unsigned long>0)
cdef unsigned long method62(unsigned long long v0, signed char v1, signed char v2, signed char v3, unsigned long v4) except *:
    cdef bint v5
    cdef bint v7
    cdef signed char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned char v12
    cdef unsigned char v13
    cdef bint v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned long v17
    cdef unsigned long v18
    cdef unsigned long v19
    cdef signed char v21
    v5 = v2 < (<signed char>4)
    if v5:
        v7 = (<signed char>0) < v3
    else:
        v7 = 0
    if v7:
        v8 = v2 * (<signed char>13)
        v9 = v8 + v1
        v10 = <signed long>v9
        v11 = v0 >> v10
        v12 = <unsigned char>v11
        v13 = v12 & (<unsigned char>1)
        v14 = <bint>v13
        if v14:
            v15 = v2 + (<signed char>1)
            v16 = v3 - (<signed char>1)
            v17 = v4 << (<signed long>6)
            v18 = <unsigned long>v1
            v19 = v17 + v18
            return method62(v0, v1, v15, v16, v19)
        else:
            v21 = v2 + (<signed char>1)
            return method62(v0, v1, v21, v3, v4)
    else:
        return v4
cdef unsigned long method64(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, unsigned long v5) except *:
    cdef bint v6
    cdef bint v7
    cdef signed char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned char v12
    cdef unsigned char v13
    cdef bint v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned long v17
    cdef unsigned long v18
    cdef unsigned long v19
    cdef signed char v21
    cdef signed char v24
    v6 = (<signed char>0) < v4
    if v6:
        v7 = v3 < (<signed char>4)
        if v7:
            v8 = v3 * (<signed char>13)
            v9 = v8 + v2
            v10 = <signed long>v9
            v11 = v0 >> v10
            v12 = <unsigned char>v11
            v13 = v12 & (<unsigned char>1)
            v14 = <bint>v13
            if v14:
                v15 = v3 + (<signed char>1)
                v16 = v4 - (<signed char>1)
                v17 = v5 << (<signed long>6)
                v18 = <unsigned long>v2
                v19 = v17 + v18
                return method64(v0, v1, v2, v15, v16, v19)
            else:
                v21 = v3 + (<signed char>1)
                return method64(v0, v1, v2, v21, v4, v5)
        else:
            v24 = v2 - (<signed char>1)
            return method63(v0, v1, v24, v4, v5)
    else:
        return v5
cdef unsigned long method63(unsigned long long v0, signed char v1, signed char v2, signed char v3, unsigned long v4) except *:
    cdef bint v5
    cdef bint v6
    cdef signed char v7
    cdef signed char v9
    v5 = (<signed char>0) <= v2
    if v5:
        v6 = v1 == v2
        if v6:
            v7 = v2 - (<signed char>1)
            return method63(v0, v1, v7, v3, v4)
        else:
            v9 = (<signed char>0)
            return method64(v0, v1, v2, v9, v3, v4)
    else:
        return v4
cdef unsigned long method68(unsigned long long v0, signed char v1, signed char v2, signed char v3, unsigned long v4) except *:
    cdef bint v5
    cdef bint v7
    cdef signed char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned char v12
    cdef unsigned char v13
    cdef bint v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned long v17
    cdef unsigned long v18
    cdef unsigned long v19
    cdef signed char v21
    v5 = (<signed char>0) <= v2
    if v5:
        v7 = (<signed char>0) < v3
    else:
        v7 = 0
    if v7:
        v8 = v1 * (<signed char>13)
        v9 = v8 + v2
        v10 = <signed long>v9
        v11 = v0 >> v10
        v12 = <unsigned char>v11
        v13 = v12 & (<unsigned char>1)
        v14 = <bint>v13
        if v14:
            v15 = v2 - (<signed char>1)
            v16 = v3 - (<signed char>1)
            v17 = v4 << (<signed long>6)
            v18 = <unsigned long>v2
            v19 = v17 + v18
            return method68(v0, v1, v15, v16, v19)
        else:
            v21 = v2 - (<signed char>1)
            return method68(v0, v1, v21, v3, v4)
    else:
        return v4
cdef unsigned long method67(unsigned long long v0, unsigned short v1, signed char v2) except *:
    cdef signed char v3
    cdef signed long v4
    cdef unsigned short v5
    cdef signed char v6
    cdef signed char v7
    cdef bint v8
    cdef signed char v9
    cdef signed char v10
    cdef unsigned long v11
    v3 = (<signed char>4) * v2
    v4 = <signed long>v3
    v5 = v1 >> v4
    v6 = <signed char>v5
    v7 = v6 & (<signed char>15)
    v8 = (<signed char>5) <= v7
    if v8:
        v9 = (<signed char>12)
        v10 = (<signed char>5)
        v11 = (<unsigned long>0)
        return method68(v0, v2, v9, v10, v11)
    else:
        return (<unsigned long>0)
cdef unsigned long method74(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, unsigned long v6) except *:
    cdef bint v7
    cdef bint v8
    cdef signed char v9
    cdef signed char v10
    cdef signed long v11
    cdef unsigned long long v12
    cdef unsigned char v13
    cdef unsigned char v14
    cdef bint v15
    cdef signed char v16
    cdef signed char v17
    cdef unsigned long v18
    cdef unsigned long v19
    cdef unsigned long v20
    cdef signed char v22
    cdef signed char v25
    v7 = (<signed char>0) < v5
    if v7:
        v8 = v4 < (<signed char>4)
        if v8:
            v9 = v4 * (<signed char>13)
            v10 = v9 + v3
            v11 = <signed long>v10
            v12 = v0 >> v11
            v13 = <unsigned char>v12
            v14 = v13 & (<unsigned char>1)
            v15 = <bint>v14
            if v15:
                v16 = v4 + (<signed char>1)
                v17 = v5 - (<signed char>1)
                v18 = v6 << (<signed long>6)
                v19 = <unsigned long>v3
                v20 = v18 + v19
                return method74(v0, v1, v2, v3, v16, v17, v20)
            else:
                v22 = v4 + (<signed char>1)
                return method74(v0, v1, v2, v3, v22, v5, v6)
        else:
            v25 = v3 - (<signed char>1)
            return method73(v0, v1, v2, v25, v5, v6)
    else:
        return v6
cdef unsigned long method73(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, unsigned long v5) except *:
    cdef bint v6
    cdef bint v7
    cdef bint v9
    cdef signed char v10
    cdef signed char v12
    v6 = (<signed char>0) <= v3
    if v6:
        v7 = v1 == v3
        if v7:
            v9 = 1
        else:
            v9 = v2 == v3
        if v9:
            v10 = v3 - (<signed char>1)
            return method73(v0, v1, v2, v10, v4, v5)
        else:
            v12 = (<signed char>0)
            return method74(v0, v1, v2, v3, v12, v4, v5)
    else:
        return v5
cdef unsigned long method77(unsigned long long v0, signed char v1, signed char v2, signed char v3, unsigned long v4) except *:
    cdef bint v5
    cdef bint v6
    cdef signed char v7
    cdef signed char v8
    cdef signed long v9
    cdef unsigned long long v10
    cdef unsigned char v11
    cdef unsigned char v12
    cdef bint v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned long v16
    cdef unsigned long v17
    cdef unsigned long v18
    cdef signed char v20
    cdef signed char v23
    v5 = (<signed char>0) < v3
    if v5:
        v6 = v2 < (<signed char>4)
        if v6:
            v7 = v2 * (<signed char>13)
            v8 = v7 + v1
            v9 = <signed long>v8
            v10 = v0 >> v9
            v11 = <unsigned char>v10
            v12 = v11 & (<unsigned char>1)
            v13 = <bint>v12
            if v13:
                v14 = v2 + (<signed char>1)
                v15 = v3 - (<signed char>1)
                v16 = v4 << (<signed long>6)
                v17 = <unsigned long>v1
                v18 = v16 + v17
                return method77(v0, v1, v14, v15, v18)
            else:
                v20 = v2 + (<signed char>1)
                return method77(v0, v1, v20, v3, v4)
        else:
            v23 = v1 - (<signed char>1)
            return method76(v0, v23, v3, v4)
    else:
        return v4
cdef unsigned long method76(unsigned long long v0, signed char v1, signed char v2, unsigned long v3) except *:
    cdef bint v4
    cdef signed char v5
    v4 = (<signed char>0) <= v1
    if v4:
        v5 = (<signed char>0)
        return method77(v0, v1, v5, v2, v3)
    else:
        return v3
cdef unsigned long long method75(unsigned long long v0, unsigned long long v1, signed char v2) except *:
    cdef bint v3
    cdef signed char v4
    cdef signed long v5
    cdef unsigned long long v6
    cdef signed char v7
    cdef signed char v8
    cdef bint v9
    cdef signed char v10
    cdef signed char v11
    cdef unsigned long v12
    cdef unsigned long v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned long v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef signed char v21
    cdef signed char v24
    cdef signed char v25
    cdef unsigned long v26
    cdef unsigned long v27
    cdef unsigned long long v28
    cdef unsigned long long v29
    cdef unsigned long long v30
    cdef unsigned long long v31
    v3 = (<signed char>0) <= v2
    if v3:
        v4 = (<signed char>3) * v2
        v5 = <signed long>v4
        v6 = v0 >> v5
        v7 = <signed char>v6
        v8 = v7 & (<signed char>7)
        v9 = v8 == (<signed char>2)
        if v9:
            v10 = (<signed char>0)
            v11 = (<signed char>2)
            v12 = (<unsigned long>0)
            v13 = method62(v1, v2, v10, v11, v12)
            v14 = (<signed char>12)
            v15 = (<signed char>3)
            v16 = method63(v1, v2, v14, v15, v13)
            v17 = <unsigned long long>(<signed char>1)
            v18 = v17 << (<signed long>32)
            v19 = <unsigned long long>v16
            v20 = v18 | v19
            return v20
        else:
            v21 = v2 - (<signed char>1)
            return method75(v0, v1, v21)
    else:
        v24 = (<signed char>12)
        v25 = (<signed char>5)
        v26 = (<unsigned long>0)
        v27 = method76(v1, v24, v25, v26)
        v28 = <unsigned long long>(<signed char>0)
        v29 = v28 << (<signed long>32)
        v30 = <unsigned long long>v27
        v31 = v29 | v30
        return v31
cdef unsigned long long method72(unsigned long long v0, unsigned long long v1, signed char v2, unsigned long v3, signed char v4) except *:
    cdef bint v5
    cdef signed char v6
    cdef bint v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef signed char v12
    cdef signed char v13
    cdef bint v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned long v17
    cdef signed char v18
    cdef signed char v19
    cdef unsigned long v20
    cdef unsigned long long v21
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef signed char v25
    cdef signed char v28
    v5 = v2 == v4
    if v5:
        v6 = v4 - (<signed char>1)
        return method72(v0, v1, v2, v3, v6)
    else:
        v8 = (<signed char>0) <= v4
        if v8:
            v9 = (<signed char>3) * v4
            v10 = <signed long>v9
            v11 = v0 >> v10
            v12 = <signed char>v11
            v13 = v12 & (<signed char>7)
            v14 = v13 == (<signed char>2)
            if v14:
                v15 = (<signed char>0)
                v16 = (<signed char>2)
                v17 = method62(v1, v4, v15, v16, v3)
                v18 = (<signed char>12)
                v19 = (<signed char>1)
                v20 = method73(v1, v2, v4, v18, v19, v17)
                v21 = <unsigned long long>(<signed char>2)
                v22 = v21 << (<signed long>32)
                v23 = <unsigned long long>v20
                v24 = v22 | v23
                return v24
            else:
                v25 = v4 - (<signed char>1)
                return method72(v0, v1, v2, v3, v25)
        else:
            v28 = (<signed char>12)
            return method75(v0, v1, v28)
cdef unsigned long long method71(unsigned long long v0, unsigned long long v1, signed char v2) except *:
    cdef bint v3
    cdef signed char v4
    cdef signed long v5
    cdef unsigned long long v6
    cdef signed char v7
    cdef signed char v8
    cdef bint v9
    cdef signed char v10
    cdef signed char v11
    cdef unsigned long v12
    cdef unsigned long v13
    cdef signed char v14
    cdef signed char v16
    cdef signed char v19
    v3 = (<signed char>0) <= v2
    if v3:
        v4 = (<signed char>3) * v2
        v5 = <signed long>v4
        v6 = v0 >> v5
        v7 = <signed char>v6
        v8 = v7 & (<signed char>7)
        v9 = v8 == (<signed char>2)
        if v9:
            v10 = (<signed char>0)
            v11 = (<signed char>2)
            v12 = (<unsigned long>0)
            v13 = method62(v1, v2, v10, v11, v12)
            v14 = (<signed char>12)
            return method72(v0, v1, v2, v13, v14)
        else:
            v16 = v2 - (<signed char>1)
            return method71(v0, v1, v16)
    else:
        v19 = (<signed char>12)
        return method75(v0, v1, v19)
cdef unsigned long long method70(unsigned long long v0, unsigned long long v1, signed char v2) except *:
    cdef bint v3
    cdef signed char v4
    cdef signed long v5
    cdef unsigned long long v6
    cdef signed char v7
    cdef signed char v8
    cdef bint v9
    cdef signed char v10
    cdef signed char v11
    cdef unsigned long v12
    cdef unsigned long v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned long v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef signed char v21
    cdef signed char v24
    v3 = (<signed char>0) <= v2
    if v3:
        v4 = (<signed char>3) * v2
        v5 = <signed long>v4
        v6 = v0 >> v5
        v7 = <signed char>v6
        v8 = v7 & (<signed char>7)
        v9 = v8 == (<signed char>3)
        if v9:
            v10 = (<signed char>0)
            v11 = (<signed char>3)
            v12 = (<unsigned long>0)
            v13 = method62(v1, v2, v10, v11, v12)
            v14 = (<signed char>12)
            v15 = (<signed char>2)
            v16 = method63(v1, v2, v14, v15, v13)
            v17 = <unsigned long long>(<signed char>3)
            v18 = v17 << (<signed long>32)
            v19 = <unsigned long long>v16
            v20 = v18 | v19
            return v20
        else:
            v21 = v2 - (<signed char>1)
            return method70(v0, v1, v21)
    else:
        v24 = (<signed char>12)
        return method71(v0, v1, v24)
cdef unsigned long long method69(unsigned long long v0, unsigned long long v1, signed char v2) except *:
    cdef bint v3
    cdef signed char v4
    cdef signed char v5
    cdef signed long v6
    cdef unsigned long long v7
    cdef signed char v8
    cdef signed char v9
    cdef bint v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef signed long v14
    cdef unsigned long long v15
    cdef signed char v16
    cdef signed char v17
    cdef bint v18
    cdef signed char v19
    cdef signed char v20
    cdef signed char v21
    cdef signed char v22
    cdef signed long v23
    cdef unsigned long long v24
    cdef signed char v25
    cdef signed char v26
    cdef bint v27
    cdef signed char v28
    cdef signed char v29
    cdef signed char v30
    cdef signed char v31
    cdef signed long v32
    cdef unsigned long long v33
    cdef signed char v34
    cdef signed char v35
    cdef bint v36
    cdef signed char v37
    cdef signed char v38
    cdef bint v39
    cdef signed char v41
    cdef signed char v42
    cdef signed long v43
    cdef unsigned long long v44
    cdef signed char v45
    cdef signed char v46
    cdef bint v47
    cdef signed char v48
    cdef signed char v49
    cdef bint v50
    cdef signed char v51
    cdef signed char v52
    cdef unsigned long v53
    cdef unsigned long v54
    cdef signed char v55
    cdef signed char v56
    cdef unsigned long v57
    cdef signed char v58
    cdef signed char v59
    cdef unsigned long v60
    cdef signed char v61
    cdef signed char v62
    cdef unsigned long v63
    cdef signed char v65
    cdef signed char v66
    cdef signed char v67
    cdef unsigned long v68
    cdef unsigned long long v69
    cdef unsigned long long v70
    cdef unsigned long long v71
    cdef unsigned long long v72
    cdef signed char v73
    cdef signed char v76
    v3 = (<signed char>-1) <= v2
    if v3:
        v4 = v2 + (<signed char>4)
        v5 = (<signed char>3) * v4
        v6 = <signed long>v5
        v7 = v0 >> v6
        v8 = <signed char>v7
        v9 = v8 & (<signed char>7)
        v10 = (<signed char>0) < v9
        if v10:
            v11 = (<signed char>1)
        else:
            v11 = (<signed char>0)
        v12 = v2 + (<signed char>3)
        v13 = (<signed char>3) * v12
        v14 = <signed long>v13
        v15 = v0 >> v14
        v16 = <signed char>v15
        v17 = v16 & (<signed char>7)
        v18 = (<signed char>0) < v17
        if v18:
            v19 = (<signed char>1)
        else:
            v19 = (<signed char>0)
        v20 = v11 & v19
        v21 = v2 + (<signed char>2)
        v22 = (<signed char>3) * v21
        v23 = <signed long>v22
        v24 = v0 >> v23
        v25 = <signed char>v24
        v26 = v25 & (<signed char>7)
        v27 = (<signed char>0) < v26
        if v27:
            v28 = (<signed char>1)
        else:
            v28 = (<signed char>0)
        v29 = v20 & v28
        v30 = v2 + (<signed char>1)
        v31 = (<signed char>3) * v30
        v32 = <signed long>v31
        v33 = v0 >> v32
        v34 = <signed char>v33
        v35 = v34 & (<signed char>7)
        v36 = (<signed char>0) < v35
        if v36:
            v37 = (<signed char>1)
        else:
            v37 = (<signed char>0)
        v38 = v29 & v37
        v39 = v2 < (<signed char>0)
        if v39:
            v41 = v2 + (<signed char>13)
        else:
            v41 = v2
        v42 = (<signed char>3) * v41
        v43 = <signed long>v42
        v44 = v0 >> v43
        v45 = <signed char>v44
        v46 = v45 & (<signed char>7)
        v47 = (<signed char>0) < v46
        if v47:
            v48 = (<signed char>1)
        else:
            v48 = (<signed char>0)
        v49 = v38 & v48
        v50 = <bint>v49
        if v50:
            v51 = (<signed char>0)
            v52 = (<signed char>1)
            v53 = (<unsigned long>0)
            v54 = method62(v1, v4, v51, v52, v53)
            v55 = (<signed char>0)
            v56 = (<signed char>1)
            v57 = method62(v1, v12, v55, v56, v54)
            v58 = (<signed char>0)
            v59 = (<signed char>1)
            v60 = method62(v1, v21, v58, v59, v57)
            v61 = (<signed char>0)
            v62 = (<signed char>1)
            v63 = method62(v1, v30, v61, v62, v60)
            if v39:
                v65 = v2 + (<signed char>13)
            else:
                v65 = v2
            v66 = (<signed char>0)
            v67 = (<signed char>1)
            v68 = method62(v1, v65, v66, v67, v63)
            v69 = <unsigned long long>(<signed char>4)
            v70 = v69 << (<signed long>32)
            v71 = <unsigned long long>v68
            v72 = v70 | v71
            return v72
        else:
            v73 = v2 - (<signed char>1)
            return method69(v0, v1, v73)
    else:
        v76 = (<signed char>12)
        return method70(v0, v1, v76)
cdef unsigned long long method66(unsigned long long v0, unsigned long long v1, unsigned short v2, signed char v3, unsigned long v4, signed char v5) except *:
    cdef bint v6
    cdef bint v7
    cdef signed char v8
    cdef signed char v10
    cdef signed long v11
    cdef unsigned long long v12
    cdef signed char v13
    cdef signed char v14
    cdef bint v15
    cdef signed char v16
    cdef signed char v17
    cdef unsigned long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef unsigned long long v22
    cdef signed char v23
    cdef signed char v27
    cdef unsigned long v28
    cdef bint v29
    cdef unsigned long v30
    cdef signed char v31
    cdef unsigned long v32
    cdef bint v33
    cdef unsigned long v34
    cdef signed char v35
    cdef unsigned long v36
    cdef bint v37
    cdef unsigned long v38
    cdef signed char v39
    cdef unsigned long v40
    cdef bint v41
    cdef unsigned long v42
    cdef bint v43
    cdef unsigned long long v44
    cdef unsigned long long v45
    cdef unsigned long long v46
    cdef unsigned long long v47
    cdef signed char v48
    v6 = (<signed char>0) <= v5
    if v6:
        v7 = v3 == v5
        if v7:
            v8 = v5 - (<signed char>1)
            return method66(v0, v1, v2, v3, v4, v8)
        else:
            v10 = (<signed char>3) * v5
            v11 = <signed long>v10
            v12 = v0 >> v11
            v13 = <signed char>v12
            v14 = v13 & (<signed char>7)
            v15 = (<signed char>2) <= v14
            if v15:
                v16 = (<signed char>0)
                v17 = (<signed char>2)
                v18 = method62(v1, v5, v16, v17, v4)
                v19 = <unsigned long long>(<signed char>6)
                v20 = v19 << (<signed long>32)
                v21 = <unsigned long long>v18
                v22 = v20 | v21
                return v22
            else:
                v23 = v5 - (<signed char>1)
                return method66(v0, v1, v2, v3, v4, v23)
    else:
        v27 = (<signed char>0)
        v28 = method67(v1, v2, v27)
        v29 = v28 >= (<unsigned long>0)
        if v29:
            v30 = v28
        else:
            v30 = (<unsigned long>0)
        v31 = (<signed char>1)
        v32 = method67(v1, v2, v31)
        v33 = v32 >= v30
        if v33:
            v34 = v32
        else:
            v34 = v30
        v35 = (<signed char>2)
        v36 = method67(v1, v2, v35)
        v37 = v36 >= v34
        if v37:
            v38 = v36
        else:
            v38 = v34
        v39 = (<signed char>3)
        v40 = method67(v1, v2, v39)
        v41 = v40 >= v38
        if v41:
            v42 = v40
        else:
            v42 = v38
        v43 = (<unsigned long>0) < v42
        if v43:
            v44 = <unsigned long long>(<signed char>5)
            v45 = v44 << (<signed long>32)
            v46 = <unsigned long long>v42
            v47 = v45 | v46
            return v47
        else:
            v48 = (<signed char>8)
            return method69(v0, v1, v48)
cdef unsigned long long method65(unsigned long long v0, unsigned long long v1, unsigned short v2, signed char v3) except *:
    cdef bint v4
    cdef signed char v5
    cdef signed long v6
    cdef unsigned long long v7
    cdef signed char v8
    cdef signed char v9
    cdef bint v10
    cdef signed char v11
    cdef signed char v12
    cdef unsigned long v13
    cdef unsigned long v14
    cdef signed char v15
    cdef signed char v17
    cdef signed char v20
    cdef unsigned long v21
    cdef bint v22
    cdef unsigned long v23
    cdef signed char v24
    cdef unsigned long v25
    cdef bint v26
    cdef unsigned long v27
    cdef signed char v28
    cdef unsigned long v29
    cdef bint v30
    cdef unsigned long v31
    cdef signed char v32
    cdef unsigned long v33
    cdef bint v34
    cdef unsigned long v35
    cdef bint v36
    cdef unsigned long long v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef unsigned long long v40
    cdef signed char v41
    v4 = (<signed char>0) <= v3
    if v4:
        v5 = (<signed char>3) * v3
        v6 = <signed long>v5
        v7 = v0 >> v6
        v8 = <signed char>v7
        v9 = v8 & (<signed char>7)
        v10 = v9 == (<signed char>3)
        if v10:
            v11 = (<signed char>0)
            v12 = (<signed char>3)
            v13 = (<unsigned long>0)
            v14 = method62(v1, v3, v11, v12, v13)
            v15 = (<signed char>12)
            return method66(v0, v1, v2, v3, v14, v15)
        else:
            v17 = v3 - (<signed char>1)
            return method65(v0, v1, v2, v17)
    else:
        v20 = (<signed char>0)
        v21 = method67(v1, v2, v20)
        v22 = v21 >= (<unsigned long>0)
        if v22:
            v23 = v21
        else:
            v23 = (<unsigned long>0)
        v24 = (<signed char>1)
        v25 = method67(v1, v2, v24)
        v26 = v25 >= v23
        if v26:
            v27 = v25
        else:
            v27 = v23
        v28 = (<signed char>2)
        v29 = method67(v1, v2, v28)
        v30 = v29 >= v27
        if v30:
            v31 = v29
        else:
            v31 = v27
        v32 = (<signed char>3)
        v33 = method67(v1, v2, v32)
        v34 = v33 >= v31
        if v34:
            v35 = v33
        else:
            v35 = v31
        v36 = (<unsigned long>0) < v35
        if v36:
            v37 = <unsigned long long>(<signed char>5)
            v38 = v37 << (<signed long>32)
            v39 = <unsigned long long>v35
            v40 = v38 | v39
            return v40
        else:
            v41 = (<signed char>8)
            return method69(v0, v1, v41)
cdef unsigned long long method61(unsigned long long v0, unsigned long long v1, unsigned short v2, signed char v3) except *:
    cdef bint v4
    cdef signed char v5
    cdef signed long v6
    cdef unsigned long long v7
    cdef signed char v8
    cdef signed char v9
    cdef bint v10
    cdef signed char v11
    cdef signed char v12
    cdef unsigned long v13
    cdef unsigned long v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned long v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef signed char v22
    cdef signed char v25
    v4 = (<signed char>0) <= v3
    if v4:
        v5 = (<signed char>3) * v3
        v6 = <signed long>v5
        v7 = v0 >> v6
        v8 = <signed char>v7
        v9 = v8 & (<signed char>7)
        v10 = v9 == (<signed char>4)
        if v10:
            v11 = (<signed char>0)
            v12 = (<signed char>4)
            v13 = (<unsigned long>0)
            v14 = method62(v1, v3, v11, v12, v13)
            v15 = (<signed char>12)
            v16 = (<signed char>1)
            v17 = method63(v1, v3, v15, v16, v14)
            v18 = <unsigned long long>(<signed char>7)
            v19 = v18 << (<signed long>32)
            v20 = <unsigned long long>v17
            v21 = v19 | v20
            return v21
        else:
            v22 = v3 - (<signed char>1)
            return method61(v0, v1, v2, v22)
    else:
        v25 = (<signed char>12)
        return method65(v0, v1, v2, v25)
cdef unsigned long long method54(unsigned long long v0) except *:
    cdef signed char v1
    cdef unsigned short v2
    cdef unsigned short v3
    cdef signed char v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef signed char v7
    cdef unsigned long v8
    cdef bint v9
    cdef unsigned long v10
    cdef signed char v11
    cdef unsigned long v12
    cdef bint v13
    cdef unsigned long v14
    cdef signed char v15
    cdef unsigned long v16
    cdef bint v17
    cdef unsigned long v18
    cdef signed char v19
    cdef unsigned long v20
    cdef bint v21
    cdef unsigned long v22
    cdef bint v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef signed char v28
    v1 = (<signed char>0)
    v2 = (<unsigned short>0)
    v3 = method55(v0, v1, v2)
    v4 = (<signed char>0)
    v5 = (<unsigned long long>0)
    v6 = method57(v0, v4, v5)
    v7 = (<signed char>0)
    v8 = method59(v0, v3, v7)
    v9 = v8 >= (<unsigned long>0)
    if v9:
        v10 = v8
    else:
        v10 = (<unsigned long>0)
    v11 = (<signed char>1)
    v12 = method59(v0, v3, v11)
    v13 = v12 >= v10
    if v13:
        v14 = v12
    else:
        v14 = v10
    v15 = (<signed char>2)
    v16 = method59(v0, v3, v15)
    v17 = v16 >= v14
    if v17:
        v18 = v16
    else:
        v18 = v14
    v19 = (<signed char>3)
    v20 = method59(v0, v3, v19)
    v21 = v20 >= v18
    if v21:
        v22 = v20
    else:
        v22 = v18
    v23 = (<unsigned long>0) < v22
    if v23:
        v24 = <unsigned long long>(<signed char>8)
        v25 = v24 << (<signed long>32)
        v26 = <unsigned long long>v22
        v27 = v25 | v26
        return v27
    else:
        v28 = (<signed char>12)
        return method61(v6, v0, v3, v28)
cdef unsigned long long method53(signed char v0, signed char v1, numpy.ndarray[signed char,ndim=1] v2) except *:
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef signed long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef signed short v9
    cdef unsigned long long tmp50
    cdef Mut1 v10
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
    v3 = <signed long>v1
    v4 = (<unsigned long long>1) << v3
    v5 = (<unsigned long long>0) | v4
    v6 = <signed long>v0
    v7 = (<unsigned long long>1) << v6
    v8 = v5 | v7
    tmp50 = len(v2)
    if <signed short>tmp50 != tmp50: raise Exception("The conversion to signed short failed.")
    v9 = <signed short>tmp50
    v10 = Mut1((<signed short>0), v8)
    while method2(v9, v10):
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
    return method54(v22)
cdef object method52(signed short v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9):
    cdef signed short v10
    cdef unsigned long long tmp47
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    cdef Tuple2 tmp48
    cdef signed char v17
    cdef signed char v18
    cdef signed char v19
    cdef signed char v20
    cdef signed char v21
    cdef signed char v22
    cdef Tuple2 tmp49
    cdef signed char v23
    cdef signed char v24
    cdef signed char v25
    cdef signed char v26
    cdef signed char v27
    cdef signed char v28
    cdef signed char v29
    cdef signed char v30
    cdef signed char v31
    cdef signed char v32
    cdef bint v33
    cdef signed long v36
    cdef bint v34
    cdef bint v37
    cdef signed long v66
    cdef bint v38
    cdef signed long v41
    cdef bint v39
    cdef bint v42
    cdef bint v43
    cdef signed long v46
    cdef bint v44
    cdef bint v47
    cdef bint v48
    cdef signed long v51
    cdef bint v49
    cdef bint v52
    cdef bint v53
    cdef signed long v56
    cdef bint v54
    cdef bint v57
    cdef bint v58
    cdef bint v59
    cdef unsigned long long v67
    cdef unsigned long long v68
    cdef bint v69
    cdef signed long v72
    cdef bint v70
    cdef bint v73
    cdef bint v74
    cdef signed char v75
    cdef signed char v76
    cdef signed char v77
    cdef signed char v78
    cdef signed char v79
    cdef signed char v80
    cdef Tuple2 tmp51
    cdef signed char v81
    cdef signed char v82
    cdef signed char v83
    cdef signed char v84
    cdef signed char v85
    cdef signed char v86
    cdef Tuple2 tmp52
    cdef unsigned long long v87
    cdef unsigned long long v88
    cdef signed char v89
    cdef unsigned long v90
    cdef unsigned long v91
    cdef unsigned long v92
    cdef signed char v93
    cdef unsigned long v94
    cdef unsigned long v95
    cdef signed char v96
    cdef unsigned long v97
    cdef unsigned long v98
    cdef signed char v99
    cdef unsigned long v100
    cdef unsigned long v101
    cdef signed char v102
    cdef signed char v103
    cdef unsigned long long v104
    cdef unsigned long long v105
    cdef signed char v106
    cdef unsigned long v107
    cdef unsigned long v108
    cdef unsigned long v109
    cdef signed char v110
    cdef unsigned long v111
    cdef unsigned long v112
    cdef signed char v113
    cdef unsigned long v114
    cdef unsigned long v115
    cdef signed char v116
    cdef unsigned long v117
    cdef unsigned long v118
    cdef signed char v119
    cdef signed char v120
    cdef numpy.ndarray[signed char,ndim=1] v121
    cdef numpy.ndarray[signed char,ndim=1] v122
    cdef numpy.ndarray[signed char,ndim=1] v123
    cdef numpy.ndarray[signed char,ndim=1] v124
    cdef bint v125
    cdef float v126
    cdef bint v128
    cdef float v129
    cdef signed short v131
    cdef float v132
    tmp47 = len(v1)
    if <signed short>tmp47 != tmp47: raise Exception("The conversion to signed short failed.")
    v10 = <signed short>tmp47
    tmp48 = method1(v7, v6, v1)
    v11, v12, v13, v14, v15, v16 = tmp48.v0, tmp48.v1, tmp48.v2, tmp48.v3, tmp48.v4, tmp48.v5
    del tmp48
    tmp49 = method1(v3, v2, v1)
    v17, v18, v19, v20, v21, v22 = tmp49.v0, tmp49.v1, tmp49.v2, tmp49.v3, tmp49.v4, tmp49.v5
    del tmp49
    v23 = v11 % (<signed char>13)
    v24 = v12 % (<signed char>13)
    v25 = v13 % (<signed char>13)
    v26 = v14 % (<signed char>13)
    v27 = v15 % (<signed char>13)
    v28 = v17 % (<signed char>13)
    v29 = v18 % (<signed char>13)
    v30 = v19 % (<signed char>13)
    v31 = v20 % (<signed char>13)
    v32 = v21 % (<signed char>13)
    v33 = v16 < v22
    if v33:
        v36 = (<signed long>-1)
    else:
        v34 = v16 > v22
        if v34:
            v36 = (<signed long>1)
        else:
            v36 = (<signed long>0)
    v37 = v36 == (<signed long>0)
    if v37:
        v38 = v23 < v28
        if v38:
            v41 = (<signed long>-1)
        else:
            v39 = v23 > v28
            if v39:
                v41 = (<signed long>1)
            else:
                v41 = (<signed long>0)
        v42 = v41 == (<signed long>0)
        if v42:
            v43 = v24 < v29
            if v43:
                v46 = (<signed long>-1)
            else:
                v44 = v24 > v29
                if v44:
                    v46 = (<signed long>1)
                else:
                    v46 = (<signed long>0)
            v47 = v46 == (<signed long>0)
            if v47:
                v48 = v25 < v30
                if v48:
                    v51 = (<signed long>-1)
                else:
                    v49 = v25 > v30
                    if v49:
                        v51 = (<signed long>1)
                    else:
                        v51 = (<signed long>0)
                v52 = v51 == (<signed long>0)
                if v52:
                    v53 = v26 < v31
                    if v53:
                        v56 = (<signed long>-1)
                    else:
                        v54 = v26 > v31
                        if v54:
                            v56 = (<signed long>1)
                        else:
                            v56 = (<signed long>0)
                    v57 = v56 == (<signed long>0)
                    if v57:
                        v58 = v27 < v32
                        if v58:
                            v66 = (<signed long>-1)
                        else:
                            v59 = v27 > v32
                            if v59:
                                v66 = (<signed long>1)
                            else:
                                v66 = (<signed long>0)
                    else:
                        v66 = v56
                else:
                    v66 = v51
            else:
                v66 = v46
        else:
            v66 = v41
    else:
        v66 = v36
    v67 = method53(v7, v6, v1)
    v68 = method53(v3, v2, v1)
    v69 = v67 < v68
    if v69:
        v72 = (<signed long>-1)
    else:
        v70 = v67 > v68
        if v70:
            v72 = (<signed long>1)
        else:
            v72 = (<signed long>0)
    v73 = v72 == v66
    v74 = v73 != 1
    if v74:
        tmp51 = method1(v7, v6, v1)
        v75, v76, v77, v78, v79, v80 = tmp51.v0, tmp51.v1, tmp51.v2, tmp51.v3, tmp51.v4, tmp51.v5
        del tmp51
        tmp52 = method1(v3, v2, v1)
        v81, v82, v83, v84, v85, v86 = tmp52.v0, tmp52.v1, tmp52.v2, tmp52.v3, tmp52.v4, tmp52.v5
        del tmp52
        v87 = method53(v7, v6, v1)
        v88 = v87 >> (<signed long>32)
        v89 = <signed char>v88
        v90 = <unsigned long>v87
        v91 = v90 >> (<signed long>6)
        v92 = v90 & (<unsigned long>63)
        v93 = <signed char>v92
        v94 = v91 >> (<signed long>6)
        v95 = v91 & (<unsigned long>63)
        v96 = <signed char>v95
        v97 = v94 >> (<signed long>6)
        v98 = v94 & (<unsigned long>63)
        v99 = <signed char>v98
        v100 = v97 >> (<signed long>6)
        v101 = v97 & (<unsigned long>63)
        v102 = <signed char>v101
        v103 = <signed char>v100
        v104 = method53(v3, v2, v1)
        v105 = v104 >> (<signed long>32)
        v106 = <signed char>v105
        v107 = <unsigned long>v104
        v108 = v107 >> (<signed long>6)
        v109 = v107 & (<unsigned long>63)
        v110 = <signed char>v109
        v111 = v108 >> (<signed long>6)
        v112 = v108 & (<unsigned long>63)
        v113 = <signed char>v112
        v114 = v111 >> (<signed long>6)
        v115 = v111 & (<unsigned long>63)
        v116 = <signed char>v115
        v117 = v114 >> (<signed long>6)
        v118 = v114 & (<unsigned long>63)
        v119 = <signed char>v118
        v120 = <signed char>v117
        print(v1)
        v121 = numpy.empty(6,dtype=numpy.int8)
        v121[0] = v80; v121[1] = v75; v121[2] = v76; v121[3] = v77; v121[4] = v78; v121[5] = v79
        print(v121)
        del v121
        v122 = numpy.empty(6,dtype=numpy.int8)
        v122[0] = v86; v122[1] = v81; v122[2] = v82; v122[3] = v83; v122[4] = v84; v122[5] = v85
        print(v122)
        del v122
        v123 = numpy.empty(6,dtype=numpy.int8)
        v123[0] = v89; v123[1] = v103; v123[2] = v102; v123[3] = v99; v123[4] = v96; v123[5] = v93
        print(v123)
        del v123
        v124 = numpy.empty(6,dtype=numpy.int8)
        v124[0] = v106; v124[1] = v120; v124[2] = v119; v124[3] = v116; v124[4] = v113; v124[5] = v110
        print(v124)
        del v124
        raise Exception("The two hand rankers should have same comparison result.")
    else:
        pass
    v125 = v72 == (<signed long>0)
    if v125:
        v126 = <float>(<signed short>0)
        return Closure11(v6, v7, v8, v9, v2, v3, v4, v5, v1, v10, v0, v126)
    else:
        v128 = v72 == (<signed long>1)
        if v128:
            v129 = <float>v9
            return Closure11(v6, v7, v8, v9, v2, v3, v4, v5, v1, v10, v0, v129)
        else:
            v131 = -v9
            v132 = <float>v131
            return Closure11(v6, v7, v8, v9, v2, v3, v4, v5, v1, v10, v0, v132)
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
cdef object method80(signed short v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8):
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
cdef UH3 method81(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, US1 v11, float v12, float v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19):
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
            v23 = method79(v8, v9, v20, v5, v6, v7, v4, v1, v2, v3, v10)
        else:
            v23 = method80(v8, v10, v1, v2, v3, v4, v5, v6, v7)
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
cdef object method79(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10):
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
        return method80(v0, v10, v3, v4, v5, v6, v7, v8, v9)
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
        return Closure14(v7, v8, v9, v6, v3, v4, v5, v10, v0, v18, v20, v2, v1)
cdef UH3 method78(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, US1 v12, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
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
            v24 = method79(v9, v10, v21, v5, v6, v7, v4, v1, v2, v3, v11)
        else:
            v24 = method80(v9, v11, v1, v2, v3, v4, v5, v6, v7)
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
        return Closure12(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v17, v15, v24, v26, v2, v1)
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
    return Closure10(v2, v0, v1, v3, v17, v18, v19, v20, v13, v14, v15, v16)
cdef object method84(signed short v0, signed short v1, signed char v2, numpy.ndarray[signed char,ndim=1] v3, signed char v4, signed char v5, unsigned char v6, signed short v7, signed char v8, signed char v9, unsigned char v10):
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
    return Closure10(v2, v0, v1, v3, v16, v17, v18, v19, v12, v13, v14, v15)
cdef UH3 method85(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, US1 v12, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
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
            v24 = method83(v8, v9, v21, v5, v6, v7, v4, v1, v2, v3, v10, v11)
        else:
            v24 = method84(v8, v9, v11, v10, v1, v2, v3, v4, v5, v6, v7)
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
cdef object method83(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11):
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
        return method84(v0, v1, v11, v10, v3, v4, v5, v6, v7, v8, v9)
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
        return Closure18(v7, v8, v9, v6, v3, v4, v5, v10, v0, v19, v21, v2, v1, v11)
cdef UH3 method82(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, US1 v13, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
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
            v25 = method83(v9, v10, v22, v5, v6, v7, v4, v1, v2, v3, v11, v12)
        else:
            v25 = method84(v9, v10, v12, v11, v1, v2, v3, v4, v5, v6, v7)
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
        return Closure16(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v18, v16, v25, v27, v2, v1, v12)
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
    return Closure9(v2, v0, v1, v3, v4, v18, v19, v20, v21, v14, v15, v16, v17)
cdef object method88(signed short v0, signed short v1, signed char v2, signed char v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11):
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
    return Closure9(v2, v0, v1, v3, v4, v17, v18, v19, v20, v13, v14, v15, v16)
cdef UH3 method89(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, US1 v13, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
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
            v25 = method87(v8, v9, v22, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12)
        else:
            v25 = method88(v8, v9, v11, v12, v10, v1, v2, v3, v4, v5, v6, v7)
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
cdef object method87(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12):
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
        return method88(v0, v1, v11, v12, v10, v3, v4, v5, v6, v7, v8, v9)
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
        return Closure22(v7, v8, v9, v6, v3, v4, v5, v10, v0, v20, v22, v2, v1, v11, v12)
cdef UH3 method86(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, US1 v14, float v15, float v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22):
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
            v26 = method87(v9, v10, v23, v5, v6, v7, v4, v1, v2, v3, v11, v12, v13)
        else:
            v26 = method88(v9, v10, v12, v13, v11, v1, v2, v3, v4, v5, v6, v7)
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
        return Closure20(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v19, v17, v26, v28, v2, v1, v12, v13)
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
    return Closure8(v2, v0, v1, v3, v4, v5, v6, v7, v21, v22, v23, v24, v17, v18, v19, v20)
cdef object method92(signed short v0, signed short v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, numpy.ndarray[signed char,ndim=1] v7, signed char v8, signed char v9, unsigned char v10, signed short v11, signed char v12, signed char v13, unsigned char v14):
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
    return Closure8(v2, v0, v1, v3, v4, v5, v6, v7, v20, v21, v22, v23, v16, v17, v18, v19)
cdef UH3 method93(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15, US1 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
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
            v28 = method91(v8, v9, v25, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14, v15)
        else:
            v28 = method92(v8, v9, v11, v12, v13, v14, v15, v10, v1, v2, v3, v4, v5, v6, v7)
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
cdef object method91(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15):
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
        return method92(v0, v1, v11, v12, v13, v14, v15, v10, v3, v4, v5, v6, v7, v8, v9)
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
        return Closure26(v7, v8, v9, v6, v3, v4, v5, v10, v0, v23, v25, v2, v1, v11, v12, v13, v14, v15)
cdef UH3 method90(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16, US1 v17, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
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
            v29 = method91(v9, v10, v26, v5, v6, v7, v4, v1, v2, v3, v11, v12, v13, v14, v15, v16)
        else:
            v29 = method92(v9, v10, v12, v13, v14, v15, v16, v11, v1, v2, v3, v4, v5, v6, v7)
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
        return Closure24(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v22, v20, v29, v31, v2, v1, v12, v13, v14, v15, v16)
cdef UH3 method97(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, US1 v11, float v12, float v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19):
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
            v23 = method96(v8, v9, v20, v5, v6, v7, v4, v1, v2, v3, v10)
        else:
            v23 = method80(v8, v10, v1, v2, v3, v4, v5, v6, v7)
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
        v32 = method94(v8, v9, v31, v5, v6, v7, v30, v1, v2, v3, v4, v10)
        return v32(v12, v13, v14, v15, v16, v17, v18, v19)
cdef object method96(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10):
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
        return method80(v0, v10, v3, v4, v5, v6, v7, v8, v9)
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
        return Closure31(v7, v8, v9, v6, v3, v4, v5, v10, v0, v18, v20, v2, v1)
cdef UH3 method95(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, US1 v12, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
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
            v24 = method96(v9, v10, v21, v5, v6, v7, v4, v1, v2, v3, v11)
        else:
            v24 = method80(v9, v11, v1, v2, v3, v4, v5, v6, v7)
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
        v33 = method94(v9, v10, v32, v5, v6, v7, v31, v1, v2, v3, v4, v11)
        return v33(v13, v14, v15, v16, v17, v18, v19, v20)
cdef object method94(signed short v0, signed short v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11):
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
        return Closure29(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v17, v15, v24, v26, v2, v1)
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
            v104 = Closure28(v49, v3, v2, v15, v23, v14, v33, v41, v32, v57, v65, v96)
            del v96
        else:
            v98 = (<unsigned char>2) == v0
            if v98:
                v99 = numpy.empty(5,dtype=numpy.int8)
                v99[0] = v49; v99[1] = v57; v99[2] = v65; v99[3] = v73; v99[4] = v81
                v104 = Closure33(v49, v3, v2, v15, v23, v14, v33, v41, v32, v57, v65, v73, v81, v99)
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
cdef object method98(v0, v1, v2, v3, v4, numpy.ndarray[object,ndim=1] v5):
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
    cdef Mut3 v16
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
    cdef Tuple0 tmp53
    cdef numpy.ndarray[object,ndim=1] v75
    cdef object v76
    cdef Tuple0 tmp54
    cdef unsigned long long v77
    cdef unsigned long long v78
    cdef bint v79
    cdef bint v80
    cdef numpy.ndarray[object,ndim=1] v81
    cdef Mut3 v82
    cdef unsigned long long v84
    cdef object v85
    cdef float v86
    cdef float v87
    cdef US1 v88
    cdef Tuple5 tmp55
    cdef UH3 v89
    cdef unsigned long long v90
    cdef unsigned long long v91
    cdef unsigned long long v92
    cdef bint v93
    cdef bint v94
    cdef numpy.ndarray[object,ndim=1] v95
    cdef Mut3 v96
    cdef unsigned long long v98
    cdef object v99
    cdef float v100
    cdef float v101
    cdef US1 v102
    cdef Tuple5 tmp56
    cdef UH3 v103
    cdef unsigned long long v104
    cdef unsigned long long v105
    cdef unsigned long long v106
    cdef unsigned long long v107
    cdef numpy.ndarray[object,ndim=1] v108
    cdef Mut3 v109
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
    v16 = Mut3((<unsigned long long>0))
    while method28(v15, v16):
        v18 = v16.v0
        v19 = v5[v18]
        if v19.tag == 0: # Action
            v20 = (<UH3_0>v19).v0; v21 = (<UH3_0>v19).v1; v22 = (<UH3_0>v19).v2; v23 = (<UH3_0>v19).v3; v24 = (<UH3_0>v19).v4; v25 = (<UH3_0>v19).v5; v26 = (<UH3_0>v19).v6; v27 = (<UH3_0>v19).v7; v28 = (<UH3_0>v19).v8; v29 = (<UH3_0>v19).v9; v30 = (<UH3_0>v19).v10; v31 = (<UH3_0>v19).v11; v32 = (<UH3_0>v19).v12; v33 = (<UH3_0>v19).v13; v34 = (<UH3_0>v19).v14; v35 = (<UH3_0>v19).v15; v36 = (<UH3_0>v19).v16; v37 = (<UH3_0>v19).v17; v38 = (<UH3_0>v19).v18; v39 = (<UH3_0>v19).v19; v40 = (<UH3_0>v19).v20; v41 = (<UH3_0>v19).v21; v42 = (<UH3_0>v19).v22; v43 = (<UH3_0>v19).v23; v44 = (<UH3_0>v19).v24; v45 = (<UH3_0>v19).v25; v46 = (<UH3_0>v19).v26; v47 = (<UH3_0>v19).v27
            v48 = v40 == (<unsigned char>0)
            if v48:
                v8.append(v18)
                v10.append(Tuple1(v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46))
                v12.append(v47)
            else:
                v9.append(v18)
                v11.append(Tuple1(v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46))
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
        tmp53 = v4(v10)
        v73, v74 = tmp53.v0, tmp53.v1
        del tmp53
        tmp54 = v3(v11)
        v75, v76 = tmp54.v0, tmp54.v1
        del tmp54
        v77 = len(v12)
        v78 = len(v73)
        v79 = v77 == v78
        v80 = v79 == 0
        if v80:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v81 = numpy.empty(v77,dtype=object)
        v82 = Mut3((<unsigned long long>0))
        while method28(v77, v82):
            v84 = v82.v0
            v85 = v12[v84]
            tmp55 = v73[v84]
            v86, v87, v88 = tmp55.v0, tmp55.v1, tmp55.v2
            del tmp55
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
        v96 = Mut3((<unsigned long long>0))
        while method28(v91, v96):
            v98 = v96.v0
            v99 = v13[v98]
            tmp56 = v75[v98]
            v100, v101, v102 = tmp56.v0, tmp56.v1, tmp56.v2
            del tmp56
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
        v109 = Mut3((<unsigned long long>0))
        while method28(v107, v109):
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
        v118 = method98(v0, v1, v2, v3, v4, v108)
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
cdef numpy.ndarray[float,ndim=1] method99(v0, v1, numpy.ndarray[object,ndim=1] v2):
    cdef list v3
    cdef list v4
    cdef list v5
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef list v10
    cdef unsigned long long v11
    cdef Mut3 v12
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
    cdef Tuple0 tmp57
    cdef numpy.ndarray[object,ndim=1] v71
    cdef object v72
    cdef Tuple0 tmp58
    cdef unsigned long long v73
    cdef unsigned long long v74
    cdef bint v75
    cdef bint v76
    cdef numpy.ndarray[object,ndim=1] v77
    cdef Mut3 v78
    cdef unsigned long long v80
    cdef object v81
    cdef float v82
    cdef float v83
    cdef US1 v84
    cdef Tuple5 tmp59
    cdef UH3 v85
    cdef unsigned long long v86
    cdef unsigned long long v87
    cdef unsigned long long v88
    cdef bint v89
    cdef bint v90
    cdef numpy.ndarray[object,ndim=1] v91
    cdef Mut3 v92
    cdef unsigned long long v94
    cdef object v95
    cdef float v96
    cdef float v97
    cdef US1 v98
    cdef Tuple5 tmp60
    cdef UH3 v99
    cdef unsigned long long v100
    cdef unsigned long long v101
    cdef unsigned long long v102
    cdef unsigned long long v103
    cdef numpy.ndarray[object,ndim=1] v104
    cdef Mut3 v105
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
    cdef Mut0 v121
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
    cdef Mut3 v145
    cdef unsigned long long v147
    cdef unsigned long long v148
    cdef float v149
    cdef unsigned long long v150
    cdef unsigned long long v151
    cdef unsigned long long v152
    cdef bint v153
    cdef bint v154
    cdef Mut3 v155
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
    v12 = Mut3((<unsigned long long>0))
    while method28(v11, v12):
        v14 = v12.v0
        v15 = v2[v14]
        if v15.tag == 0: # Action
            v16 = (<UH3_0>v15).v0; v17 = (<UH3_0>v15).v1; v18 = (<UH3_0>v15).v2; v19 = (<UH3_0>v15).v3; v20 = (<UH3_0>v15).v4; v21 = (<UH3_0>v15).v5; v22 = (<UH3_0>v15).v6; v23 = (<UH3_0>v15).v7; v24 = (<UH3_0>v15).v8; v25 = (<UH3_0>v15).v9; v26 = (<UH3_0>v15).v10; v27 = (<UH3_0>v15).v11; v28 = (<UH3_0>v15).v12; v29 = (<UH3_0>v15).v13; v30 = (<UH3_0>v15).v14; v31 = (<UH3_0>v15).v15; v32 = (<UH3_0>v15).v16; v33 = (<UH3_0>v15).v17; v34 = (<UH3_0>v15).v18; v35 = (<UH3_0>v15).v19; v36 = (<UH3_0>v15).v20; v37 = (<UH3_0>v15).v21; v38 = (<UH3_0>v15).v22; v39 = (<UH3_0>v15).v23; v40 = (<UH3_0>v15).v24; v41 = (<UH3_0>v15).v25; v42 = (<UH3_0>v15).v26; v43 = (<UH3_0>v15).v27
            v5.append(v14)
            v44 = v36 == (<unsigned char>0)
            if v44:
                v6.append(Tuple1(v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42))
                v8.append(v43)
            else:
                v7.append(Tuple1(v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42))
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
        tmp57 = v1(v6)
        v69, v70 = tmp57.v0, tmp57.v1
        del tmp57
        tmp58 = v0(v7)
        v71, v72 = tmp58.v0, tmp58.v1
        del tmp58
        v73 = len(v8)
        v74 = len(v69)
        v75 = v73 == v74
        v76 = v75 == 0
        if v76:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v77 = numpy.empty(v73,dtype=object)
        v78 = Mut3((<unsigned long long>0))
        while method28(v73, v78):
            v80 = v78.v0
            v81 = v8[v80]
            tmp59 = v69[v80]
            v82, v83, v84 = tmp59.v0, tmp59.v1, tmp59.v2
            del tmp59
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
        v92 = Mut3((<unsigned long long>0))
        while method28(v87, v92):
            v94 = v92.v0
            v95 = v9[v94]
            tmp60 = v71[v94]
            v96, v97, v98 = tmp60.v0, tmp60.v1, tmp60.v2
            del tmp60
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
        v105 = Mut3((<unsigned long long>0))
        while method28(v103, v105):
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
        v114 = method99(v0, v1, v104)
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
        v121 = Mut0((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method0(v119, v121):
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
    v145 = Mut3((<unsigned long long>0))
    while method28(v141, v145):
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
    v155 = Mut3((<unsigned long long>0))
    while method28(v151, v155):
        v157 = v155.v0
        v158 = v3[v157]
        v159 = v4[v157]
        v140[v158] = v159
        v160 = v157 + (<unsigned long long>1)
        v155.v0 = v160
    del v3; del v4
    del v155
    return v140
cdef object method100(v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4):
    cdef list v5
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef unsigned long long v10
    cdef Mut3 v11
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
    cdef Tuple0 tmp61
    cdef unsigned long long v69
    cdef unsigned long long v70
    cdef bint v71
    cdef bint v72
    cdef numpy.ndarray[object,ndim=1] v73
    cdef Mut3 v74
    cdef unsigned long long v76
    cdef object v77
    cdef float v78
    cdef float v79
    cdef US1 v80
    cdef Tuple5 tmp62
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
    v11 = Mut3((<unsigned long long>0))
    while method28(v10, v11):
        v13 = v11.v0
        v14 = v4[v13]
        if v14.tag == 0: # Action
            v15 = (<UH3_0>v14).v0; v16 = (<UH3_0>v14).v1; v17 = (<UH3_0>v14).v2; v18 = (<UH3_0>v14).v3; v19 = (<UH3_0>v14).v4; v20 = (<UH3_0>v14).v5; v21 = (<UH3_0>v14).v6; v22 = (<UH3_0>v14).v7; v23 = (<UH3_0>v14).v8; v24 = (<UH3_0>v14).v9; v25 = (<UH3_0>v14).v10; v26 = (<UH3_0>v14).v11; v27 = (<UH3_0>v14).v12; v28 = (<UH3_0>v14).v13; v29 = (<UH3_0>v14).v14; v30 = (<UH3_0>v14).v15; v31 = (<UH3_0>v14).v16; v32 = (<UH3_0>v14).v17; v33 = (<UH3_0>v14).v18; v34 = (<UH3_0>v14).v19; v35 = (<UH3_0>v14).v20; v36 = (<UH3_0>v14).v21; v37 = (<UH3_0>v14).v22; v38 = (<UH3_0>v14).v23; v39 = (<UH3_0>v14).v24; v40 = (<UH3_0>v14).v25; v41 = (<UH3_0>v14).v26; v42 = (<UH3_0>v14).v27
            v7.append(v13)
            v8.append(Tuple1(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41))
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
        tmp61 = v3(v8)
        v67, v68 = tmp61.v0, tmp61.v1
        del tmp61
        v69 = len(v9)
        v70 = len(v67)
        v71 = v69 == v70
        v72 = v71 == 0
        if v72:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v73 = numpy.empty(v69,dtype=object)
        v74 = Mut3((<unsigned long long>0))
        while method28(v69, v74):
            v76 = v74.v0
            v77 = v9[v76]
            tmp62 = v67[v76]
            v78, v79, v80 = tmp62.v0, tmp62.v1, tmp62.v2
            del tmp62
            v81 = v77(v78, v79, v80)
            del v77; del v80
            v73[v76] = v81
            del v81
            v82 = v76 + (<unsigned long long>1)
            v74.v0 = v82
        del v67
        del v74
        v83 = method100(v0, v1, v2, v3, v73)
        del v73
        v85 = v68(v83)
        del v68; del v83
    else:
        v85 = v0
    del v8; del v9
    v86 = v1(v6)
    del v6
    return v2(v7, v85, v5, v86)
cdef numpy.ndarray[float,ndim=1] method101(v0, numpy.ndarray[object,ndim=1] v1):
    cdef list v2
    cdef list v3
    cdef list v4
    cdef list v5
    cdef list v6
    cdef unsigned long long v7
    cdef Mut3 v8
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
    cdef Tuple0 tmp63
    cdef unsigned long long v66
    cdef unsigned long long v67
    cdef bint v68
    cdef bint v69
    cdef numpy.ndarray[object,ndim=1] v70
    cdef Mut3 v71
    cdef unsigned long long v73
    cdef object v74
    cdef float v75
    cdef float v76
    cdef US1 v77
    cdef Tuple5 tmp64
    cdef UH3 v78
    cdef unsigned long long v79
    cdef numpy.ndarray[float,ndim=1] v80
    cdef numpy.ndarray[float,ndim=1] v82
    cdef numpy.ndarray[float,ndim=1] v84
    cdef unsigned long long v85
    cdef unsigned long long v86
    cdef bint v87
    cdef bint v88
    cdef Mut3 v89
    cdef unsigned long long v91
    cdef unsigned long long v92
    cdef float v93
    cdef unsigned long long v94
    cdef unsigned long long v95
    cdef unsigned long long v96
    cdef bint v97
    cdef bint v98
    cdef Mut3 v99
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
    v8 = Mut3((<unsigned long long>0))
    while method28(v7, v8):
        v10 = v8.v0
        v11 = v1[v10]
        if v11.tag == 0: # Action
            v12 = (<UH3_0>v11).v0; v13 = (<UH3_0>v11).v1; v14 = (<UH3_0>v11).v2; v15 = (<UH3_0>v11).v3; v16 = (<UH3_0>v11).v4; v17 = (<UH3_0>v11).v5; v18 = (<UH3_0>v11).v6; v19 = (<UH3_0>v11).v7; v20 = (<UH3_0>v11).v8; v21 = (<UH3_0>v11).v9; v22 = (<UH3_0>v11).v10; v23 = (<UH3_0>v11).v11; v24 = (<UH3_0>v11).v12; v25 = (<UH3_0>v11).v13; v26 = (<UH3_0>v11).v14; v27 = (<UH3_0>v11).v15; v28 = (<UH3_0>v11).v16; v29 = (<UH3_0>v11).v17; v30 = (<UH3_0>v11).v18; v31 = (<UH3_0>v11).v19; v32 = (<UH3_0>v11).v20; v33 = (<UH3_0>v11).v21; v34 = (<UH3_0>v11).v22; v35 = (<UH3_0>v11).v23; v36 = (<UH3_0>v11).v24; v37 = (<UH3_0>v11).v25; v38 = (<UH3_0>v11).v26; v39 = (<UH3_0>v11).v27
            v4.append(v10)
            v5.append(Tuple1(v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38))
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
        tmp63 = v0(v5)
        v64, v65 = tmp63.v0, tmp63.v1
        del tmp63
        v66 = len(v6)
        v67 = len(v64)
        v68 = v66 == v67
        v69 = v68 == 0
        if v69:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v70 = numpy.empty(v66,dtype=object)
        v71 = Mut3((<unsigned long long>0))
        while method28(v66, v71):
            v73 = v71.v0
            v74 = v6[v73]
            tmp64 = v64[v73]
            v75, v76, v77 = tmp64.v0, tmp64.v1, tmp64.v2
            del tmp64
            v78 = v74(v75, v76, v77)
            del v74; del v77
            v70[v73] = v78
            del v78
            v79 = v73 + (<unsigned long long>1)
            v71.v0 = v79
        del v64
        del v71
        v80 = method101(v0, v70)
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
    v89 = Mut3((<unsigned long long>0))
    while method28(v85, v89):
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
    v99 = Mut3((<unsigned long long>0))
    while method28(v95, v99):
        v101 = v99.v0
        v102 = v2[v101]
        v103 = v3[v101]
        v84[v102] = v103
        v104 = v101 + (<unsigned long long>1)
        v99.v0 = v104
    del v2; del v3
    del v99
    return v84
cdef UH3 method103(unsigned char v0, v1, UH3 v2):
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
    cdef Tuple0 tmp65
    cdef float v35
    cdef float v36
    cdef US1 v37
    cdef Tuple5 tmp66
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
            v32[(<unsigned long long>0)] = Tuple1(v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29)
            del v5; del v8; del v19
            tmp65 = v1(v32)
            v33, v34 = tmp65.v0, tmp65.v1
            del tmp65
            del v32; del v34
            tmp66 = v33[(<unsigned long long>0)]
            v35, v36, v37 = tmp66.v0, tmp66.v1, tmp66.v2
            del tmp66
            del v33
            v38 = v30(v35, v36, v37)
            del v30; del v37
            return method103(v0, v1, v38)
    elif v2.tag == 1: # Terminal
        v41 = (<UH3_1>v2).v0; v42 = (<UH3_1>v2).v1; v44 = (<UH3_1>v2).v3; v45 = (<UH3_1>v2).v4; v47 = (<UH3_1>v2).v6; v48 = (<UH3_1>v2).v7; v49 = (<UH3_1>v2).v8; v50 = (<UH3_1>v2).v9; v51 = (<UH3_1>v2).v10; v52 = (<UH3_1>v2).v11; v53 = (<UH3_1>v2).v12; v54 = (<UH3_1>v2).v13; v55 = (<UH3_1>v2).v14; v56 = (<UH3_1>v2).v15; v58 = (<UH3_1>v2).v17; v59 = (<UH3_1>v2).v18; v60 = (<UH3_1>v2).v19; v61 = (<UH3_1>v2).v20
        return v2
cdef UH0 method105(UH0 v0, UH0 v1):
    cdef US0 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # Cons
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method105(v3, v4)
    elif v0.tag == 1: # Nil
        return v1
cdef str method107(signed char v0):
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
cdef void method108(list v0, list v1) except *:
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
cdef void method106(list v0, list v1, bint v2, UH0 v3) except *:
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
            v7 = method107(v6)
            v1.append(v7)
            del v7
            v8 = 1
            method106(v0, v1, v8, v5)
        elif v4.tag == 1: # C2of2
            v9 = (<US0_1>v4).v0
            method108(v0, v1)
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
            method106(v0, v1, v16, v5)
    elif v3.tag == 1: # Nil
        method108(v0, v1)
cdef list method104(UH0 v0):
    cdef list v1
    cdef list v2
    cdef bint v3
    cdef UH0 v4
    cdef UH0 v5
    v1 = [None]*(<unsigned long long>0)
    v2 = [None]*(<unsigned long long>0)
    v3 = 1
    v4 = UH0_1()
    v5 = method105(v0, v4)
    del v4
    method106(v1, v2, v3, v5)
    del v2; del v5
    return v1
cdef str method109(signed char v0, signed char v1):
    cdef str v2
    cdef str v3
    v2 = method107(v1)
    v3 = method107(v0)
    return f'{v2}{v3}'
cdef str method112(unsigned long long v0):
    cdef unsigned long long v1
    cdef signed char v2
    cdef unsigned long v3
    cdef unsigned long v4
    cdef unsigned long v5
    cdef signed char v6
    cdef unsigned long v7
    cdef unsigned long v8
    cdef signed char v9
    cdef unsigned long v10
    cdef unsigned long v11
    cdef signed char v12
    cdef unsigned long v13
    cdef unsigned long v14
    cdef signed char v15
    cdef signed char v16
    cdef bint v17
    cdef bint v18
    cdef bint v19
    cdef bint v20
    cdef bint v21
    cdef bint v22
    cdef bint v23
    cdef bint v24
    cdef bint v25
    v1 = v0 >> (<signed long>32)
    v2 = <signed char>v1
    v3 = <unsigned long>v0
    v4 = v3 >> (<signed long>6)
    v5 = v3 & (<unsigned long>63)
    v6 = <signed char>v5
    v7 = v4 >> (<signed long>6)
    v8 = v4 & (<unsigned long>63)
    v9 = <signed char>v8
    v10 = v7 >> (<signed long>6)
    v11 = v7 & (<unsigned long>63)
    v12 = <signed char>v11
    v13 = v10 >> (<signed long>6)
    v14 = v10 & (<unsigned long>63)
    v15 = <signed char>v14
    v16 = <signed char>v13
    v17 = (<signed char>0) == v2
    if v17:
        return "high card"
    else:
        v18 = (<signed char>1) == v2
        if v18:
            return "pair"
        else:
            v19 = (<signed char>2) == v2
            if v19:
                return "two pair"
            else:
                v20 = (<signed char>3) == v2
                if v20:
                    return "triple"
                else:
                    v21 = (<signed char>4) == v2
                    if v21:
                        return "straight"
                    else:
                        v22 = (<signed char>5) == v2
                        if v22:
                            return "flush"
                        else:
                            v23 = (<signed char>6) == v2
                            if v23:
                                return "full house"
                            else:
                                v24 = (<signed char>7) == v2
                                if v24:
                                    return "four of a kind"
                                else:
                                    v25 = (<signed char>8) == v2
                                    if v25:
                                        return "straight flush"
                                    else:
                                        raise Exception("Invalid card score.")
cdef str method113(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4):
    cdef str v5
    cdef str v6
    cdef str v7
    cdef str v8
    cdef str v9
    v5 = method107(v4)
    v6 = method107(v3)
    v7 = method107(v2)
    v8 = method107(v1)
    v9 = method107(v0)
    return f'{v5}{v6}{v7}{v8}{v9}'
cdef void method111(numpy.ndarray[signed char,ndim=1] v0, list v1, unsigned char v2, signed char v3, signed char v4) except *:
    cdef bint v5
    cdef str v6
    cdef unsigned long long v7
    cdef str v8
    cdef unsigned long long v9
    cdef signed char v10
    cdef unsigned long v11
    cdef unsigned long v12
    cdef unsigned long v13
    cdef signed char v14
    cdef unsigned long v15
    cdef unsigned long v16
    cdef signed char v17
    cdef unsigned long v18
    cdef unsigned long v19
    cdef signed char v20
    cdef unsigned long v21
    cdef unsigned long v22
    cdef signed char v23
    cdef signed char v24
    cdef str v25
    cdef str v26
    v5 = v2 == (<unsigned char>0)
    if v5:
        v6 = "Player One"
    else:
        v6 = "Player Two"
    v7 = method53(v4, v3, v0)
    v8 = method112(v7)
    v9 = v7 >> (<signed long>32)
    v10 = <signed char>v9
    v11 = <unsigned long>v7
    v12 = v11 >> (<signed long>6)
    v13 = v11 & (<unsigned long>63)
    v14 = <signed char>v13
    v15 = v12 >> (<signed long>6)
    v16 = v12 & (<unsigned long>63)
    v17 = <signed char>v16
    v18 = v15 >> (<signed long>6)
    v19 = v15 & (<unsigned long>63)
    v20 = <signed char>v19
    v21 = v18 >> (<signed long>6)
    v22 = v18 & (<unsigned long>63)
    v23 = <signed char>v22
    v24 = <signed char>v21
    v25 = method113(v14, v17, v20, v23, v24)
    v26 = f'{v6} shows {v8} {v25}'
    del v6; del v8; del v25
    v1.append(v26)
cdef void method114(float v0, list v1, unsigned char v2) except *:
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
cdef str method110(bint v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9, float v10, list v11):
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
        method111(v1, v11, v21, v13, v14)
        v22 = (<unsigned char>1)
        method111(v1, v11, v22, v17, v18)
    else:
        pass
    v23 = (<unsigned char>0)
    method114(v10, v11, v23)
    v24 = (<unsigned char>1)
    method114(v10, v11, v24)
    return "\n".join(v11)
cdef void method102(v0, v1, unsigned char v2, signed short v3, UH3 v4) except *:
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
    cdef numpy.ndarray[signed char,ndim=1] v59
    cdef signed short v60
    cdef unsigned long long tmp67
    cdef list v61
    cdef Mut5 v62
    cdef signed short v64
    cdef signed char v65
    cdef str v66
    cdef signed short v67
    cdef str v68
    cdef object v69
    cdef object v70
    cdef float v71
    cdef float v72
    cdef UH0 v73
    cdef float v74
    cdef float v75
    cdef UH0 v76
    cdef float v77
    cdef float v78
    cdef signed char v79
    cdef signed char v80
    cdef unsigned char v81
    cdef signed short v82
    cdef signed char v83
    cdef signed char v84
    cdef unsigned char v85
    cdef signed short v86
    cdef numpy.ndarray[signed char,ndim=1] v87
    cdef signed short v88
    cdef signed short v89
    cdef bint v90
    cdef float v91
    cdef bint v92
    cdef UH0 v93
    cdef list v94
    cdef str v95
    cdef object v96
    cdef object v97
    cdef object v98
    cdef object v99
    cdef float v101
    cdef signed short v102
    cdef bint v103
    cdef signed char v104
    cdef signed char v105
    cdef unsigned char v106
    cdef signed short v107
    cdef signed char v108
    cdef signed char v109
    cdef unsigned char v110
    cdef signed short v111
    cdef signed short v112
    cdef str v113
    cdef signed short v114
    cdef str v115
    cdef numpy.ndarray[signed char,ndim=1] v116
    cdef signed short v117
    cdef unsigned long long tmp68
    cdef list v118
    cdef Mut5 v119
    cdef signed short v121
    cdef signed char v122
    cdef str v123
    cdef signed short v124
    cdef str v125
    cdef object v126
    cdef object v127
    v5 = method103(v2, v0, v4)
    if v5.tag == 0: # Action
        v6 = (<UH3_0>v5).v0; v7 = (<UH3_0>v5).v1; v8 = (<UH3_0>v5).v2; v9 = (<UH3_0>v5).v3; v10 = (<UH3_0>v5).v4; v11 = (<UH3_0>v5).v5; v12 = (<UH3_0>v5).v6; v13 = (<UH3_0>v5).v7; v14 = (<UH3_0>v5).v8; v15 = (<UH3_0>v5).v9; v16 = (<UH3_0>v5).v10; v17 = (<UH3_0>v5).v11; v18 = (<UH3_0>v5).v12; v19 = (<UH3_0>v5).v13; v20 = (<UH3_0>v5).v14; v21 = (<UH3_0>v5).v15; v22 = (<UH3_0>v5).v16; v23 = (<UH3_0>v5).v17; v24 = (<UH3_0>v5).v18; v25 = (<UH3_0>v5).v19; v26 = (<UH3_0>v5).v20; v27 = (<UH3_0>v5).v21; v28 = (<UH3_0>v5).v22; v29 = (<UH3_0>v5).v23; v30 = (<UH3_0>v5).v24; v31 = (<UH3_0>v5).v25; v32 = (<UH3_0>v5).v26; v33 = (<UH3_0>v5).v27
        v34 = v2 == (<unsigned char>0)
        if v34:
            v35 = v8
        else:
            v35 = v11
        del v8; del v11
        v36 = method104(v35)
        del v35
        v37 = "\n".join(v36)
        del v36
        if v28:
            v40 = Closure41(v0, v1, v2, v3, v33)
        else:
            v40 = False
        if v29:
            v43 = Closure42(v0, v1, v2, v3, v33)
        else:
            v43 = False
        v44 = Closure43(v0, v1, v2, v3, v33)
        del v33
        v45 = {'call': v44, 'fold': v40, 'raise_max': v30, 'raise_min': v31, 'raise_to': v43}
        del v40; del v43; del v44
        v46 = v2 == v16
        if v46:
            v47, v48, v49, v50, v51, v52, v53, v54 = v14, v15, v16, v17, v18, v19, v20, v21
        else:
            v47, v48, v49, v50, v51, v52, v53, v54 = v18, v19, v20, v21, v14, v15, v16, v17
        v55 = v3 - v50
        v56 = method109(v48, v47)
        v57 = v3 - v54
        v58 = method109(v52, v51)
        v59 = v22[:v23]
        del v22
        tmp67 = len(v59)
        if <signed short>tmp67 != tmp67: raise Exception("The conversion to signed short failed.")
        v60 = <signed short>tmp67
        v61 = [None]*v60
        v62 = Mut5((<signed short>0))
        while method36(v60, v62):
            v64 = v62.v0
            v65 = v59[v64]
            v66 = method107(v65)
            v61[v64] = v66
            del v66
            v67 = v64 + (<signed short>1)
            v62.v0 = v67
        del v59
        del v62
        v68 = "".join(v61)
        del v61
        v69 = {'community_card': v68, 'my_card': v56, 'my_pot': v50, 'my_stack': v55, 'op_card': v58, 'op_pot': v54, 'op_stack': v57}
        del v56; del v58; del v68
        v70 = {'actions': v45, 'table_data': v69, 'trace': v37}
        del v37; del v45; del v69
        v1(v70)
    elif v5.tag == 1: # Terminal
        v71 = (<UH3_1>v5).v0; v72 = (<UH3_1>v5).v1; v73 = (<UH3_1>v5).v2; v74 = (<UH3_1>v5).v3; v75 = (<UH3_1>v5).v4; v76 = (<UH3_1>v5).v5; v77 = (<UH3_1>v5).v6; v78 = (<UH3_1>v5).v7; v79 = (<UH3_1>v5).v8; v80 = (<UH3_1>v5).v9; v81 = (<UH3_1>v5).v10; v82 = (<UH3_1>v5).v11; v83 = (<UH3_1>v5).v12; v84 = (<UH3_1>v5).v13; v85 = (<UH3_1>v5).v14; v86 = (<UH3_1>v5).v15; v87 = (<UH3_1>v5).v16; v88 = (<UH3_1>v5).v17; v89 = (<UH3_1>v5).v18; v90 = (<UH3_1>v5).v19; v91 = (<UH3_1>v5).v20
        v92 = v2 == (<unsigned char>0)
        if v92:
            v93 = v73
        else:
            v93 = v76
        del v73; del v76
        v94 = method104(v93)
        del v93
        v95 = method110(v90, v87, v83, v84, v85, v86, v79, v80, v81, v82, v91, v94)
        del v94
        v96 = False
        v97 = False
        v98 = False
        v99 = {'call': v96, 'fold': v97, 'raise_max': (<signed short>0), 'raise_min': (<signed short>0), 'raise_to': v98}
        del v96; del v97; del v98
        if v92:
            v101 = v91
        else:
            v101 = -v91
        v102 = round(v101)
        v103 = v2 == v81
        if v103:
            v104, v105, v106, v107, v108, v109, v110, v111 = v79, v80, v81, v82, v83, v84, v85, v86
        else:
            v104, v105, v106, v107, v108, v109, v110, v111 = v83, v84, v85, v86, v79, v80, v81, v82
        v112 = v89 + v102
        v113 = method109(v105, v104)
        v114 = v89 - v102
        v115 = method109(v109, v108)
        v116 = v87[:v88]
        del v87
        tmp68 = len(v116)
        if <signed short>tmp68 != tmp68: raise Exception("The conversion to signed short failed.")
        v117 = <signed short>tmp68
        v118 = [None]*v117
        v119 = Mut5((<signed short>0))
        while method36(v117, v119):
            v121 = v119.v0
            v122 = v116[v121]
            v123 = method107(v122)
            v118[v121] = v123
            del v123
            v124 = v121 + (<signed short>1)
            v119.v0 = v124
        del v116
        del v119
        v125 = "".join(v118)
        del v118
        v126 = {'community_card': v125, 'my_card': v113, 'my_pot': (<signed short>0), 'my_stack': v112, 'op_card': v115, 'op_pot': (<signed short>0), 'op_stack': v114}
        del v113; del v115; del v125
        v127 = {'actions': v99, 'table_data': v126, 'trace': v95}
        del v95; del v99; del v126
        v1(v127)
cpdef object main():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef object v8
    v0 = collections.namedtuple("Size",['action', 'policy', 'value'])((<signed short>18), (<signed short>69), (<signed short>124))
    v1 = Closure0()
    v2 = collections.namedtuple("Neural",['handler', 'size'])(v1, v0)
    del v0; del v1
    v3 = Closure3()
    v4 = Closure4()
    v5 = Closure5()
    v6 = Closure35()
    v7 = {'callbot_player': v3, 'neural': v2, 'uniform_player': v4, 'vs_one': v5, 'vs_self': v6}
    del v2; del v3; del v4; del v5; del v6
    v8 = Closure39()
    return {'train': v7, 'ui': v8}
