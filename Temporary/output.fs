Error in CudaKernel: Ln: 2 Col: 1
inl {stream Cuda CudaTensor} ->
^
Expecting: number, '!', '"', '"""', '\'', '(', '-', '.', '//', '@', '@"', '[',
'cuda', 'false', 'function', 'if', 'inb', 'inm', 'join', 'join_type', 'match',
'met', 'true', 'type', 'use' or '{'

The parser backtracked after:
  Error in CudaKernel: Ln: 2 Col: 5
  inl {stream Cuda CudaTensor} ->
      ^
  Expecting: identifier, '(' or '//'

The parser backtracked after:
  Error in CudaKernel: Ln: 2 Col: 5
  inl {stream Cuda CudaTensor} ->
      ^
  Expecting: open or openb or '//'

The parser backtracked after:
  Error in CudaKernel: Ln: 2 Col: 5
  inl {stream Cuda CudaTensor} ->
      ^
  Expecting: '//' or 'rec'

The parser backtracked after:
  Error in CudaKernel: Ln: 2 Col: 5
  inl {stream Cuda CudaTensor} ->
      ^
  Expecting: '//'
  Other error messages:
    inl not allowed as an identifier.

The parser backtracked after:
  Error in CudaKernel: Ln: 2 Col: 30
  inl {stream Cuda CudaTensor} ->
                               ^
  Expecting: '&', ',', '//', ':', '::', '=', '=>', 'as', 'when' or '|'

The parser backtracked after:
  Error in CudaKernel: Ln: 3 Col: 5
      open HostTensor
      ^
  Expecting: '//'

  The parser backtracked after:
    Error in CudaKernel: Ln: 421 Col: 13
            run {
                ^
    Expecting: identifier, number, '!', '"', '"""', '\'', '(', ',', '-', '.',
    '//', ':', ':=', ';', '<-', '@', '@"', '[', '\\/', 'cuda', 'false',
    'function', 'if', 'inb', 'inl', 'inm', 'join', 'join_type', 'match', 'met',
    'true', 'type' or 'use'
    Other error messages:
      Statements not allowed in the last position of a block.

    The parser backtracked after:
      Error in CudaKernel: Ln: 425 Col: 23
                      forcd {from=threadIdx.y+blockDim.y*blockIdx.y-dim_in_a.fr
                            ^
      Expecting: identifier, number, '!', '"', '"""', '\'', '(', ',', '-', '.',
      '//', ':', ':=', ';', '<-', '@', '@"', '[', '\\/', 'cuda', 'false',
      'function', 'if', 'inb', 'inl', 'inm', 'join', 'join_type', 'match',
      'met', 'true', 'type', 'use' or '}'

      The parser backtracked after:
        Error in CudaKernel: Ln: 425 Col: 134
        rom; by=gridDim.y*blockDim.y; near_to=dim_in_a.near_to; body=inl {i} ->
                                                                     ^
        Expecting: number, '!', '"', '"""', '\'', '(', '-', '.', '@', '@"', '['
        , 'cuda', 'false', 'function', 'if', 'inb', 'inm', 'join', 'join_type',
        'match', 'met', 'true', 'type', 'use' or '{'

        The parser backtracked after:
          Error in CudaKernel: Ln: 425 Col: 138
          m; by=gridDim.y*blockDim.y; near_to=dim_in_a.near_to; body=inl {i} ->
                                                                         ^
          Expecting: identifier, '(' or '//'

        The parser backtracked after:
          Error in CudaKernel: Ln: 425 Col: 138
          m; by=gridDim.y*blockDim.y; near_to=dim_in_a.near_to; body=inl {i} ->
                                                                         ^
          Expecting: open or openb or '//'

        The parser backtracked after:
          Error in CudaKernel: Ln: 425 Col: 138
          m; by=gridDim.y*blockDim.y; near_to=dim_in_a.near_to; body=inl {i} ->
                                                                         ^
          Expecting: '//' or 'rec'

        The parser backtracked after:
          Error in CudaKernel: Ln: 425 Col: 138
          m; by=gridDim.y*blockDim.y; near_to=dim_in_a.near_to; body=inl {i} ->
                                                                         ^
          Expecting: '//'
          Other error messages:
            inl not allowed as an identifier.

        The parser backtracked after:
          Error in CudaKernel: Ln: 425 Col: 142
          m; by=gridDim.y*blockDim.y; near_to=dim_in_a.near_to; body=inl {i} ->
                                                                             ^
          Expecting: '&', ',', '//', ':', '::', '=', '=>', 'as', 'when' or '|'

        The parser backtracked after:
          Error in CudaKernel: Ln: 426 Col: 21
                              inl in, out = in i, out i
                              ^
          Expecting: '//'

          The parser backtracked after:
            Error in CudaKernel: Ln: 451 Col: 21
                                }
                                ^
            Expecting: identifier, number, '!', '"', '"""', '\'', '(', '-', '.'
            , '//', ';', '@', '@"', '[', 'cuda', 'false', 'function', 'if',
            'inb', 'inl', 'inm', 'join', 'join_type', 'match', 'met', 'true',
            'type', 'use' or '{'
            Other error messages:
              Statements not allowed in the last position of a block.
