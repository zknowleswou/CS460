import { AuthenticationError } from "./AuthenticationError";
import { AuthToken } from "./AuthToken";

export class SignInResult{
    succeeded:boolean;
    errors: AuthenticationError[];
    token: AuthToken;
}