async function http<T = unknown>(method: string, url: string, headers?: HeadersInit): Promise<T> {
  const response = await fetch(url, {
    method,
    headers: {
      'Content-Type': 'application/json',
      ...headers,
    },
  });

  let responseJSON;
  const contentType = response.headers.get('Content-Type');
  if (contentType && contentType.includes('application/json'))
    responseJSON = await response.json();

 else
responseJSON = undefined;

  if (response.status === 200)
    return responseJSON;

 else
    throw new Error(responseJSON?.message);

}

export async function get<T = unknown>(url: string, headers?: HeadersInit): Promise<T> {
  return await http<T>('GET', url, headers);
}

export async function post<T = unknown>(url: string, headers?: HeadersInit): Promise<T> {
  return await http<T>('POST', url, headers);
}
