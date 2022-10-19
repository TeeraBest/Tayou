
export interface UserOptions {
  username: string;
  password: string;
  phone: string;
  loginType: string;
}

export interface changePassword {
  oldPassword: string;
  newPassword: string;
  confirmPassword: string;
  token: string;
}

export interface userAccount {
  username: string; password: string; phone: string; email: string; birthday: string; point: number;
}
