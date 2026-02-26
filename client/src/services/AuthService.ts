class AuthService {
  private key = 'token';

  public getToken(): string {
    return localStorage.getItem(this.key) || '';
  }

  public setToken(value: string) {
    localStorage.setItem(this.key, value);
  }
}

const authService = new AuthService();

export default authService;
