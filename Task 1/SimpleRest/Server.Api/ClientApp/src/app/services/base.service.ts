import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import BaseRequestModel from '../api/base-request.model';

@Injectable({
    providedIn: 'root'
})
export class BaseService {
    constructor(protected httpClient: HttpClient) { }

    protected get GetOriginUrl(): string { return 'http://localhost:5000'; };
    protected static readonly MY_OBJECT_ENDPOINT = 'MyObject';
    protected static readonly MY_OBJECT_COUNT_ENDPOINT = 'MyObject/GetMyObjectsCount';

    protected Get<T>(url: string, params?: { [param: string]: string | number | boolean | ReadonlyArray<string | number | boolean> }) {
        return this.httpClient.get<T>(`${this.GetOriginUrl}/api/v1/${url}`, { params: params });
    }

    protected Post<T>(url: string, body: string) {
        return this.httpClient.post<T>(`${this.GetOriginUrl}/api/v1/${url}`, body, { headers: new HttpHeaders({ 'content-type': 'application/json' }) });
    }

    protected PostFormData<T extends { formData: FormData }>(url: string, model: T) {
        return this.httpClient.post(`${this.GetOriginUrl}/api/v1/${url}`, model.formData, {
            reportProgress: true,
            observe: 'events',
            responseType: 'text'
        })
    }
}