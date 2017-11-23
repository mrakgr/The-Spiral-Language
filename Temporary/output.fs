Error in Core: Ln: 92 Col: 1
inl assert c = function
^
Expecting: number, '!', '"', '"""', '\'', '(', '-', '.', '//', ';', '@', '@"',
'[', 'cuda', 'false', 'function', 'if', 'if_dynamic', 'inb', 'inm', 'join',
'match', 'met', 'open', 'true', 'type', 'use' or '{'
Other error messages:
  Statements not allowed in the last position of a block.

The parser backtracked after:
  Error in Core: Ln: 92 Col: 5
  inl assert c = function
      ^
  Expecting: '//' or 'rec'

The parser backtracked after:
  Error in Core: Ln: 92 Col: 5
  inl assert c = function
      ^
  Expecting: '//'
  Other error messages:
    inl not allowed as an identifier.

The parser backtracked after:
  Error in Core: Ln: 92 Col: 12
  inl assert c = function
             ^
  Expecting: '&', ',', '//', ':', '::', '=', '=>', 'as', 'when' or '|'

The parser backtracked after:
  Error in Core: Ln: 92 Col: 14
  inl assert c = function
               ^
  Expecting: identifier, number, '!', '"', '"""', '#', '&', '\'', '(', ',',
  '->', '.', '//', ':', '::', '=>', '@', '@"', '[', '_', 'as', 'false', 'true',
  'when', '{' or '|'

The parser backtracked after:
  Error in Core: Ln: 92 Col: 16
  inl assert c = function
                 ^
  Expecting: number, '!', '"', '"""', '\'', '(', '-', '.', '//', '@', '@"', '['
  , 'cuda', 'false', 'if', 'if_dynamic', 'inb', 'inl', 'inm', 'join', 'match',
  'met', 'open', 'true', 'type', 'use' or '{'

  The parser backtracked after:
    Error in Core: Ln: 93 Col: 5
        | msg : string -> if c then () else failwith unit msg
        ^
    Expecting: identifier, number, '!', '"', '"""', '#', '\'', '(', '.', '//',
    '@', '@"', '[', '_', 'false', 'true' or '{'

  The parser backtracked after:
    Error in Core: Ln: 93 Col: 5
        | msg : string -> if c then () else failwith unit msg
        ^
    Expecting: '//'
    Other error messages:
      function not allowed as an identifier.
