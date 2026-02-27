module.exports = {
  env: {
    es6: true,
    browser: true,
    commonjs: true,
  },
  extends: [
    'eslint:recommended',
    'plugin:@typescript-eslint/eslint-recommended',
    'plugin:@typescript-eslint/recommended',
  ],
  parser: '@typescript-eslint/parser',
  parserOptions: {
    jsx: true,
    useJSXTextNode: true,
    ecmaVersion: 6,
    sourceType: 'module',
    project: './tsconfig.json',
  },
  plugins: ['@typescript-eslint', 'react'],
  settings: {
    react: {
      version: '17',
    },
  },
  rules: {
    // ── TypeScript ────────────────────────────────────────────────────────────
    'react/prop-types': 'off',
    '@typescript-eslint/no-explicit-any': 'error',
    '@typescript-eslint/no-non-null-assertion': 'error',
    '@typescript-eslint/explicit-function-return-type': 'off',
    '@typescript-eslint/no-var-requires': 'off',
    '@typescript-eslint/naming-convention': [
      'error',
      {
        selector: 'interface',
        format: ['PascalCase'],
        custom: { regex: '^I[A-Z]', match: true },
      },
      {
        selector: 'enum',
        format: ['PascalCase'],
      },
      {
        selector: 'typeAlias',
        format: ['PascalCase'],
      },
    ],
    '@typescript-eslint/member-delimiter-style': [
      'error',
      {
        multiline: { delimiter: 'semi', requireLast: true },
        singleline: { delimiter: 'semi', requireLast: false },
      },
    ],

    // ── General ───────────────────────────────────────────────────────────────
    'no-var': 'error',
    'prefer-const': 'error',
    'eqeqeq': ['error', 'always', { null: 'ignore' }],
    'object-shorthand': 'error',
    'no-console': 'warn',
    'spaced-comment': ['error', 'always'],
    'no-trailing-spaces': 'error',
    'no-multiple-empty-lines': ['error', { max: 1, maxEOF: 0 }],
    'nonblock-statement-body-position': ['error', 'below'],
    'curly': ['error', 'multi'],
    'brace-style': ['error', 'stroustrup'],

    // ── React / JSX ───────────────────────────────────────────────────────────
    'react/self-closing-comp': 'error',
    'react/jsx-boolean-value': ['error', 'always'],
  },
};
