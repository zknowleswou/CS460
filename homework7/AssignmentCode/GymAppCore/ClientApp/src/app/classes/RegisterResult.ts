import { AuthenticationError } from "./AuthenticationError";

export class RegisterResult {
    succeeded: boolean;
    errors: AuthenticationError[];
    authToken: string;
}